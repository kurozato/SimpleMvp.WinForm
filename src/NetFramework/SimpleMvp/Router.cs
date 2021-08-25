using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackSugar.SimpleMvp
{
    /// <summary>
    /// 
    /// </summary>
    public class Router
    {
        /// <summary>
        /// 
        /// </summary>
        public static IDependencyResolver DependencyResolver { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dependencyResolver"></param>
        public static void Configure(IDependencyResolver dependencyResolver)
        {
            DependencyResolver = dependencyResolver;
        }

        private static IPresenter<TView> GetPresenter<TView>()
           where TView : class
        {
            var view = DependencyResolver.Resolve<TView>();
            var presenter = DependencyResolver.Resolve<IPresenter<TView>>();
            presenter.Set(view);
            presenter.Initialize();

            return presenter;
        }

        /// <summary>
        /// get view(initialized by presenter)
        /// </summary>
        /// <typeparam name="TView"></typeparam>
        /// <returns>view</returns>
        public static TView NavigateTo<TView>()
            where TView : class
        {
            return GetPresenter<TView>().GetView();
        }

        /// <summary>
        /// view show(initialized by presenter)
        /// </summary>
        /// <typeparam name="TView"></typeparam>
        /// <param name="modal"></param>
        /// <returns></returns>
        public static object NavigateTo<TView>(bool modal)
            where TView : class
        {
            return GetPresenter<TView>().Show(modal);
        }
    }
}
