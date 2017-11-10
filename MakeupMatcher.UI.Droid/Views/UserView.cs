
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MakeupMatcher.Core.Repositories;
using MakeupMatcher.Core.Models;

using Android.App;
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

        //private SQLiteConnection _connection;

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
                var db = new SQLiteConnection(dbPath);

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

                var db = new SQLiteConnection(dbPath);

                var table = db.Table<UserModel>();

                foreach (var item in table)
                {
                    UserModel user = new UserModel();
                    user.UserImage = item.UserImage;
                    user.UserName = item.UserName;
                    displayText.Text += user.ToString() + "\n";
                }
            };

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
