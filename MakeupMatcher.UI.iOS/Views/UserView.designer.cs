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
        UIKit.UIButton storedata { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (storedata != null) {
                storedata.Dispose ();
                storedata = null;
            }
        }
    }
}