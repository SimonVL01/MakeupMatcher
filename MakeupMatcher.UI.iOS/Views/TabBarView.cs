using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MakeupMatcher.Core.ViewModels;
using Airbnb.Lottie;
using MakeupMatcher.Core.Models;
using SQLite;
using MakeupMatcher.UI.iOS.iOSServices;

using UIKit;
using CoreGraphics;
using Foundation;

namespace MakeupMatcher.UI.iOS.Views
{
    public partial class TabBarView : MvxTabBarViewController
    {
        private MvxViewController tabLib, tabCam, tabFil;

        public TabBarView() : base()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            tabLib = new MakeupView();
            tabLib.Title = "Green";
            tabLib.View.BackgroundColor = UIColor.Green;
            tabCam = new MakeupView();
            tabLib.Title = "Orange";
            tabLib.View.BackgroundColor = UIColor.Orange;
            tabFil = new MakeupView();
            tabFil.Title = "Red";
            tabFil.View.BackgroundColor = UIColor.Red;

            var tabs = new MvxViewController[] {
                tabLib, tabCam, tabFil
            };
            ViewControllers = tabs;

            SelectedViewController = tabFil;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

