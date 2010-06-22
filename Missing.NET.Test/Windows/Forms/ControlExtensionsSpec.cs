using System.Threading;
using System.Windows.Forms;
using Missing.Windows.Forms;
using NUnit.Framework;

namespace Missing.NET.Test.Windows.Forms
{
    [TestFixture]
    public class ControlExtensionsSpec
    {
        
        [Test]
        public void It_should_do_invoke_if_invoke_required()
        {
            // Don't know how to test this.
        }

        [Test]
        public void It_should_add_control_to_control()
        {
            Form f = new Form();
            var tb = new TextBox();
            f.AddControl(tb);
            Assert.Contains(tb,f.Controls);
        }

        [Test]
        public void It_should_add_control_with_docstyle()
        {
            Form f = new Form();
            var tb = new TextBox();
            f.AddControl(tb,DockStyle.Fill);
            Assert.Contains(tb, f.Controls);
            Assert.AreEqual(DockStyle.Fill,tb.Dock);
        }

        [Test]
        public void It_should_clear_control()
        {
            Form f = new Form();
            var tb = new TextBox();
            f.AddControl(tb);
            f.Clear();
            Assert.IsEmpty(f.Controls);
        }
    }
}
