using TypeScriptGenerator.TsModel.BuildIn;
using TypeScriptGenerator.Writer;

namespace TypeScriptGenerator.TsModel
{
    public class TsUnionType: TsType
    {
        private readonly TsType[] types;

        public static TsUnionType CreateNullableType(TsType baseType, Options options)
        {
            return options.MakeOptionalWhenIsNullable
                ? new TsUnionType(baseType, TsUndefined.Instance)
                : new TsUnionType(baseType, TsNull.Instance);
        }

        public TsUnionType(params TsType[] types)
        {
            this.types = types;
        }

        public override void Write(IWriter writer)
        {
            writer.WriteUnion(types);
        }
    }
}
