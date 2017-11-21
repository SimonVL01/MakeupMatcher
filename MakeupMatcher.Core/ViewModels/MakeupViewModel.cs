using System;
using MvvmCross.Core.ViewModels;
using MakeupMatcher.Core.Models;
using MvvmCross.Platform;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MakeupMatcher.Core.Enum;

namespace MakeupMatcher.Core.ViewModels
{
    public class MakeupViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        //readonly MakeupModel _makeupProfile;

        //Constructor

        public MakeupViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            //_makeupProfile = 
            Mvx.IocConstruct<MakeupModel>();
        }

        //State

        int _colorId;

        public int ColorId
        {
            get { return _colorId; }
        }

        Colors _colorName;

        public Colors ColorName
        {
            get { return _colorName; }
            set
            {
                _colorName = value;
                RaisePropertyChanged(() => ColorName);
            }
        }

        ProductModel[] _products;

        public ProductModel[] Products
        {
            get { return _products; }
            set
            {
                _products = value;
                RaisePropertyChanged(() => Products);
            }
        }

        //Navigation Service

        public override void Prepare()
        {
        }

        private IMvxAsyncCommand _goToFilterCommand;
        public IMvxAsyncCommand GoToFilterCommand
        {
            get
            {
                _goToFilterCommand = _goToFilterCommand ?? new MvxAsyncCommand(() => _navigationService.Navigate<FilterViewModel>());
                return _goToFilterCommand;
            }
        }

        private IMvxAsyncCommand _goToProductCommand;
        public IMvxAsyncCommand GoToProductCommand
        {
            get
            {
                _goToProductCommand = _goToProductCommand ?? new MvxAsyncCommand(() => _navigationService.Navigate<ProductViewModel>());
                return _goToProductCommand;
            }
        }
    }
}