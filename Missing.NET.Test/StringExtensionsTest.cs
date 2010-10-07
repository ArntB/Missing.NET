using NUnit.Framework;

namespace Missing.NET.Test
{
    [TestFixture]
    public class StringExtensionsTest
    {
        [Test]
        public void It_should_format_string()
        {
            Assert.AreEqual("Test 1 2", "Test {0} {1}".With(1,2));
            Assert.AreEqual("Jeps 3 4", "Jeps {0} {1}".With(3, 4));
        }
    }
}