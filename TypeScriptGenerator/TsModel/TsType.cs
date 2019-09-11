using TypeScriptGenerator.Writer;

namespace TypeScriptGenerator.TsModel
{
    internal abstract class TsType: IWritable
    {
        public string Name { get; set; }
        public string Module { get; set; }
        public abstract void Write(IWriter writer);
    }
}
