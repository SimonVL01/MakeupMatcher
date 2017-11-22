// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace MakeupMatcher.UI.iOS.Views
{
    [Register ("ProductDetailView")]
    partial class ProductDetailView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel product_brand { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel product_name { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (product_brand != null) {
                product_brand.Dispose ();
                product_brand = null;
            }

            if (product_name != null) {
                product_name.Dispose ();
                product_name = null;
            }
        }
    }
}