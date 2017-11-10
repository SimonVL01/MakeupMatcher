
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;

namespace MakeupMatcher.UI.Droid.Views
{
    [Activity(Label = "SplashScreenView", MainLauncher = true, NoHistory = true)]
    public class SplashScreenView : MvxSplashScreenActivity
    {
        public SplashScreenView() : base(Resource.Layout.SplashScreen)
        {

        }
    }
}
