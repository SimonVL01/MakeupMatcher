using System;
using MvvmCross.Core.ViewModels;
using MakeupMatcher.Core.Models;
using MvvmCross.Platform;
using MakeupMatcher.Core.Enum;
using MvvmCross.Core.Navigation;

namespace MakeupMatcher.Core.ViewModels
{
    public class ProductViewModel : MvxViewModel
    {
        //readonly ProductModel _product;

        //Constructor

        private readonly IMvxNavigationService _navigationService;

        public ProductViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        //State

        int _productId;

        public int ProductId
        {
            get { return _productId; }
        }

        string _productName;

        public string ProductName
        {
            get { return _productName; }
            set
            {
                _productName = value;
                RaisePropertyChanged(() => ProductName);
            }
        }

        string _productBrand;

        public string ProductBrand
        {
            get { return ProductBrand; }
            set
            {
                _productBrand = value;
                RaisePropertyChanged(() => ProductBrand);
            }
        }

        double _productPrice;

        public double ProductPrice
        {
            get { return _productPrice; }
            set {
                _productPrice = value;
                RaisePropertyChanged(() => ProductPrice);
            }
        }

        bool _favorite;

        public bool Favorite
        {
            get { return _favorite; }
            set {
                _favorite = value;
                RaisePropertyChanged(() => Favorite);
            }
        }

        Colors _productColor;

        public Colors ProductColor 
        {
            get { return _productColor; }
            set
            {
                _productColor = value;
                RaisePropertyChanged(() => ProductColor);
            }
        }

        private IMvxAsyncCommand _goToProductDetailCommand;
        public IMvxAsyncCommand GoToProductDetailCommand
        {
            get
            {
                _goToProductDetailCommand = _goToProductDetailCommand ?? new MvxAsyncCommand(() => _navigationService.Navigate<ProductDetailViewModel, ProductParameters>(new ProductParameters() { Name = ProductName, Brand = ProductBrand }));
                return _goToProductDetailCommand;
            }
        }
    }
}