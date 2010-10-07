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
            Assert.AreEqual("Some text", obj.GetValue("Test"));
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
            Assert.AreEqual("Some text", obj.GetValue("Test"));
        }

        [Test]
        public void It_should_build_string_displaying_one_properies()
        {
            Assert.AreEqual("Test: Some thing",new {Test = "Some thing"}.ToPropertyString());
            Assert.AreEqual("Prop: text", new { Prop = "text" }.ToPropertyString());
        }
        [Test]
        public void It_should_build_string_displaying_two_properies()
        {
            Assert.AreEqual("T: 1\r\nP: 2", new { T = "1", P = 2 }.ToPropertyString());
        }

    }
}