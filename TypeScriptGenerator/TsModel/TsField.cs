using System.Text;
using TypeScriptGenerator.Writer;

namespace TypeScriptGenerator.TsModel
{
    public sealed class TsField: IWritable
    {
        public TsField(string name, TsType type, bool isOptional = false)
        {
            Name = name;
            FieldType = type;
            IsOptional = isOptional;
        }

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
