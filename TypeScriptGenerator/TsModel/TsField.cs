using System.Text;
using TypeScriptGenerator.Writer;

namespace TypeScriptGenerator.TsModel
{
    internal sealed class TsField: IWritable
    {
        public TsType FieldType { get; set; }
        public string Name { get; set; }
        public bool IsOptional { get; set; }
        
        public void Write(IWriter writer)
        {
            writer.WriteName(Name, IsOptional);
            writer.WriteTypeDeclarator();
            FieldType.Write(writer);
        }
    }
}
