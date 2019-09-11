using System.Collections.Generic;
using TypeScriptGenerator.Writer;

namespace TypeScriptGenerator.TsModel
{
    internal sealed class TsInterface: TsInlineInterface, IEntity
    {
        public TsInterface()
        {
            GenericArguments = new List<TsType>();
            Extends = new List<TsInterface>();
        }

        public List<TsType> GenericArguments { get; }
        
        public List<TsInterface> Extends { get; }

        /// <summary>
        /// Writes an interface in a type for example Class0 or Class1[number] or Class2[T]
        /// </summary>
        /// <param name="writer"></param>
        public override void Write(IWriter writer)
        {
            if (!string.IsNullOrEmpty(Module))
            {
                writer.Write(Module);
                writer.Write(".");
            }
            writer.Write(Name);
            if (GenericArguments.Count > 0)
            {
                writer.StartGenericArgumentList();
                writer.WriteList(GenericArguments);
                writer.EndGenericArgumentList();
            }
        }

        public void WriteEntity(IWriter writer)
        {
            writer.Write("interface");
            writer.WordDelimiter();
            writer.Write(Name);
            if (GenericArguments.Count > 0)
            {
                writer.StartGenericArgumentList();
                writer.WriteList(GenericArguments);
                writer.EndGenericArgumentList();
            }
            writer.WordDelimiter();
            
            if (Extends.Count > 0)
            {
                writer.Write("extends");
                writer.WriteList(Extends);
                writer.WordDelimiter();
            }
            
            writer.StartBlock();
            
            if (IndexProperty != null)
            {
                writer.WriteIndent();
                IndexProperty.Write(writer);
                writer.EndStatement();
                writer.NewLine();
            }

            foreach (var field in Fields)
            {
                writer.WriteIndent();
                field.Write(writer);
                writer.EndStatement();
                writer.NewLine();
            }

            foreach (var method in Methods)
            {
                writer.WriteIndent();
                method.Write(writer);
                writer.EndStatement();
                writer.NewLine();
            }
            
            writer.EndBlock();
        }
    }
}
