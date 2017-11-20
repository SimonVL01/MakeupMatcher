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
        private Button b1, b2, b3, b4, b5, b6, b7;
        private Bitmap bmp;
        private Bitmap operation;
        private ImageView img;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Filter);

            b1 = FindViewById<Button>(Resource.Id.filter_1);
            b2 = FindViewById<Button>(Resource.Id.filter_2);
            b3 = FindViewById<Button>(Resource.Id.filter_3);
            b4 = FindViewById<Button>(Resource.Id.filter_4);
            b5 = FindViewById<Button>(Resource.Id.filter_5);
            b6 = FindViewById<Button>(Resource.Id.filter_6);
            b7 = FindViewById<Button>(Resource.Id.filter_7);

            img = FindViewById<ImageView>(Resource.Id.image_edit);

            //Apply images
            Bitmap originalImage = ((BitmapDrawable)img.Drawable).Bitmap;
            Bitmap imgResized = Bitmap.CreateScaledBitmap(originalImage, 70, 70, true);

            b1.Background = new BitmapDrawable(Resources, imgResized);
            b2.Background = new BitmapDrawable(Resources, imgResized);
            b3.Background = new BitmapDrawable(Resources, imgResized);
            b4.Background = new BitmapDrawable(Resources, imgResized);
            b5.Background = new BitmapDrawable(Resources, imgResized);
            b6.Background = new BitmapDrawable(Resources, imgResized);
            b7.Background = new BitmapDrawable(Resources, imgResized);
     
            BitmapDrawable abmp = (BitmapDrawable)img.Drawable;

            bmp = abmp.Bitmap;

        }

        public void gray(View view) {
            operation = Bitmap.CreateBitmap(bmp.Width, bmp.Height, bmp.GetConfig());
            double red = 0.33;
            double green = 0.59;
            double blue = 0.11;

            for (int i = 0; i < bmp.Width; i++) {
                for (int j = 0; j < bmp.Height; j++) {
                    int p = bmp.GetPixel(i, j);
                    int r = Color.GetRedComponent(p);
                    int g = Color.GetGreenComponent(p);
                    int b = Color.GetBlueComponent(p);
                    int a = Color.GetAlphaComponent(p);

                    r = (int)red * r;
                    g = (int)green * g;
                    b = (int)blue * b;
                    a = 1;
                    operation.SetPixel(i, j, Color.Argb(a, r, g, b));
                }
            }

            img.SetImageBitmap(operation);
        }

        public void bright(View view) {
            
        }

    }
}
