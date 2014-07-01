namespace Dem0n13.XmlValidator
{
    public class Tag
    {
        public readonly string Name;
        public readonly TagType Type;

        public Tag(string name, TagType type)
        {
            Name = name;
            Type = type;
        }

        public override string ToString()
        {
            return string.Format("<{0}{1}>", Type == TagType.Opening ? "" : "/", Name);
        }
    }
}