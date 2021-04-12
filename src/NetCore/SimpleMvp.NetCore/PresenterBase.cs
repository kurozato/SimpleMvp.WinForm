using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackSugar.SimpleMvp.WinForm
{
    /// <summary>
    /// this is for WinFroms.
    /// </summary>
    /// <typeparam name="TView"></typeparam>
    public class PresenterBase<TView> : IPresenter<TView>, IDisposable
          where TView : class
    {
        protected TView _view;

        protected bool initialize = false;

        public virtual TView GetView()
        {
            return _view;
        }

        public virtual void Initialize()
        {
            if (initialize)
            {
                InitializeView();
                initialize = false;
            }
        }

        protected virtual void InitializeView()
        {

        }

        private bool? IsDisposed(TView view)
        {
            var form = view as Form;
            return form?.IsDisposed;
        }

        public virtual void Set(TView view)
        {
            if (_view == null || IsDisposed(_view) == true)
            {
                _view = view;
                initialize = true;
            }
        }

        public virtual object Show(bool modal)
        {
            return null;
        }

        #region IDisposable Support
        private bool disposedValue = false; // 重複する呼び出しを検出するには

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    var form = _view as Form;
                    if (form != null)
                    {
                        form.Dispose();
                        form = null;
                        _view = null;
                    }
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion

    }
}
