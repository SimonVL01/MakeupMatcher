using System;
using System.Windows.Input;
using MvvmCross.Platform;
using MvvmCross.Core.ViewModels;

namespace MakeupMatcher.Core.ViewModels
{
    public class SplashScreenViewModel : MvxViewModel
    {
        public ICommand GoCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<UserViewModel>());
            }
        }
    }
}