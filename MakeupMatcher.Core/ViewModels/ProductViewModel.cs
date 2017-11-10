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
    }
}