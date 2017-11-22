using System;
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

            product_name.Font.WithSize(36);
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

