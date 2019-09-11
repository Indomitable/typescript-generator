using TypeScriptGenerator.Writer;

namespace TypeScriptGenerator.TsModel.BuildIn
{
    public class TsNever: TsType
    {
        public override void Write(IWriter writer)
        {
            writer.Write("never");
        }
    }
}