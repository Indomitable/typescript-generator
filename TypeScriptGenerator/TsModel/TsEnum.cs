using TypeScriptGenerator.Writer;

namespace TypeScriptGenerator.TsModel
{
    public sealed class TsEnum: TsType
    {
        public override void Write(IWriter writer)
        {
            if (!string.IsNullOrEmpty(Module))
            {
                writer.Write(Module);
                writer.AccessToken();
            }
            writer.Write(Name);
        }
    }
}
