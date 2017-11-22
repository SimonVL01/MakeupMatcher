
using System;
//using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MakeupMatcher.Core.Repositories;
using MakeupMatcher.Core.Models;

using Android.App;
using Java.IO;
using Android.Graphics;
using Com.Airbnb.Lottie;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;
//using SQLite.Net;
//using SQLite.Net.Platform.XamarinAndroid;
using MakeupMatcher.Core.ViewModels;
using MakeupMatcher.UI.Droid.DroidServices;
using SQLite;
using Android.Provider;
using Android.Content.PM;
using Android.Graphics.Drawables;


namespace MakeupMatcher.UI.Droid.Views
{
    [Activity(Label = "ProductDetailView")]
    public class ProductDetailView : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ProductDetail);

            TextView title = FindViewById<TextView>(Resource.Id.product_name);
            TextView subText = FindViewById<TextView>(Resource.Id.product_brand);

            title.Text = Intent.GetStringExtra("Name") ?? "Oops!";
            subText.Text = Intent.GetStringExtra("Brand") ?? "We couldn't find your product," +
                                   " try again later.";
        }
    }
}
