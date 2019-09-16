using System.Collections.Generic;
using System.Linq;
using System.Text;
using TypeScriptGenerator.Writer;

namespace TypeScriptGenerator.TsModel
{
    public sealed class TsMethod: IWritable
    {
        public TsMethod()
        {
            GenericArguments = new List<TsGenericArgument>();
            Arguments = new List<TsField>();
        }
        
        public string Name { get; set; }
        public TsType ReturnType { get; set; }
        public List<TsGenericArgument> GenericArguments { get; set; }
        public List<TsField> Arguments { get; set; }

        public bool IsOptional { get; set; }


        public void Write(IWriter writer)
        {
            writer.WriteName(Name, IsOptional);
            if (GenericArguments.Count > 0)
            {
                writer.StartGenericArgumentList();
                writer.WriteList(GenericArguments);
                writer.EndGenericArgumentList();
            }
            writer.StartArgumentList();
            writer.WriteList(Arguments);
            writer.EndArgumentList();

            writer.WriteTypeDeclarator();
            ReturnType.Write(writer);
        }
    }
}
