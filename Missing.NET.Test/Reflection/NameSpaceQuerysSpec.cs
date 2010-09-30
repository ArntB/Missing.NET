using NUnit.Framework;
using Missing.Reflection;

namespace Missing.NET.Test.Reflection
{
    [TestFixture]
    public class NameSpaceQuerysSpec
    {
        [Test]
        public void It_should_find_types_in_nampespace()
        {
            var types = GetType().Assembly.GetTypesInNamespace("Missing.NET.Test.Reflection");
            Assert.Contains(GetType(), types);
        }
    }
}
