using TypeScriptGenerator.Writer;

namespace TypeScriptGenerator.TsModel.BuildIn
{
    public sealed class TsAny: TsType
    {
        private static TsAny instance;
        public static TsAny Instance => instance ?? (instance = new TsAny());
        
        public override void Write(IWriter writer)
        {
            writer.Write("any");
        }
    }
}
