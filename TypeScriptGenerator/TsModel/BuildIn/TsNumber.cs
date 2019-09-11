using TypeScriptGenerator.Writer;

namespace TypeScriptGenerator.TsModel.BuildIn
{
    public class TsNumber: TsType
    {
        public override void Write(IWriter writer)
        {
            writer.Write("number");
        }
    }
}