using TypeScriptGenerator.Writer;

namespace TypeScriptGenerator.TsModel.BuildIn
{
    internal sealed class TsNever: TsType
    {
        public override void Write(IWriter writer)
        {
            writer.Write("never");
        }
    }
}