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
    [Register ("ProductView")]
    partial class ProductView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel brand { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel product { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (brand != null) {
                brand.Dispose ();
                brand = null;
            }

            if (product != null) {
                product.Dispose ();
                product = null;
            }
        }
    }
}