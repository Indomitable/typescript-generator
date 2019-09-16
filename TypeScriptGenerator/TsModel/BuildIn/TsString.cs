using TypeScriptGenerator.Writer;

namespace TypeScriptGenerator.TsModel.BuildIn
{
    public sealed class TsString: TsType
    {
        private static TsString instance;
        public static TsString Instance => instance ?? (instance = new TsString());

        public override void Write(IWriter writer)
        {
            writer.Write("string");
        }
    }
}
