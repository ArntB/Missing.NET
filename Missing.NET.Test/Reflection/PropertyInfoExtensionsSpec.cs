using Missing.Reflection;
using NUnit.Framework;

namespace Missing.NET.Test.Reflection
{
    [TestFixture]
    public class PropertyInfoExtensionsSpec
    {
        class PropTest
        {
            public string Test { set; get; }
        }
        [Test]
        public void It_should_get_property_value()
        {
            var obj = new PropTest{Test = "Some text"};
            Assert.AreEqual(obj.GetValue("Test"), obj.Test);
        }

        [Test]
        public void It_should_set_property_value()
        {
            var obj = new PropTest { Test = "Some text" };
            obj.SetValue1("Test", "Some other text");
            Assert.AreEqual(obj.Test, "Some other text");
        }

        [Test]
        public void It_should_get_anonymous_types_value()
        {
            var obj = new { Test = "Some text" };
            obj.GetValue("Test");
            Assert.AreEqual(obj.Test, "Some text");
        }
    }
}