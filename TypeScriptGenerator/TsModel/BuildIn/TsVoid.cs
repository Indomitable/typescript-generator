using TypeScriptGenerator.Writer;

namespace TypeScriptGenerator.TsModel.BuildIn
{
    internal sealed class TsVoid: TsType
    {
        public override void Write(IWriter writer)
        {
            writer.Write("void");
        }
    }
}
