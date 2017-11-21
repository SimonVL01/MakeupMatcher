// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace MakeupMatcher.UI.iOS.iOSServices
{
    [Register ("ProductViewCell")]
    partial class ProductViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView product_image { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel subText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel title { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (product_image != null) {
                product_image.Dispose ();
                product_image = null;
            }

            if (subText != null) {
                subText.Dispose ();
                subText = null;
            }

            if (title != null) {
                title.Dispose ();
                title = null;
            }
        }
    }
}