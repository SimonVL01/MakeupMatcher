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
    [Activity(Label = "FilterView")]
    public class FilterView : MvxActivity<FilterViewModel>
    {
        private Bitmap bmp;
        private ImageView img;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Filter);

            img = FindViewById<ImageView>(Resource.Id.image_edit);
            BitmapDrawable abmp = (BitmapDrawable)img.Drawable;

            bmp = abmp.Bitmap;

            for (int i = 0; i < bmp.Width; i++) {
                for (int j = 0; j < bmp.Height; j++) {
                    int p = bmp.GetPixel(i, j);
                }
            }
        }
    }
}
