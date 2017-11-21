using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MakeupMatcher.Core.ViewModels;
using Airbnb.Lottie;
using MakeupMatcher.Core.Models;
using SQLite;
using MakeupMatcher.UI.iOS.iOSServices;
using UIKit;
using CoreImage;
using Foundation;
using CoreGraphics;
using System.Collections.Generic;

namespace MakeupMatcher.UI.iOS.Views
{
    public partial class ProductView : MvxViewController<ProductViewModel>
    {
        private List<ProductModel> _productList;

        public ProductView() : base("ProductView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationItem.Title = "ColorMatch results";
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

