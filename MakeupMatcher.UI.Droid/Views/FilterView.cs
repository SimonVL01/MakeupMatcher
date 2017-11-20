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
        //private Bitmap operation;
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
            Bitmap imgResizedForEditing = Bitmap.CreateScaledBitmap(originalImage, 500, 500, true);

            b1.Background = new BitmapDrawable(Resources, ApplySepiaToningEffect(imgResized, 5, 20, 10, 0));
            b2.Background = new BitmapDrawable(Resources, ApplyGammaEffect(imgResized, 4.5, 1.75, 3.25));
            b3.Background = new BitmapDrawable(Resources, ApplyGammaEffect(imgResized, 2, 4.25, 3.25));
            b4.Background = new BitmapDrawable(Resources, ApplyContrastEffect(imgResized, 0.3));
            b5.Background = new BitmapDrawable(Resources, ApplyColorFilterEffect(imgResized, 0.9, 0.9, 0.0));
            b6.Background = new BitmapDrawable(Resources, ApplyBrightnessEffect(imgResized, -45));
            b7.Background = new BitmapDrawable(Resources, ApplyBrightnessEffect(imgResized, 75));

            BitmapDrawable abmp = (BitmapDrawable)img.Drawable;

            bmp = abmp.Bitmap;

            b1.Click += (sender, e) => img.SetImageBitmap(ApplySepiaToningEffect(imgResizedForEditing, 5, 20, 10, 0));
            b2.Click += (sender, e) => img.SetImageBitmap(ApplyGammaEffect(imgResizedForEditing, 4.5, 1.75, 3.25));
            b3.Click += (sender, e) => img.SetImageBitmap(ApplyGammaEffect(imgResizedForEditing, 2, 4.25, 3.25));
            b4.Click += (sender, e) => img.SetImageBitmap(ApplyContrastEffect(imgResizedForEditing, 0.3));
            b5.Click += (sender, e) => img.SetImageBitmap(ApplyColorFilterEffect(imgResizedForEditing, 0.9, 0.9, 0.0));
            b6.Click += (sender, e) => img.SetImageBitmap(ApplyBrightnessEffect(imgResizedForEditing, -45));
            b7.Click += (sender, e) => img.SetImageBitmap(ApplyBrightnessEffect(imgResizedForEditing, 75));

            //img.SetImageBitmap(Blue(bmp));

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.FilterMenu, menu);
            return base.OnPrepareOptionsMenu(menu);

        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.save:
                    SavePicture();
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        public Bitmap Bright(Bitmap bm)
        {
            Bitmap _operation = Bitmap.CreateBitmap(bm.Width, bm.Height, bm.GetConfig());
            //operation = Bitmap.CreateBitmap(bm.Width, bm.Height, bm.GetConfig());

            for (int i = 0; i < bm.Width; i++)
            {
                for (int j = 0; j < bm.Height; j++)
                {
                    int p = bm.GetPixel(i, j);
                    int r = (Color.GetRedComponent(p) + 100) / 255;
                    int g = (Color.GetGreenComponent(p) + 100) / 255;
                    int b = (Color.GetBlueComponent(p) + 100) / 255;
                    int a = Color.GetAlphaComponent(p);

                    //r = 25 + r;
                    //g = 20 + g;
                    //b = 10 + b;
                    //a = 10 + a;
                    _operation.SetPixel(i, j, Color.Argb(a, r, g, b));
                }
            }
            //img.SetImageBitmap(operation);
            return _operation;
        }


        public Bitmap ApplyContrastEffect(Bitmap _src, double value)
        {
            int width = _src.Width;
            int height = _src.Height;

            Bitmap bmOut = Bitmap.CreateBitmap(width, height, _src.GetConfig());

            int A, R, G, B;
            int pixel;

            double contrast = Math.Pow((100 + value) / 100, 2);

            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    pixel = _src.GetPixel(x, y);

                    A = Color.GetAlphaComponent(pixel);
                    R = Color.GetRedComponent(pixel);
                    R = (int)(((((R / 255.0) - 0.5) * contrast) + 0.5) * 255.0);
                    if (R < 0) { R = 0; }
                    else if (R > 255) { R = 255; }

                    G = Color.GetBlueComponent(pixel);
                    G = (int)(((((G / 255.0) - 0.5) * contrast) + 0.5) * 255.0);
                    if (G < 0) { G = 0; }
                    else if (G > 255) { G = 255; }

                    B = Color.GetBlueComponent(pixel);
                    B = (int)(((((B / 255.0) - 0.5) * contrast) + 0.5) * 255.0);
                    if (B > 255) { B = 0; }
                    else if (B > 255) { B = 255; }

                    bmOut.SetPixel(x, y, Color.Argb(A, R, G, B));
                }
            }

            return bmOut;
        }

        public Bitmap ApplyGammaEffect(Bitmap _src, double red, double green, double blue)
        {
            Bitmap bmOut = Bitmap.CreateBitmap(_src.Width, _src.Height, _src.GetConfig());

            int width = _src.Width;
            int height = _src.Height;
            int A, R, G, B;
            int pixel;

            const int MAX_SIZE = 256;
            const double MAX_VALUE_DBL = 255.0;
            const int MAX_VALUE_INT = 255;
            const double REVERSE = 1.0;

            int[] gammaR = new int[MAX_SIZE];
            int[] gammaG = new int[MAX_SIZE];
            int[] gammaB = new int[MAX_SIZE];

            for (int i = 0; i < MAX_SIZE; ++i)
            {
                gammaR[i] = (int)Math.Min(MAX_VALUE_INT, (int)((MAX_VALUE_DBL * Math.Pow(i / MAX_VALUE_DBL, REVERSE / red)) + 0.5));
                gammaG[i] = (int)Math.Min(MAX_VALUE_INT, (int)((MAX_VALUE_DBL * Math.Pow(i / MAX_VALUE_DBL, REVERSE / green)) + 0.5));
                gammaB[i] = (int)Math.Min(MAX_VALUE_INT, (int)((MAX_VALUE_DBL * Math.Pow(i / MAX_VALUE_DBL, REVERSE / blue)) + 0.5));
            }

            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    pixel = _src.GetPixel(x, y);
                    A = Color.GetAlphaComponent(pixel);

                    R = gammaR[Color.GetRedComponent(pixel)];
                    G = gammaG[Color.GetGreenComponent(pixel)];
                    B = gammaB[Color.GetBlueComponent(pixel)];

                    bmOut.SetPixel(x, y, Color.Argb(A, R, G, B));
                }
            }

            return bmOut;
        }

        public Bitmap ApplyColorFilterEffect(Bitmap _src, double red, double green, double blue)
        {
            int width = _src.Width;
            int height = _src.Height;

            Bitmap bmOut = Bitmap.CreateBitmap(width, height, _src.GetConfig());
            int A, R, G, B;
            int pixel;

            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    pixel = _src.GetPixel(x, y);

                    A = Color.GetAlphaComponent(pixel);
                    R = (int)(Color.GetRedComponent(pixel) * red);
                    G = (int)(Color.GetGreenComponent(pixel) * green);
                    B = (int)(Color.GetBlueComponent(pixel) * blue);

                    bmOut.SetPixel(x, y, Color.Argb(A, R, G, B));
                }
            }

            return bmOut;
        }

        public Bitmap ApplySepiaToningEffect(Bitmap _src, int depth, double red, double green, double blue)
        {
            int width = _src.Width;
            int height = _src.Height;

            Bitmap bmOut = Bitmap.CreateBitmap(width, height, _src.GetConfig());

            const double GS_RED = 0.3;
            const double GS_GREEN = 0.59;
            const double GS_BLUE = 0.11;

            int A, R, G, B;
            int pixel;

            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    pixel = _src.GetPixel(x, y);

                    A = Color.GetAlphaComponent(pixel);
                    R = Color.GetRedComponent(pixel);
                    G = Color.GetGreenComponent(pixel);
                    B = Color.GetBlueComponent(pixel);

                    B = G = R = (int)(GS_RED * R + GS_GREEN * G + GS_BLUE * B);

                    R += (depth * (int)red);
                    if (R > 255) { R = 255; }

                    G += (depth * (int)green);
                    if (G > 255) { G = 255; }

                    B += (depth * (int)blue);
                    if (B > 255) { B = 255; }

                    bmOut.SetPixel(x, y, Color.Argb(A, R, G, B));
                }
            }

            return bmOut;
        }

        public Bitmap ApplySaturationFilter(Bitmap _src, int level)
        {
            int width = _src.Width;
            int height = _src.Height;
            int[] pixels = new int[width * height];
            float[] HSV = new float[3];
            _src.GetPixels(pixels, 0, width, 0, 0, width, height);

            int index = 0;

            for (int y = 0; y < height; ++y)
            {
                for (int x = 0; x < width; ++x)
                {
                    index = y * width + x;

                    Color.ColorToHSV(new Android.Graphics.Color(pixels[index]), HSV);

                    HSV[1] *= level;
                    HSV[1] = (float)Math.Max(0.0, Math.Min(HSV[1], 1.0));

                    pixels[index] |= Color.HSVToColor(HSV);
                }
            }

            Bitmap bmOut = Bitmap.CreateBitmap(width, height, Bitmap.Config.Argb8888);
            bmOut.SetPixels(pixels, 0, width, 0, 0, width, height);
            return bmOut;
        }

        public Bitmap ApplyHueFilter(Bitmap _src, int level)
        {
            int width = _src.Width;
            int height = _src.Height;
            int[] pixels = new int[width * height];
            float[] HSV = new float[3];

            _src.GetPixels(pixels, 0, width, 0, 0, width, height);

            int index = 0;

            for (int y = 0; y < height; ++y)
            {
                for (int x = 0; x < width; ++x)
                {
                    Color.ColorToHSV(new Android.Graphics.Color(pixels[index]), HSV);

                    HSV[0] *= level;
                    HSV[0] = (float)Math.Max(0.0, Math.Min(HSV[0], 360.0));
                    pixels[index] |= Color.HSVToColor(HSV);
                }
            }

            Bitmap bmOut = Bitmap.CreateBitmap(width, height, Bitmap.Config.Argb8888);
            bmOut.SetPixels(pixels, 0, width, 0, 0, width, height);
            return bmOut;
        }

        public Bitmap ApplyBrightnessEffect(Bitmap _src, int value)
        {
            int width = _src.Width;
            int height = _src.Height;

            Bitmap bmOut = Bitmap.CreateBitmap(width, height, _src.GetConfig());

            int A, R, G, B;
            int pixel;

            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    pixel = _src.GetPixel(x, y);
                    A = Color.GetAlphaComponent(pixel);
                    R = Color.GetRedComponent(pixel);
                    G = Color.GetGreenComponent(pixel);
                    B = Color.GetBlueComponent(pixel);

                    R += value;
                    if (R > 255) { R = 255; }
                    else if (R < 0) { R = 0; }

                    G += value;
                    if (G > 255) { G = 255; }
                    else if (G < 0) { G = 0; }

                    B += value;
                    if (B > 255) { B = 255; }
                    else if (B < 0) { B = 0; }

                    bmOut.SetPixel(x, y, Color.Argb(A, R, G, B));
                }
            }

            return bmOut;
        }

        public async void SavePicture() {
            await ViewModel.GoToMakeupCommand.ExecuteAsync();
        }

    }
}