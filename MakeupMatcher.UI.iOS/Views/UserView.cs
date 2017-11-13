using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MakeupMatcher.Core.ViewModels;
using Airbnb.Lottie;
using MakeupMatcher.Core.Models;
using SQLite;
using CoreGraphics;

using UIKit;
using System.IO;

namespace MakeupMatcher.UI.iOS.Views
{
    public partial class UserView : MvxViewController<UserViewModel>
    {
        private SQLiteConnection db;
        private string dbPath;

        public UserView() : base("UserView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var docsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var libPath = Path.Combine(docsPath, "..", "Library");

            dbPath = Path.Combine(libPath, "dbTest.db3");

            store.TouchUpInside += (sender, ea) =>
            {
                db = new SQLiteConnection(dbPath);

                db.CreateTable<UserModel>();

                UserModel user = new UserModel();

                user.UserName = "Fabolous Simona";
                user.UserImage = "blabla/path";

                db.Insert(user);
                db.Close();

                data.Text += user.UserName + " " + user.UserImage + "\n";
            };

            show.TouchUpInside += (sender, ea) =>
            {
                db = new SQLiteConnection(dbPath);

                var table = db.Table<UserModel>();

                foreach(var item in table)
                {
                    UserModel user = new UserModel();
                    user.UserImage = item.UserImage;
                    user.UserName = item.UserName;
                    //info.Text += user.ToString() + "/n";
                }

                info.Text += table.Count();

            };

            /*LOTAnimationView animation = LOTAnimationView.AnimationNamed("heart");
            animation.Frame = new CGRect(0, 100, this.View.Frame.Size.Width, 250);
            animation.ContentMode = UIViewContentMode.ScaleAspectFill;
            animation.LoopAnimation = true;

            this.View.AddSubview(animation);
            animation.Play();*/
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

