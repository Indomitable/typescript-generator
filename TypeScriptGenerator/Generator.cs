using System;

namespace TypeScriptGenerator
{
    public interface IGenerator
    {
        string Generate();
    }

    internal sealed class Generator : IGenerator
    {
        private readonly Options option;
        private readonly TsTypeConverter typeConverter;

        internal Generator(Options option, TsTypeConverter typeConverter)
        {
            this.option = option;
            this.typeConverter = typeConverter;
        }

        public string Generate()
        {
            throw new NotImplementedException();
        }
    }
}
