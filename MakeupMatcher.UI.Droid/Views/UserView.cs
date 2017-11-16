
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
    [Activity(Label = "UserView")]
    public class UserView : MvxActivity<UserViewModel>
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

            EditText name = FindViewById<EditText>(Resource.Id.username);
            EditText password = FindViewById<EditText>(Resource.Id.userPassword);
            Button login = FindViewById<Button>(Resource.Id.login);
            ImageView userImage = FindViewById<ImageView>(Resource.Id.userImage);

            login.Click += delegate {
                
                //setup connection
                db = new SQLiteConnection(dbPath);

                db.CreateTable<UserModel>();

                //MakeupModel makeup = new MakeupModel();
                UserModel user = new UserModel();


                user.UserId = DatabaseList().ToArray().Count() + 1;
                user.UserName = name.Text;
                user.UserPassWord = password.Text;
                //Uri path = new Uri().LocalPath(userImage);
                //user.UserImage = path.ToString();

                db.Insert(user);
                db.Close();

                AlertDialog.Builder builder = new AlertDialog.Builder
                    (this, Android.Resource.Style.ThemeMaterialDialogAlert);
                builder.SetTitle(Resource.String.login_complete)
                       .SetMessage("Your Id is " + user.UserId + ", your profilename is " +
                                                                      user.UserName + " and your image is " +
                                                                      user.UserImage + " and your password is " +
                                                                      user.UserPassWord)
                       .SetPositiveButton("Ok!", OkAction)
                       .Show();
                
            };

        }

        private async void OkAction(object sender, DialogClickEventArgs e) {
            var myButton = sender as Button;
            if (myButton != null) {
                await ViewModel.GoToMakeupCommand.ExecuteAsync();
            }
        }

        /*protected override void OnStart()
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
        }*/

    }
}
