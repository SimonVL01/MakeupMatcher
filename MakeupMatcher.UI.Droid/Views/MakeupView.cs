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
    [Activity(Label = "MakeupView")]
    public class MakeupView : MvxActivity<MakeupViewModel>, Android.Views.View.IOnTouchListener
    {
        private ImageView _imageView;
        private Bitmap _bitmap;
        private Button _color;
        private GradientDrawable _bgShape;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            SetContentView(Resource.Layout.Makeup);

            Button _library = FindViewById<Button>(Resource.Id.library);
            Button _camera = FindViewById<Button>(Resource.Id.camera);
            Button _filter = FindViewById<Button>(Resource.Id.filter);
            _color = FindViewById<Button>(Resource.Id.color);
            _imageView = FindViewById<ImageView>(Resource.Id.imageView);

            _bgShape = (GradientDrawable)_color.Background;
            _bgShape.SetColor(Color.White);

            _library.Click += delegate {
                Intent intent = new Intent(Intent.ActionOpenDocument);

                intent.AddCategory(Intent.CategoryOpenable);

                intent.SetType("image/*");
                StartActivityForResult(intent, 1);
            };

            if (IsThereAnAppToTakePictures())
            {
                CreateDirectoryForPictures();
            }

            _camera.Click += TakePicture;

            _bitmap = ((BitmapDrawable)_imageView.Drawable).Bitmap;

            _imageView.SetOnTouchListener(this);

            _color.Click += async (sender, e) => await ViewModel.GoToProductCommand.ExecuteAsync();

            _filter.Click += async (sender, e) => await ViewModel.GoToFilterCommand.ExecuteAsync();
        }

        private void CreateDirectoryForPictures()
        {
            CameraHelper._dir = new File(
                Android.OS.Environment.GetExternalStoragePublicDirectory(
                Android.OS.Environment.DirectoryPictures), "CameraAppDemo");
            if(!CameraHelper._dir.Exists()) {
                CameraHelper._dir.Mkdirs();
            }
        }

        private bool IsThereAnAppToTakePictures()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            IList<ResolveInfo> availableActivities =
                PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
            return availableActivities != null && availableActivities.Count > 0;
        }

        private void TakePicture(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            CameraHelper._file = new File(CameraHelper._dir, String.Format("myPhoto_{0}.jpg", Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(CameraHelper._file));
            StartActivityForResult(intent, 0);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent resultData)
        {
            base.OnActivityResult(requestCode, resultCode, resultData);
            if (resultCode == Result.Ok)
            {
                switch(requestCode)
                {
                    case 1:
                        Android.Net.Uri u = resultData.Data;
                        _imageView.SetImageURI(u);
                    break;

                    case 0:
                        Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                        Android.Net.Uri contentUri = Android.Net.Uri.FromFile(CameraHelper._file);
                        mediaScanIntent.SetData(contentUri);
                        SendBroadcast(mediaScanIntent);

                        int height = Resources.DisplayMetrics.HeightPixels;
                        int width = _imageView.Height;
                        CameraHelper._bitmap = CameraHelper._file.Path.LoadAndResizeBitmap(width, height);
                        if (CameraHelper._bitmap != null) {
                            _imageView.SetImageBitmap(CameraHelper._bitmap);
                            CameraHelper._bitmap = null;
                        }
                        GC.Collect();

                    break;
                }

            }
        }

        public bool OnTouch(View v, MotionEvent e)
        {
            int x = (int)e.GetX();
            int y = (int)e.GetY();
            int pixel = _bitmap.GetPixel(x, y);
            //Color _uiColor = new Color();
            Color _uiColor = new Color();

            _uiColor.R = (byte)Color.GetRedComponent(pixel);
            _uiColor.G = (byte)Color.GetGreenComponent(pixel);
            _uiColor.B = (byte)Color.GetBlueComponent(pixel);
            _uiColor.A = (byte)Color.GetAlphaComponent(pixel);
            //_color.SetBackgroundColor(_uiColor);
            _bgShape.SetColor(_uiColor);

            return false;
        }
    }
}
