using TypeScriptGenerator.Writer;

namespace TypeScriptGenerator.TsModel.BuildIn
{
    internal sealed class TsNumber: TsType
    {
        public override void Write(IWriter writer)
        {
            writer.Write("number");
        }
    }
}