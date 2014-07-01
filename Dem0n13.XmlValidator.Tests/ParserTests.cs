using System;
using System.Linq;
using NUnit.Framework;

namespace Dem0n13.XmlValidator.Tests
{
    [TestFixture]
    public class ParserTests
    {
        private XmlParser _parser;

        [SetUp]
        public void SetUp()
        {
            _parser = new XmlParser();
        }

        [Test]
        public void OneOpen()
        {
            var tokens = new Token[] {new OpeningBraketToken(), new TagNameToken("a"), new ClosingBraketToken()};
            var parsed = _parser.Parse(tokens).ToArray();
            Assert.AreEqual(1, parsed.Length);
            Assert.AreEqual(TagType.Opening, parsed[0].Type);
            Assert.AreEqual("a", parsed[0].Name);
        }

        [Test]
        public void OneOpenOneClose()
        {
            var tokens = new Token[]
                         {
                             new OpeningBraketToken(), new TagNameToken("a"), new ClosingBraketToken(),
                             new OpeningBraketToken(), new SlashToken(), new TagNameToken("a"), new ClosingBraketToken()
                         };
            var parsed = _parser.Parse(tokens).ToArray();
            Assert.AreEqual(2, parsed.Length);
            Assert.AreEqual(TagType.Opening, parsed[0].Type);
            Assert.AreEqual("a", parsed[0].Name);
            Assert.AreEqual(TagType.Closing, parsed[1].Type);
            Assert.AreEqual("a", parsed[1].Name);
        }

        [Test]
        public void InvalidTags()
        {
            var tokens = new Token[] {new OpeningBraketToken(), new ClosingBraketToken()};
            Assert.Throws<Exception>(() => _parser.Parse(tokens).ToArray());

            tokens = new Token[] { new ClosingBraketToken(), new OpeningBraketToken() };
            Assert.Throws<Exception>(() => _parser.Parse(tokens).ToArray());

            tokens = new Token[] { new OpeningBraketToken(), new SlashToken(), new ClosingBraketToken() };
            Assert.Throws<Exception>(() => _parser.Parse(tokens).ToArray());
        }
    }
}