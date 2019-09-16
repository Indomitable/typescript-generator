using TypeScriptGenerator.Writer;

namespace TypeScriptGenerator.TsModel
{
    public class TsArray: TsType
    {
        public TsArray(TsType ofType, int dimension = 1)
        {
            this.OfType = ofType;
            this.Dimension = dimension;
        }

        public TsType OfType { get; }

        public int Dimension { get; }

        public override void Write(IWriter writer)
        {
            OfType.Write(writer);
            for (var i = 0; i < this.Dimension; i++)
            {
                writer.StartList();
                writer.EndList();
            }
        }
    }
}
