using System;
using System.Windows.Forms;

namespace Missing.Windows.Forms
{
    public static class ControlExtensions
    {
        public static void Disable(this Control self)
        {
            self.SetEnabled(false);
        }

        public static void Enable(this Control self)
        {
            self.SetEnabled(true);
        }

        static void  SetEnabled(this Control self, bool status)
        {
            self.RunThreadSafe(() => self.Enabled = status );
        }

        public static void RunThreadSafe(this Control self,Action action)
        {
            if (self.InvokeRequired)
            {
                self.Invoke(new Action<Control,Action>(RunThreadSafe),
                            new object[] {self,action });
            }
            else
            {
                action();
            }
        }

        public static void AddControl(this Control self, Control control, DockStyle dockStyle)
        {
            control.Dock = dockStyle;
            self.AddControl(control);
        }

        public static void AddControl(this Control self, Control control)
        {
            self.Controls.Add(control);
        }

        public static void Clear(this Control self)
        {
            self.Controls.Clear();
        }
    }
}