using System;
using MvvmCross.Core.ViewModels;
using MakeupMatcher.Core.Models;
using MvvmCross.Platform;
using MvvmCross.Core.Navigation;

namespace MakeupMatcher.Core.ViewModels
{

    public class FilterViewModel : MvxViewModel<BitmapParameters>
    {

        private readonly IMvxNavigationService _navigationService;

        public FilterViewModel(IMvxNavigationService navigationService) {
            _navigationService = navigationService;
        }

        byte[] _imageBytes;

        public byte[] ImageBytes
        {
            get { return _imageBytes; }
            set {
                _imageBytes = value;
            }
        }

        private IMvxAsyncCommand _goToMakeupCommand;
        public IMvxAsyncCommand GoToMakeupCommand
        {
            get
            {
                _goToMakeupCommand = _goToMakeupCommand ?? new MvxAsyncCommand(() => _navigationService.Navigate<MakeupViewModel>());
                return _goToMakeupCommand;
            }
        }

        public override void Prepare(BitmapParameters parameter)
        {
            _imageBytes = parameter.Image;
        }
    }
}