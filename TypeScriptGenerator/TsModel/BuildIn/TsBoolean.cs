using TypeScriptGenerator.Writer;

namespace TypeScriptGenerator.TsModel.BuildIn
{
    internal sealed class TsBoolean: TsType
    {
        public override void Write(IWriter writer)
        {
            writer.Write("boolean");
        }
    }
}
