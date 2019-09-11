using TypeScriptGenerator.Writer;

namespace TypeScriptGenerator.TsModel
{
    public class TsIndexProperty: IWritable
    {
        public TsField Key { get; set; }
        public TsType Value { get; set; }
        public void Write(IWriter writer)
        {
            writer.StartList();
            Key.Write(writer);
            writer.WriteTypeDeclarator();
            Value.Write(writer);
        }
    }
}
