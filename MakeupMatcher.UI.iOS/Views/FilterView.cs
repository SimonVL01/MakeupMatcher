using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MakeupMatcher.Core.ViewModels;
using Airbnb.Lottie;
using MakeupMatcher.Core.Models;
using SQLite;
using MakeupMatcher.UI.iOS.iOSServices;
using UIKit;

namespace MakeupMatcher.UI.iOS.Views
{
    public partial class FilterView : MvxViewController
    {
        public FilterView() : base("FilterView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationItem.Title = "Apply Filter";

            int _xCoord = 5;
            int _yCoord = 5;
            int _buttonWidth = 70;
            int _buttonHeight = 70;
            int _gapBetweenButtons = 5;

            int _itemCount = 0;

            for (int i = 0; i < CoreImage.CIFilter.FilterNamesInCategory("KCICategoryColorAdjustment").Length; i++) {
                _itemCount = i;

                UIButton filterButton = new UIButton();
                filterButton.Frame = new CoreGraphics.CGRect(_xCoord, _yCoord, _buttonWidth, _buttonHeight);
                filterButton.Tag = _itemCount;
                //filterButton.AddTarget(Self, Action.CreateDelegate();

                //CoreImage.CIFilter filter = new CoreImage.CIFilter("");
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();


        }
    }
}

