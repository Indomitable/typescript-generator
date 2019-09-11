using TypeScriptGenerator.Writer;

namespace TypeScriptGenerator.TsModel.BuildIn
{
    public class TsUndefined: TsType
    {
        public override void Write(IWriter writer)
        {
            writer.Write("undefined");
        }
    }
}