using TypeScriptGenerator.Writer;

namespace TypeScriptGenerator.TsModel.BuildIn
{
    internal sealed class TsNull: TsType
    {
        public override void Write(IWriter writer)
        {
            writer.Write("null");
        }
    }
}
