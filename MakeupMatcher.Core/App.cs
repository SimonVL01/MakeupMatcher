using MvvmCross.Platform.IoC;
using MvvmCross.Platform;
using MvvmCross.Core.ViewModels;
using MakeupMatcher.Core.ViewModels;


namespace MakeupMatcher.Core
{
    public class App : MvxApplication
    {
        public App()
        {
            Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<UserViewModel>());
        }
    }
}
