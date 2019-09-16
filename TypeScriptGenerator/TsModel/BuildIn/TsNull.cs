using TypeScriptGenerator.Writer;

namespace TypeScriptGenerator.TsModel.BuildIn
{
    public sealed class TsNull: TsType
    {
        private static TsNull instance;
        public static TsNull Instance => instance ?? (instance = new TsNull());

        public override void Write(IWriter writer)
        {
            writer.Write("null");
        }
    }
}
