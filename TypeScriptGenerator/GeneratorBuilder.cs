using System;
using System.Collections.Generic;
using System.Reflection;
using TypeScriptGenerator.TsModel;
using TypeScriptGenerator.TsModel.BuildIn;

namespace TypeScriptGenerator
{
    public class GeneratorBuilder
    {
        private readonly Options option;

        /// <summary>
        /// List of types that need to be converted
        /// </summary>
        private List<Type> types = new List<Type>();

        /// <summary>
        /// A type mapping that need to be used for converting like string -> TsString.
        /// </summary>
        private Dictionary<Type, TsType> strictMappings = new Dictionary<Type, TsType>();

        /// <summary>
        /// A type mapping that need to be used for converting using base class for example
        /// all IEnumerable[T] classes will be converted to T[];
        /// </summary>
        private Dictionary<Type, TsType> baseMappings = new Dictionary<Type, TsType>();

        private GeneratorBuilder(Options option)
        {
            this.option = option;
            RegisterStrictMapping(typeof(bool), TsBoolean.Instance);

            RegisterStrictMapping(typeof(byte), TsNumber.Instance);
            RegisterStrictMapping(typeof(short), TsNumber.Instance);
            RegisterStrictMapping(typeof(int), TsNumber.Instance);
            RegisterStrictMapping(typeof(long), TsNumber.Instance);
            RegisterStrictMapping(typeof(float), TsNumber.Instance);
            RegisterStrictMapping(typeof(double), TsNumber.Instance);

            RegisterStrictMapping(typeof(void), TsVoid.Instance);
            RegisterStrictMapping(typeof(object), TsAny.Instance);
            RegisterStrictMapping(typeof(string), TsString.Instance);

            RegisterBaseMapping(typeof(IEnumerable<>), CreateEnumerableType());
            RegisterBaseMapping(typeof(IDictionary<,>), CreateDictionaryType());
        }

        public static GeneratorBuilder CreateBuilder(Options option)
        {
            return new GeneratorBuilder(option);
        }

        public GeneratorBuilder AddType(Type type)
        {
            types.Add(type);
            return this;
        }

        public GeneratorBuilder AddTypes(IEnumerable<Type> types)
        {
            foreach (var type in types)
            {
                AddType(type);
            }
            return this;
        }

        public GeneratorBuilder RegisterStrictMapping(Type type, TsType tsType)
        {
            types.Add(type.GetTypeInfo());
            return this;
        }

        public GeneratorBuilder RegisterBaseMapping(Type type, TsType tsType)
        {
            types.Add(type.GetTypeInfo());
            return this;
        }

        public IGenerator Build()
        {
            var resolver = new TsTypeConverter(types, strictMappings, baseMappings);
            return new Generator(option, resolver);
        }

        private static TsType CreateEnumerableType()
        {
            return new TsArray(new TsGenericArgument("T"));
        }

        private static TsType CreateDictionaryType()
        {
            var tsType = new TsInlineInterface();
            tsType.Name = "Dictionary";
            tsType.IndexProperty = new TsIndexProperty(new TsField("key", new TsGenericArgument("TKey")), new TsGenericArgument("TValue"));
            return tsType;
        }
    }
}
