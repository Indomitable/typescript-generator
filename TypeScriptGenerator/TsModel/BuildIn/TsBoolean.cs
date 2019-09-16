using TypeScriptGenerator.Writer;

namespace TypeScriptGenerator.TsModel.BuildIn
{
    public sealed class TsBoolean: TsType
    {
        private static TsBoolean instance;
        public static TsBoolean Instance => instance ?? (instance = new TsBoolean());

        public override void Write(IWriter writer)
        {
            writer.Write("boolean");
        }
    }
}
