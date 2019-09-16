using TypeScriptGenerator.Writer;

namespace TypeScriptGenerator.TsModel.BuildIn
{
    public sealed class TsNumber: TsType
    {
        private static TsNumber instance;
        public static TsNumber Instance => instance ?? (instance = new TsNumber());

        public override void Write(IWriter writer)
        {
            writer.Write("number");
        }
    }
}
