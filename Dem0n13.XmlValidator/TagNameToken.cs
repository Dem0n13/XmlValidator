namespace Dem0n13.XmlValidator
{
    public class TagNameToken : Token
    {
        private readonly string _originalString;

        public TagNameToken(string originalString)
        {
            _originalString = originalString;
        }

        public override string OriginalString
        {
            get { return _originalString; }
        }
    }
}