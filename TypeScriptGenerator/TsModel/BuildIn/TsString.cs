using TypeScriptGenerator.Writer;

namespace TypeScriptGenerator.TsModel.BuildIn
{
    public class TsString: TsType
    {
        public override void Write(IWriter writer)
        {
            writer.Write("string");
        }
    }
}