using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackSugar.SimpleMvp.WinForm
{
    public class Presenter<TView> : PresenterBase<TView>
        where TView : class
    {
        protected bool shown;

        public override void Initialize()
        {
            shown = !initialize;
            base.Initialize();
        }

        public override object Show(bool modal)
        {
            var view = _view as IView;
            if (shown)
                view?.ToFront();
            else
            {
                shown = true;
                if (modal)
                    return view?.ShowDialog();
                else
                    view?.Show();
            }
            return null;
        }

        protected new bool? IsDisposed(TView view)
        {
            var form = view as IView;
            return form?.IsDisposed;
        }
    }
}
