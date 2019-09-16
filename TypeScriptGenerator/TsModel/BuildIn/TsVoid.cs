using TypeScriptGenerator.Writer;

namespace TypeScriptGenerator.TsModel.BuildIn
{
    public sealed class TsVoid: TsType
    {
        private static TsVoid instance;
        public static TsVoid Instance => instance ?? (instance = new TsVoid());

        public override void Write(IWriter writer)
        {
            writer.Write("void");
        }
    }
}
