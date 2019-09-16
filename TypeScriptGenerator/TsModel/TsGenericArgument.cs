using TypeScriptGenerator.Writer;

namespace TypeScriptGenerator.TsModel
{
    public sealed class TsGenericArgument: TsType
    {
        public TsGenericArgument(string name)
        {
            this.Name = name;
        }

        public override void Write(IWriter writer)
        {
            writer.Write(Name);
        }
    }
}
