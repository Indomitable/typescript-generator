using TypeScriptGenerator.Writer;

namespace TypeScriptGenerator.TsModel.BuildIn
{
    public sealed class TsNever: TsType
    {
        private static TsNever instance;
        public static TsNever Instance => instance ?? (instance = new TsNever());

        public override void Write(IWriter writer)
        {
            writer.Write("never");
        }
    }
}
