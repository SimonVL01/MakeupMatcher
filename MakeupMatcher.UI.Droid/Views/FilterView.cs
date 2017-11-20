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

            b1.Background = new BitmapDrawable(Resources, ApplyInvertEffect(imgResized));
            b2.Background = new BitmapDrawable(Resources, ApplyGammaEffect(imgResized, 4.5, 1.75, 3.25));
            b3.Background = new BitmapDrawable(Resources, ApplySaturationFilter(imgResized, 7));
            b4.Background = new BitmapDrawable(Resources, ApplyHueFilter(imgResized, 75));
            b5.Background = new BitmapDrawable(Resources,ApplyColorFilterEffect(imgResized, 0.9, 0.9, 0.0));
            b6.Background = new BitmapDrawable(Resources, Blue(imgResized));
            b7.Background = new BitmapDrawable(Resources, Warm(imgResized));
     
            BitmapDrawable abmp = (BitmapDrawable)img.Drawable;

            bmp = abmp.Bitmap;

            b1.Click += (sender, e) => img.SetImageBitmap(ApplyInvertEffect(imgResizedForEditing));
            b2.Click += (sender, e) => img.SetImageBitmap(ApplyGammaEffect(imgResizedForEditing, 4.5, 1.75, 3.25));
            b3.Click += (sender, e) => img.SetImageBitmap(ApplySaturationFilter(imgResizedForEditing, 7));
            b4.Click += (sender, e) => img.SetImageBitmap(ApplyHueFilter(imgResizedForEditing, 75));
            b5.Click += (sender, e) => img.SetImageBitmap(ApplyColorFilterEffect(imgResizedForEditing, 0.9, 0.9, 0.0));
            b6.Click += (sender, e) => img.SetImageBitmap(Blue(imgResizedForEditing));
            b7.Click += (sender, e) => img.SetImageBitmap(Warm(imgResizedForEditing));

            //img.SetImageBitmap(Blue(bmp));

        }

        public Bitmap Bright(Bitmap bm) {
            Bitmap _operation = Bitmap.CreateBitmap(bm.Width, bm.Height, bm.GetConfig());
            //operation = Bitmap.CreateBitmap(bm.Width, bm.Height, bm.GetConfig());

            for (int i = 0; i < bm.Width; i++) {
                for (int j = 0; j < bm.Height; j++) {
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

        public Bitmap Dark(Bitmap bm)
        {
            Bitmap _operation = Bitmap.CreateBitmap(bm.Width, bm.Height, bm.GetConfig());

            for (int i = 0; i < bm.Width; i++)
            {
                for (int j = 0; j < bm.Height; j++)
                {
                    int p = bm.GetPixel(i, j);
                    int r = Color.GetRedComponent(p);
                    int g = Color.GetGreenComponent(p);
                    int b = Color.GetBlueComponent(p);
                    int a = Color.GetAlphaComponent(p);

                    r = r - 5;
                    g = g - 20;
                    //b = b - 25;
                    //a = a;
                    _operation.SetPixel(i, j, Color.Argb(a, r, g, b));
                }
            }
            //img.SetImageBitmap(operation);
            return _operation;
        }

        public Bitmap Gamma(Bitmap bm) {
            Bitmap _operation = Bitmap.CreateBitmap(bm.Width, bm.Height, bm.GetConfig());

            for (int i = 0; i < bm.Width; i++)
            {
                for (int j = 0; j < bm.Height; j++)
                {
                    int p = bm.GetPixel(i, j);
                    int r = Color.GetRedComponent(p);
                    int g = Color.GetGreenComponent(p);
                    int b = Color.GetBlueComponent(p);
                    int a = Color.GetAlphaComponent(p);

                    r = r + 5;
                    //g = g + 50;
                    //b = b - 5;
                    //a = 100 + a;
                    _operation.SetPixel(i, j, Color.Argb(a, r, g, b));
                }
            }
            //img.SetImageBitmap(operation);
            return _operation;
        }

        public Bitmap Green(Bitmap bm) {
            Bitmap _operation = Bitmap.CreateBitmap(bm.Width, bm.Height, bm.GetConfig());

            for (int i = 0; i < bm.Width; i++)
            {
                for (int j = 0; j < bm.Height; j++)
                {
                    int p = bm.GetPixel(i, j);
                    int r = Color.GetRedComponent(p);
                    int g = Color.GetGreenComponent(p);
                    int b = Color.GetBlueComponent(p);
                    int a = Color.GetAlphaComponent(p);

                    r = 25 + r;
                    g = 50 + g;
                    b = 25 + b;
                    //a = 100 + a;
                    _operation.SetPixel(i, j, Color.Argb(a, r, g, b));
                }
            }
            //img.SetImageBitmap(operation);
            return _operation;
        }

        public Bitmap Blue(Bitmap bm) {
            Bitmap _operation = Bitmap.CreateBitmap(bm.Width, bm.Height, bm.GetConfig());

            for (int i = 0; i < bm.Width; i++)
            {
                for (int j = 0; j < bm.Height; j++)
                {
                    int p = bm.GetPixel(i, j);
                    int r = Color.GetRedComponent(p);
                    int g = Color.GetGreenComponent(p);
                    int b = Color.GetBlueComponent(p);
                    int a = Color.GetAlphaComponent(p);

                    //r = 15 + r;
                    //g = 5 - g;
                    b = 45 + b;
                    //a = 100 + a;
                    _operation.SetPixel(i, j, Color.Argb(a, r, g, b));
                }
            }
            //img.SetImageBitmap(operation);
            return _operation;
        }

        public Bitmap Warm(Bitmap bm) {
            Bitmap _operation = Bitmap.CreateBitmap(bm.Width, bm.Height, bm.GetConfig());

            for (int i = 0; i < bm.Width; i++)
            {
                for (int j = 0; j < bm.Height; j++)
                {
                    int p = bm.GetPixel(i, j);
                    int r = Color.GetRedComponent(p);
                    int g = Color.GetGreenComponent(p);
                    int b = Color.GetBlueComponent(p);
                    int a = Color.GetAlphaComponent(p);

                    r = 150 + r;
                    g = 100 + g;
                    //b = 100 + b;
                    //a = 100 + a;
                    _operation.SetPixel(i, j, Color.Argb(a, r, g, b));
                }
            }
            //img.SetImageBitmap(operation);
            return _operation;
        }

        public Bitmap ApplyInvertEffect(Bitmap _src) 
        {
            Bitmap bmOut = Bitmap.CreateBitmap(_src.Width, _src.Height, _src.GetConfig());

            int A, R, G, B;
            int pixelColor;

            int height = _src.Height;
            int width = _src.Width;

            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    pixelColor = _src.GetPixel(x, y);

                    A = Color.GetAlphaComponent(pixelColor);
                    R = 255 - Color.GetRedComponent(pixelColor);
                    G = 255 - Color.GetGreenComponent(pixelColor);
                    B = 255 - Color.GetBlueComponent(pixelColor);

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

            for (int i = 0; i < MAX_SIZE; ++i) {
                gammaR[i] = (int)Math.Min(MAX_VALUE_INT, (int)((MAX_VALUE_DBL * Math.Pow(i / MAX_VALUE_DBL, REVERSE / red)) + 0.5));
                gammaG[i] = (int)Math.Min(MAX_VALUE_INT, (int)((MAX_VALUE_DBL * Math.Pow(i / MAX_VALUE_DBL, REVERSE / green)) + 0.5));
                gammaB[i] = (int)Math.Min(MAX_VALUE_INT, (int)((MAX_VALUE_DBL * Math.Pow(i / MAX_VALUE_DBL, REVERSE / blue)) + 0.5));
            }

            for (int x = 0; x < width; ++x) {
                for (int y = 0; y < height; ++y) {
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

        public Bitmap ApplyColorFilterEffect(Bitmap _src, double red, double green, double blue) {
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

        /*public Bitmap ApplyTintEffect(Bitmap _src, int degree) {
            int width = _src.Width;
            int height = _src.Height;

            int[] pix = new int[width * height];
            _src.GetPixels(pix, 0, width, 0, 0, width, height);

            int RY, GY, BY, RYY, GYY, BYY, R, G, B, Y;
            double angle = (Math.PI * (double)degree) / 90;

            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    int r = (pix[index] >> 16) & new Color(0f00);
                }
            }
        }*/

        /*public Bitmap ApplySnowEffect(Bitmap _src) {
            int width = _src.Width;
            int height = _src.Height;
            int[] pixels = new int[width * height];
            _src.GetPixels(pixels, 0, width, 0, 0, width, height);

            Random random = new Random();
            int R, G, B, index = 0, thresHold = 50;

            for (int y = 0; y < width; ++y) {
                for (int x = 0; x < width; ++x) {
                    index = y * width + x;

                    R = Color.GetRedComponent(pixels[index]);
                    G = Color.GetGreenComponent(pixels[index]);
                    B = Color.GetBlueComponent(pixels[index]);
                    const int COLOR_MAX = 256;

                    thresHold = random.Next(COLOR_MAX);

                    if(R > thresHold && G > thresHold && B > thresHold) {
                        pixels[index] = Color.Rgb(COLOR_MAX, COLOR_MAX, COLOR_MAX);
                    }
                }
            }

            Bitmap bmOut = Bitmap.CreateBitmap(width, height, Bitmap.Config.Rgb565);
            bmOut.SetPixels(pixels, 0, width, 0, 0, width, height);
            return bmOut;
        }*/

        /*public Bitmap ApplyShadingFilter(Bitmap _src, int shadingColor) {
            int width = _src.Width;
            int height = _src.Height;
            int[] pixels = new int[width * height];
            _src.GetPixels(pixels, 0, width, 0, 0, width, height);

            int index = 0;
            for (int y = 0; y < height; ++y) {
                for (int x = 0; x < width; ++x) {
                    index = y * width + x;
                    pixels[index] &= shadingColor;
                }
            }

            Bitmap bmOut = Bitmap.CreateBitmap(width, height, Bitmap.Config.Argb8888);
            bmOut.SetPixels(pixels, 0, width, 0, 0, width, height);
            return bmOut;
        }*/

        public Bitmap ApplySaturationFilter(Bitmap _src, int level) {
            int width = _src.Width;
            int height = _src.Height;
            int[] pixels = new int[width * height];
            float[] HSV = new float[3];
            _src.GetPixels(pixels, 0, width, 0, 0, width, height);

            int index = 0;

            for (int y = 0; y < height; ++y) {
                for (int x = 0; x < width; ++x) {
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

        public Bitmap ApplyReflection(Bitmap _src) {
            const int REFLECTION_GAP = 4;

            int width = _src.Width;
            int height = _src.Height;

            Matrix matrix = new Matrix();
            matrix.PreScale(1, -1);

            Bitmap reflectionImage = Bitmap.CreateBitmap(_src, 0, height / 2, width, height / 2, matrix, false);
            Bitmap bitmapWithReflection = Bitmap.CreateBitmap(width, (height + height / 2), Bitmap.Config.Argb8888);

            Canvas canvas = new Canvas(bitmapWithReflection);
            canvas.DrawBitmap(_src, 0, 0, null);

            Paint defaultPaint = new Paint();
            canvas.DrawRect(0, height, width, height + REFLECTION_GAP, defaultPaint);
            canvas.DrawBitmap(reflectionImage, 0, height + REFLECTION_GAP, null);

            Paint paint = new Paint();

            LinearGradient shader = new LinearGradient(0, _src.Height, 0,
                                    bitmapWithReflection.Height + REFLECTION_GAP,
                                    new Color(0x70ffffff), new Color(0x00ffffff),
                                    Shader.TileMode.Clamp);

            paint.SetShader(shader);
            paint.SetXfermode(new PorterDuffXfermode(PorterDuff.Mode.DstIn));
            canvas.DrawRect(0, height, width, bitmapWithReflection.Height + REFLECTION_GAP, paint);

            return bitmapWithReflection;
        }

    }
}
