using TypeScriptGenerator.Writer;

namespace TypeScriptGenerator.TsModel.BuildIn
{
    public sealed class TsUndefined: TsType
    {
        private static TsUndefined instance;
        public static TsUndefined Instance => instance ?? (instance = new TsUndefined());

        public override void Write(IWriter writer)
        {
            writer.Write("undefined");
        }
    }
}
