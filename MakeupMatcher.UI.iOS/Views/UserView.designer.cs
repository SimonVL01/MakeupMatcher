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
        UIKit.UIButton login { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField password { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton pic { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField username { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (login != null) {
                login.Dispose ();
                login = null;
            }

            if (password != null) {
                password.Dispose ();
                password = null;
            }

            if (pic != null) {
                pic.Dispose ();
                pic = null;
            }

            if (username != null) {
                username.Dispose ();
                username = null;
            }
        }
    }
}