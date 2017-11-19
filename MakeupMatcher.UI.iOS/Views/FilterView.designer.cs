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
    [Register ("FilterView")]
    partial class FilterView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView image { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton imageButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIScrollView scrollview { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (image != null) {
                image.Dispose ();
                image = null;
            }

            if (imageButton != null) {
                imageButton.Dispose ();
                imageButton = null;
            }

            if (scrollview != null) {
                scrollview.Dispose ();
                scrollview = null;
            }
        }
    }
}