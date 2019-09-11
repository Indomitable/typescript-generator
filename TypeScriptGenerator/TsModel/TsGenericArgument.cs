using TypeScriptGenerator.Writer;

namespace TypeScriptGenerator.TsModel
{
    public class TsGenericArgument: TsType
    {
        public override void Write(IWriter writer)
        {
            writer.Write(Name);
        }
    }
}