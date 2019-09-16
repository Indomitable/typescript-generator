using System.Collections.Generic;
using TypeScriptGenerator.Writer;

namespace TypeScriptGenerator.TsModel
{
    public class TsInlineInterface: TsType
    {
        public TsInlineInterface()
        {
            Fields = new List<TsField>();
            Methods = new List<TsMethod>();
        }
        public TsIndexProperty IndexProperty { get; set; }

        public List<TsField> Fields { get; }

        public List<TsMethod> Methods { get;  }
        
        /// <summary>
        /// Write TsInline interface like { [key: number]: string; t: boolean; method(): void;  }
        /// </summary>
        /// <param name="writer"></param>
        public override void Write(IWriter writer)
        {
            writer.StartBlock();
            if (IndexProperty != null)
            {
                IndexProperty.Write(writer);
                writer.EndStatement();
            }

            foreach (var field in Fields)
            {
                field.Write(writer);
                writer.EndStatement();
            }

            foreach (var method in Methods)
            {
                method.Write(writer);
                writer.EndStatement();
            }
            writer.EndBlock();
        }
    }
}
