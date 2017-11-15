using System;
using MvvmCross.Core.ViewModels;
using MakeupMatcher.Core.Models;
using MvvmCross.Platform;
using MvvmCross.Core.Navigation;

namespace MakeupMatcher.Core.ViewModels
{

    public class FilterViewModel : MvxViewModel
    {

        private readonly IMvxNavigationService _navigationService;

        /*{
            get
            {
                _goToMakeupCommand = _goToMakeupCommand ?? new MvxAsyncCommand(() => _navigationService.Navigate<MakeupViewModel>());
                return _goToMakeupCommand;
            }
        }*/

        public FilterViewModel(IMvxNavigationService navigationService) {
            _navigationService = navigationService;
        }
    }
}