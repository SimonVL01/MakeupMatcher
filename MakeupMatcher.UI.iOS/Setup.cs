using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Core.ViewModels;
using MakeupMatcher.Core;
using MvvmCross.Platform.Logging;

namespace MakeupMatcher.UI.iOS
{
    public class Setup: MvxIosSetup
    {
        public Setup(MvxApplicationDelegate appDelegate, IMvxIosViewPresenter presenter)
            : base(appDelegate, presenter)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override MvxLogProviderType GetDefaultLogProviderType() =>
         MvxLogProviderType.None;

    }
}