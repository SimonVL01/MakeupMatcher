using System;
using MvvmCross.Core.ViewModels;
using MakeupMatcher.Core.Models;
using MvvmCross.Platform;

namespace MakeupMatcher.Core.ViewModels
{
    public class MakeupViewModel : MvxViewModel
    {
        readonly MakeupModel _makeupProfile;

        //Constructor

        public MakeupViewModel()
        {
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

        //Extra products
    }
}