using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MakeupMatcher.Core.ViewModels;
using Airbnb.Lottie;
using MakeupMatcher.Core.Models;
using SQLite;
using MakeupMatcher.UI.iOS.iOSServices;

using UIKit;
using CoreGraphics;
using Foundation;

namespace MakeupMatcher.UI.iOS.Views
{
    public partial class ProductView : MvxViewController<ProductViewModel>
    {
        public ProductView() : base("ProductView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationItem.Title = "Color results";
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

