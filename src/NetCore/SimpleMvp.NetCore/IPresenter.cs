using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackSugar.SimpleMvp
{
    /// <summary>
    /// this is for method "NavigateTo".
    /// </summary>
    /// <typeparam name="TView"></typeparam>
    public interface IPresenter<TView> where TView : class
    {
        TView GetView();

        void Set(TView view);

        void Initialize();

        object Show(bool modal);
    }
}
