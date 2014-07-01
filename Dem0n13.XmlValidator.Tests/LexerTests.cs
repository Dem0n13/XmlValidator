using System.Linq;
using NUnit.Framework;

namespace Dem0n13.XmlValidator.Tests
{
    [TestFixture]
    public class LexerTests
    {
        private XmlLexer _lexer;

        [SetUp]
        public void SetUp()
        {
            _lexer = new XmlLexer();
        }

        [Test]
        public void Normal()
        {
            const string input = "<a></a><b>";
            var tokens = _lexer.Tokenize(input);
            Assert.AreEqual(10, tokens.Count());
        }

        [Test]
        public void Whitespace()
        {
            const string input = "   < a ></ a> < b  >   ";
            var tokens = _lexer.Tokenize(input);
            Assert.AreEqual(10, tokens.Count());
        }
    }
}