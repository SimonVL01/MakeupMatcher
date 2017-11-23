using System;
using CoreGraphics;
using MakeupMatcher.Core.ViewModels;
using MvvmCross.iOS.Views;
using UIKit;

namespace MakeupMatcher.UI.iOS.Views
{
    public partial class ProductDetailView : UIViewController //<ProductDetailViewModel>
    {
        private string _productName;
        private string _productBrand;
        
        public ProductDetailView(string productName, string productBrand) : base("ProductDetailView", null)
        {
            _productName = productName;
            _productBrand = productBrand;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var navBar = new UINavigationBar(new CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, 120));
            View.AddSubview(navBar);
            var navItem = new UINavigationItem(_productName);
            var doneItem = new UIBarButtonItem(UIBarButtonSystemItem.Cancel, null);

            doneItem.Clicked += async (sender, e) => await DismissViewControllerAsync(true);

            navItem.LeftBarButtonItem = doneItem;
            navBar.SetItems(new UINavigationItem[] { navItem }, false);

            product_name.Font = UIFont.FromName("Helvetica", 30);
            product_name.Text = "Lorem Ipsum";
            product_name.Text = _productName;
            product_brand.Text = _productBrand;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

