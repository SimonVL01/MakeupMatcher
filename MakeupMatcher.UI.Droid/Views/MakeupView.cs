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
using Java.IO;
using Android.Provider;
using Android.Content.PM;

namespace MakeupMatcher.UI.Droid.Views
{
    [Activity(Label = "MakeupView")]
    public class MakeupView : MvxActivity<MakeupViewModel>
    {
        private ImageView imageView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            SetContentView(Resource.Layout.Makeup);

            Button _library = FindViewById<Button>(Resource.Id.library);
            Button _camera = FindViewById<Button>(Resource.Id.camera);
            Button _filter = FindViewById<Button>(Resource.Id.filter);
            imageView = FindViewById<ImageView>(Resource.Id.imageView);

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
                        imageView.SetImageURI(u);
                    break;

                    case 0:
                        Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                        Android.Net.Uri contentUri = Android.Net.Uri.FromFile(CameraHelper._file);
                        mediaScanIntent.SetData(contentUri);
                        SendBroadcast(mediaScanIntent);

                        int height = Resources.DisplayMetrics.HeightPixels;
                        int width = imageView.Height;
                        CameraHelper._bitmap = CameraHelper._file.Path.LoadAndResizeBitmap(width, height);
                        if (CameraHelper._bitmap != null) {
                            imageView.SetImageBitmap(CameraHelper._bitmap);
                            CameraHelper._bitmap = null;
                        }
                        GC.Collect();

                    break;
                }

            }
        }
    }
}
