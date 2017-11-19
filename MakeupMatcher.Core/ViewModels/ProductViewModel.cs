using System;
using MvvmCross.Core.ViewModels;
using MakeupMatcher.Core.Models;
using MvvmCross.Platform;

namespace MakeupMatcher.Core.ViewModels
{
    public class ProductViewModel : MvxViewModel
    {
        readonly ProductModel _product;

        //Constructor

        public ProductViewModel()
        {
            _product = Mvx.IocConstruct<ProductModel>();
        }

        //State

        int _productId;

        public int ProductId
        {
            get { return _product.ProductId; }
        }

        string _productName;

        public string ProductName
        {
            get { return _product.ProductName; }
            set
            {
                _productName = value;
                _product.ProductName = value;
                RaisePropertyChanged(() => _productName);
            }
        }

        string _productBrand;

        public string ProductBrand
        {
            get { return _product.ProductBrand; }
            set
            {
                _productBrand = value;
                _product.ProductBrand = value;
                RaisePropertyChanged(() => _productBrand);
            }
        }

        double _productPrice;

        public double ProductPrice
        {
            get { return _product.ProductPrice; }
            set {
                _productPrice = value;
                _product.ProductPrice = value;
                RaisePropertyChanged(() => _productPrice);
            }
        }

        bool _favorite;

        public bool Favorite
        {
            get { return _product.Favorite; }
            set {
                _favorite = value;
                _product.Favorite = value;
                RaisePropertyChanged(() => _favorite);
            }
        }
    }
}