namespace TypeScriptGenerator
{
    public class Options
    {
        /// <summary>
        /// Generate the ts entity as optional when is nullable type
        /// usually the json deserializers drop null values so in the client it becomes optional
        /// if your json deserialize settings are to preserve nulls then set to false.
        /// </summary>
        public bool MakeOptionalWhenIsNullable { get; set; } = true;
    }
}
