using System;
using MvvmCross.Core.ViewModels;

namespace MakeupMatcher.Core.ViewModels
{
    public class ProductViewModel : MvxViewModel
    {
        //Constructor

        public ProductViewModel()
        {
        }

        //State

        int _productId;

        public int ProductId
        {
            get { return _productId; }
            set
            {
                _productId = value;
                RaisePropertyChanged(() => _productId);
            }
        }

        string _productName;

        public string ProductName
        {
            get { return _productName; }
            set
            {
                _productName = value;
                RaisePropertyChanged(() => _productName);
            }
        }
    }
}