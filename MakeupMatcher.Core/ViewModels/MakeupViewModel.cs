using System;
using MvvmCross.Core.ViewModels;

namespace MakeupMatcher.Core.ViewModels
{
    public class MakeupViewModel : MvxViewModel
    {
        //Constructor

        public MakeupViewModel()
        {
        }

        //State

        int _colorId;

        public int ColorId
        {
            get { return _colorId; }
        }

        string _colorName;

        public string ColorName
        {
            get { return _colorName; }
            set
            {
                _colorName = value;
                RaisePropertyChanged(() => ColorName);
            }
        }

        //Extra products
    }
}