using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MakeupMatcher.Core.Repositories;
using MakeupMatcher.Core.Models;

using Android.App;
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
using SQLite;

namespace MakeupMatcher.UI.Droid.Views
{
    [Activity(Label = "MakeupView")]
    public class MakeupView : MvxActivity<MakeupViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            SetContentView(Resource.Layout.Makeup);

            Button _library = FindViewById<Button>(Resource.Id.library);
            Button _camera = FindViewById<Button>(Resource.Id.camera);
            Button _filter = FindViewById<Button>(Resource.Id.filter);

            _library.Click += delegate {
                Intent intent = new Intent(Intent.ActionOpenDocument);

                intent.AddCategory(Intent.CategoryOpenable);

                intent.SetType("image/*");
                StartActivityForResult(intent, 1);
            };

            _camera.Click += delegate {
                //CheckCameraHardware();
            };
        }

        private Boolean CheckCameraHardware(Context context) {
            if (context.PackageManager.HasSystemFeature("FEATURE_CAMERA")) {
                return true;
            } else {
                return false;
            }        
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent resultData)
        {
            base.OnActivityResult(requestCode, resultCode, resultData);
            if (resultCode == Result.Ok)
            {

                ImageView userImage = FindViewById<ImageView>(Resource.Id.userImage);
                Android.Net.Uri u = resultData.Data;
                userImage.SetImageURI(u);
            }
        }
    }
}
