using TypeScriptGenerator.Writer;

namespace TypeScriptGenerator.TsModel.BuildIn
{
    internal sealed class TsString: TsType
    {
        public override void Write(IWriter writer)
        {
            writer.Write("string");
        }
    }
}