using System.Windows.Forms;

namespace System
{
    internal class MouseEventHandler
    {
        private Action<object, MouseEventArgs> groupBox2_Enter;

        public MouseEventHandler(Action<object, MouseEventArgs> groupBox2_Enter)
        {
            this.groupBox2_Enter = groupBox2_Enter;
        }
    }
}