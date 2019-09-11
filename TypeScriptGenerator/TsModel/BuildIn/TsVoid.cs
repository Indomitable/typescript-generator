using TypeScriptGenerator.Writer;

namespace TypeScriptGenerator.TsModel.BuildIn
{
    public class TsVoid: TsType
    {
        public override void Write(IWriter writer)
        {
            writer.Write("void");
        }
    }
}
