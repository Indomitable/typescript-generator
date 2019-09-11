using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeScriptGenerator.Writer
{
    public interface IWriter
    {
        void Write(string statement);
        void WriteName(string name, bool isOptional);
        void StartBlock();
        void EndBlock();
        void EndStatement();
        void StartGenericArgumentList();
        void EndGenericArgumentList();
        void StartArgumentList();
        void EndArgumentList();

        void StartList();
        void EndList();
        void WriteTypeDeclarator();
        string ToString();

        void WriteList(IEnumerable<IWritable> list);
    }

    public class Writer : IWriter
    {
        private readonly StringBuilder builder = new StringBuilder();
        private int indent = 0;
        
        
        public Writer()
        {
            
        }

        public void Write(string statement)
        {
            builder.Append(statement);
        }
        
        public void WriteName(string name, bool isOptional)
        {
            builder.Append(name);
            if (isOptional)
            {
                builder.Append(Constants.OptionalIndicator);
            }
        }

        public void StartBlock()
        {
            builder.AppendLine(Constants.StartBlock);
            indent++;
        }

        public void EndBlock()
        {
            builder.AppendLine(Constants.EndBlock);
            indent--;
        }

        public void EndStatement()
        {
            builder.AppendLine(Constants.EndStatement);
        }

        public void StartGenericArgumentList()
        {
            builder.Append(Constants.StartGenericArgumentsList);
        }

        public void EndGenericArgumentList()
        {
            builder.Append(Constants.EndGenericArgumentsList);
        }
        
        public void StartArgumentList()
        {
            builder.Append(Constants.StartArgumentsList);
        }

        public void EndArgumentList()
        {
            builder.Append(Constants.EndArgumentsList);
        }

        public void StartList()
        {
            builder.Append(Constants.StartList);
        }

        public void EndList()
        {
            builder.Append(Constants.EndList);
        }

        public void WriteTypeDeclarator()
        {
            builder.Append(Constants.TypeDeclarator);
        }

        public void WriteList(IEnumerable<IWritable> list)
        {
            using (var enumerator = list.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    while(true)
                    {
                        enumerator.Current.Write(this);
                        if (enumerator.MoveNext())
                        {
                            Write(Constants.ListSeparator);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }
        
        public override string ToString()
        {
            return builder.ToString();
        }

        private void WriteIndent()
        {
            builder.Append(string.Join(string.Empty, Enumerable.Repeat(Constants.IndentChar, indent)));
        }
    }
}
