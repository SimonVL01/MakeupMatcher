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
    [Register ("UserView")]
    partial class UserView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField data { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel info { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton nextPage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton show { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton store { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (data != null) {
                data.Dispose ();
                data = null;
            }

            if (info != null) {
                info.Dispose ();
                info = null;
            }

            if (nextPage != null) {
                nextPage.Dispose ();
                nextPage = null;
            }

            if (show != null) {
                show.Dispose ();
                show = null;
            }

            if (store != null) {
                store.Dispose ();
                store = null;
            }
        }
    }
}