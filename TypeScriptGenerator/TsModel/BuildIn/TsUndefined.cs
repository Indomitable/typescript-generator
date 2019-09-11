using TypeScriptGenerator.Writer;

namespace TypeScriptGenerator.TsModel.BuildIn
{
    internal sealed class TsUndefined: TsType
    {
        public override void Write(IWriter writer)
        {
            writer.Write("undefined");
        }
    }
}