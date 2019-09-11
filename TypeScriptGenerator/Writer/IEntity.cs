namespace TypeScriptGenerator.Writer
{
    /// <summary>
    /// Interface that is implemented of all typescript top level entities: Interface, enum, etc. 
    /// </summary>
    public interface IEntity
    {
        void WriteEntity(IWriter writer);
    }
}