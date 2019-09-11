using TypeScriptGenerator.Writer;

namespace TypeScriptGenerator.TsModel
{
    internal sealed class TsGenericArgument: TsType
    {
        public override void Write(IWriter writer)
        {
            writer.Write(Name);
        }
    }
}