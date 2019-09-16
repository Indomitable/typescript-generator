using TypeScriptGenerator.Writer;

namespace TypeScriptGenerator.TsModel
{
    public sealed class TsIndexProperty: IWritable
    {
        public TsIndexProperty(TsField key, TsType value)
        {
            Key = key;
            Value = value;
        }
        public TsField Key { get; }
        public TsType Value { get; }
        public void Write(IWriter writer)
        {
            writer.StartList();
            Key.Write(writer);
            writer.WriteTypeDeclarator();
            Value.Write(writer);
        }
    }
}
