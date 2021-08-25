# SimpleMvp.WinForm
Model-View-Presenter (Passive View) for WinForm.  
View:Presnenter = 1:1  

made for views transition.  
use NavigateTo method for views transition.

## How to use

### Quick Start
```cs
//Register interface
var container = new SomethingContainer();
container.Register<IService, Service>();
container.Register<IView, Form>();
container.Register<IPresenter<IView>, Presenter>();

//DependencyResolver (container wrapper)
var resolver = new DependencyResolver();
resolver.Set(container);

// Set DependencyResolver
Router.Configure(resolver);

//Get View (initialized by presenter)
var view = Router.NavigateTo<IView>();

//Show View (initialized by presenter) and return result
var result = Router.NavigateTo<IView>(true);
```

### Make DependencyResolver
```cs
public class DependencyResolver : IDependencyResolver
{
    private SomethingContainer container;

    public object ContainerObject => container;

    public TService Resolve<TService>()
        where TService : class
    {
        return container.Resolve<TService>();
    }

    public object Resolve(Type serviceType)
    {
        return container.Resolve(serviceType);
    }

    public void Set(SomethingContainer container)
    {
        this.container = container;
    }
}
```
### Make Presenter
```cs
public class Presenter : PresenterBase<IView>
{
    protected IService _service;

    public Presenter(IService service)
    {
        _service = service;
    }

    protected override void InitializeView()
    {
        _view.Model = _service.Get();
    }

    public override object Show(bool modal)
    {
        if(modal)
            _view.ShowDialog();
        else
            _view.Show();
    
        return _view.ResultObject;
    }
}
```
### How set the transition parameters
container register singleton custom class.

## Japanese
Windowsフォームアプリ向けのModel-View-Presenterフレームワーク  
(そんな大層なもんじゃないけど)  
- View : Presnenter = 1 : 1  
- Passive View

画面遷移を実装しているものが見当たらなかったので、作成。  
