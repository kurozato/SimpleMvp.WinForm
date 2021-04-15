using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackSugar.SimpleMvp.WinForm
{
    public interface IView
    {
        void ToFront();

        void Show();

        DialogResult ShowDialog();

        bool IsDisposed { get; }
    }

    public class ViewForm : Form, IView
    {
        public event EventHandler MoveUp;

        protected virtual void OnMoveUp(EventArgs e)
        {
            MoveUp?.Invoke(this, e);
        }

        public void ToFront()
        {
            if(!this.TopMost)
            {
                this.TopMost = true;
                this.TopMost = false;
                OnMoveUp(EventArgs.Empty);
            }
        }
    }
}
