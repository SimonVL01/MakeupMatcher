
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
using SQLite;

namespace MakeupMatcher.UI.Droid.Views
{
    [Activity(Label = "UserView")]
    public class UserView : MvxActivity
    {
        private SQLiteConnection db;

        private LottieAnimationView animationView;
        string userName;
        string userImage;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            string dbPath = Path.Combine(System.
                Environment.GetFolderPath
                (System.Environment.SpecialFolder.Personal), "dbTest.db3");

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.User);

            Button button = FindViewById<Button>(Resource.Id.clicker);
            Button getButton = FindViewById<Button>(Resource.Id.get);

            button.Click += delegate {
                
                //setup connection
                db = new SQLiteConnection(dbPath);

                db.CreateTable<UserModel>();

                //MakeupModel makeup = new MakeupModel();
                UserModel user = new UserModel();

                user.UserName = "Fabulous Simona";
                user.UserImage = "blabla/path";

                db.Insert(user);

                db.Close();
            };

            getButton.Click += delegate {
                TextView displayText = FindViewById<TextView>(Resource.Id.userData);

                db = new SQLiteConnection(dbPath);

                var table = db.Table<UserModel>();

                foreach (var item in table)
                {
                    UserModel user = new UserModel();
                    user.UserImage = item.UserImage;
                    user.UserName = item.UserName;
                    displayText.Text += user.ToString() + "\n";
                }
            };


            EditText usernameField = FindViewById<EditText>(Resource.Id.username);
            userName = usernameField.Text;
            EditText userImageField = FindViewById<EditText>(Resource.Id.userimage);
            userImage = userImageField.Text;

            animationView = FindViewById<LottieAnimationView>(Resource.Id.animation_view);

        }

        protected override void OnStart()
        {
            base.OnStart();   
            animationView.Progress = 0f;
            animationView.PlayAnimation();
        }

        protected override void OnStop()
        {
            base.OnStop();
            this.animationView.Progress = 0f;
            this.animationView.PlayAnimation();
        }

        /*private async Task<string> insertUpdateData(UserModel user, string path)
        {
            try
            {
                var db = new SQLiteAsyncConnection(path);
            }
        }*/

    }
}
