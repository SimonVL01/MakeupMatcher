using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MakeupMatcher.Core.ViewModels;
using Airbnb.Lottie;
using MakeupMatcher.Core.Models;
using SQLite;

using UIKit;
using System.IO;

namespace MakeupMatcher.UI.iOS.Views
{
    public partial class UserView : MvxViewController<UserViewModel>
    {
        private SQLiteConnection db;

        public UserView() : base("UserView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var docsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var libPath = Path.Combine(docsPath, "..", "Library");

            string dbPath = Path.Combine(libPath, "dbTest.db3");

            store.TouchUpInside += (sender, ea) =>
            {
                db = new SQLiteConnection(dbPath);

                db.CreateTable<UserModel>();

                UserModel user = new UserModel();

                user.UserName = "Fabolous Simona";
                user.UserImage = "blabla/path";

                db.Insert(user);
                db.Close();

            };

            /*button.Click += delegate {

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
            };*/

            LOTAnimationView animation = LOTAnimationView.AnimationNamed("heart");
            this.View.AddSubview(animation);
            animation.Play();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

