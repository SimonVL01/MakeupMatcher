using System;

using UIKit;

namespace MakeupMatcher.UI.iOS.Views
{
    public partial class ProductDetailView : UIViewController
    {
        public ProductDetailView() : base("ProductDetailView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            product_name.Font.WithSize(36);
            product_name.Text = "Lorem Ipsum";
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

