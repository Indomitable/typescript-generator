using TypeScriptGenerator.Writer;

namespace TypeScriptGenerator.TsModel.BuildIn
{
    public class TsNull: TsType
    {
        public override void Write(IWriter writer)
        {
            writer.Write("null");
        }
    }
}
