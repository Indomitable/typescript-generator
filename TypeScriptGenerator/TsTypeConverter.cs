using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TypeScriptGenerator.TsModel;

namespace TypeScriptGenerator
{
    internal sealed class TsTypeConverter
    {
        private static readonly BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly;

        private readonly List<Type> initialTypes;

        private readonly Dictionary<Type, TsType> strictMappings;

        private readonly Dictionary<Type, TsType> baseMappings;

        private readonly Dictionary<Type, TsType> convertedTypes = new Dictionary<Type, TsType>();

        public TsTypeConverter(
            List<Type> initialTypes,
            Dictionary<Type, TsType> strictMappings,
            Dictionary<Type, TsType> baseMappings)
        {
            this.initialTypes = initialTypes;
            this.strictMappings = strictMappings;
            this.baseMappings = baseMappings;
        }

        IEnumerable<TsType> Resolve()
        {
            ReadTypes();
            return convertedTypes.Select(_ => _.Value);
        }

        private void ReadTypes()
        {
            foreach (var type in initialTypes)
            {
                var tsType = ReadType(type);
                convertedTypes.Add(type, tsType);
            }
        }

        private TsType ReadType(Type type)
        {
            if (type.IsEnum)
            {
                return new TsEnum();
            }

            if (type.IsClass)
            {
                return ReadClass(type);
            }

            throw new NotSupportedException($"Type {type.FullName} is not supported");
        }

        private TsType ReadClass(Type classType)
        {
            if (!(GetDictionaryType(classType) is null))
            {
                return ReadDictionary(classType);
            }

            throw new NotSupportedException($"Type {classType.FullName} is not supported");
        }

        private bool IsEnumerable(Type typeInfo)
        {
            return typeInfo.GetInterfaces().Any(_ => _.IsGenericType && _.GetGenericTypeDefinition() == typeof(IEnumerable<>));
        }

        private Type GetDictionaryType(Type typeInfo)
        {
            // Check if not Enumerable<KeyValuePair<,>> => Dictionary.
            return typeInfo.GetInterfaces().FirstOrDefault(_ => _.IsGenericType &&
                                                                _.GetGenericTypeDefinition() == typeof(IEnumerable<>) &&
                                                                _.GetGenericArguments().Any(ga =>
                                                                    ga.IsGenericType && ga.GetGenericTypeDefinition() == typeof(KeyValuePair<,>))
            );
        }

        private TsType ReadDictionary(Type dictType)
        {
            var keyValueInterface = GetDictionaryType(dictType);
            var keyValuePair = keyValueInterface.GetGenericArguments()
                .Single(_ => _.IsGenericType && _.GetGenericTypeDefinition() == typeof(KeyValuePair<,>));
            var tsInterface = new TsInterface();
            var keyValueArguments = keyValuePair.GetGenericArguments();
            var keyType = keyValueArguments[0];
            var valueType = keyValueArguments[1];
            var keyTsType = ResolveType(keyType);
            var valueTsType = ResolveType(valueType);
            tsInterface.IndexProperty = new TsIndexProperty(new TsField("key", keyTsType), valueTsType);
            return ReadGenericClass(tsInterface, dictType);
        }

        private TsType ReadGenericClass(TsInterface tsType, Type type)
        {
            if (type.IsGenericType)
            {
                var genericArguments = type.GetGenericArguments();
                foreach (var genericArgument in genericArguments)
                {
                    tsType.GenericArguments.Add(new TsGenericArgument(genericArgument.Name));
                }
            }

            ReadFields(tsType, type);
            ReadMethods(tsType, type);
            return tsType;
        }

        private void ReadMethods(TsInterface tsType, IReflect type)
        {
            var methods = type.GetMethods(bindingFlags);
            foreach (var method in methods)
            {
                var tsMethod = new TsMethod();
                tsMethod.Name = method.Name;
                if (method.IsGenericMethod)
                {
                    var generics = method.GetGenericArguments();
                    foreach (var generic in generics)
                    {
                        tsMethod.GenericArguments.Add(new TsGenericArgument(generic.Name));
                    }
                }

                foreach (var parameterInfo in method.GetParameters())
                {
                    var field = new TsField(parameterInfo.Name, ResolveType(parameterInfo.ParameterType), IsTypeOptional(parameterInfo.ParameterType));
                    tsMethod.Arguments.Add(field);
                }

                tsMethod.ReturnType = ResolveType(method.ReturnType);
                tsType.Methods.Add(tsMethod);
            }
        }

        private void ReadFields(TsInterface tsType, IReflect type)
        {
            void AddField(string name, Type memberType)
            {
                var tsField = new TsField(name, ResolveType(memberType), IsTypeOptional(memberType));
                tsType.Fields.Add(tsField);
            }

            var fields = type.GetFields(bindingFlags);
            foreach (var field in fields)
            {
                AddField(field.Name, field.FieldType);
            }

            var properties = type.GetProperties(bindingFlags);
            foreach (var property in properties)
            {
                AddField(property.Name, property.PropertyType);
            }
        }

        private bool IsTypeOptional(Type type)
        {
            //TODO: Add support for attribute which to specify optional fields
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        private TsType ResolveType(Type type)
        {
            if (type.IsGenericParameter)
            {
                return new TsGenericArgument(type.Name);
            }

            if (convertedTypes.TryGetValue(type, out var convertedType))
            {
                return convertedType;
            }

            var tsType = ReadType(type);
            convertedTypes.Add(type, tsType);
            return tsType;
        }
    }
}
