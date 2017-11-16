using System;
using MvvmCross.Core.ViewModels;
using MakeupMatcher.Core.Models;
using MvvmCross.Platform;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;

namespace MakeupMatcher.Core.ViewModels
{
    public class MakeupViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        readonly MakeupModel _makeupProfile;

        //Constructor

        public MakeupViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            _makeupProfile = Mvx.IocConstruct<MakeupModel>();
        }

        //State

        int _colorId;

        public int ColorId
        {
            get { return _makeupProfile.ColorId; }
        }

        string _colorName;

        public string ColorName
        {
            get { return _makeupProfile.ColorName; }
            set
            {
                _colorName = value;
                _makeupProfile.ColorName = value;;
                RaisePropertyChanged(() => ColorName);
            }
        }

        ProductModel[] _products;

        public ProductModel[] Products
        {
            get { return _makeupProfile.Products; }
            set
            {
                _products = value;
                _makeupProfile.Products = value;
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

        /*public override async Task Initialize()
        {
            //
        }*/

    }
}