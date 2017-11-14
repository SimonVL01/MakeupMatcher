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
    [Register ("MakeupView")]
    partial class MakeupView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton camera { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton filter { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton library { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (camera != null) {
                camera.Dispose ();
                camera = null;
            }

            if (filter != null) {
                filter.Dispose ();
                filter = null;
            }

            if (imageView != null) {
                imageView.Dispose ();
                imageView = null;
            }

            if (library != null) {
                library.Dispose ();
                library = null;
            }
        }
    }
}