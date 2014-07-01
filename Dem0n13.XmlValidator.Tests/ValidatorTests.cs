using System;
using System.Diagnostics;
using NUnit.Framework;

namespace Dem0n13.XmlValidator.Tests
{
    [TestFixture]
    public class ValidatorTests
    {
        private XmlValidator _validator;

        [SetUp]
        public void SetUp()
        {
            _validator = new XmlValidator();
        }

        [Test]
        public void OneOpenCloseTags()
        {
            var tags = new[] {new Tag("a", TagType.Opening), new Tag("a", TagType.Closing)};
            Assert.DoesNotThrow(() => _validator.Validate(tags));
        }

        [Test]
        public void InnerTags()
        {
            var tags = new[]
                       {
                           new Tag("a", TagType.Opening),
                           new Tag("b", TagType.Opening),
                           new Tag("b", TagType.Closing),
                           new Tag("a", TagType.Closing)
                       };
            Assert.DoesNotThrow(() => _validator.Validate(tags));
        }

        [Test]
        public void BadInnerTags()
        {
            var tags = new[]
                       {
                           new Tag("a", TagType.Opening),
                           new Tag("b", TagType.Opening),
                           new Tag("a", TagType.Closing),
                           new Tag("b", TagType.Closing)
                       };
            var ex = Assert.Throws<Exception>(() => _validator.Validate(tags));
            Debug.WriteLine(ex.Message);
        }

        [Test]
        public void BadCloseTag()
        {
            var tags = new[]
                       {
                           new Tag("a", TagType.Opening),
                           new Tag("b", TagType.Opening),
                           new Tag("b", TagType.Closing)
                       };
            var ex = Assert.Throws<Exception>(() => _validator.Validate(tags));
            Debug.WriteLine(ex.Message);
        }
    }
}