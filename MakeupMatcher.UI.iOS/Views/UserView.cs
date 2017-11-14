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

            NavigationItem.Title = "Login";

            var docsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var libPath = Path.Combine(docsPath, "..", "Library");

            dbPath = Path.Combine(libPath, "dbTest.db3");

            login.TouchUpInside += async (sender, e) =>
            {
                db = new SQLiteConnection(dbPath);

                var table = db.Table<UserModel>();

                db.CreateTable<UserModel>();

                UserModel user = new UserModel();

                user.UserId = table.Count() + 1;
                user.UserName = username.Text;
                //user.UserImage = password.Text;
                user.UserPassWord = password.Text;

                //

                db.Insert(user);
                db.Close();

                /*var confirmAlertController = UIAlertController.Create("Done!","Your Id is " + user.UserId + ", your profilename is " +
                                                                      user.UserName +  " and your password is " +
                                                                      user.UserPassWord, UIAlertControllerStyle.Alert);

                confirmAlertController.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));

                PresentViewController(confirmAlertController, true, null);*/

                 await ViewModel.GoToMakeupCommand.ExecuteAsync();

            };

            /*LOTAnimationView animation = LOTAnimationView.AnimationNamed("heart");
            animation.Frame = new CGRect(0, 100, this.View.Frame.Size.Width, 250);
            animation.ContentMode = UIViewContentMode.ScaleAspectFill;
            animation.LoopAnimation = true;

            this.View.AddSubview(animation);
            animation.Play();*/

            var g = new UITapGestureRecognizer(() => View.EndEditing(true));
            g.CancelsTouchesInView = false;

            View.AddGestureRecognizer(g);

        }

        public override void ViewWillDisappear(bool Animated)
        {
            if(this.NavigationController != null) {
                var Controllers = this.NavigationController.ViewControllers;
                var NewControllers = new UIViewController[Controllers.Length -1];
                int Index = 0;
                foreach(var item in Controllers) {
                    if (item != this) {
                        NewControllers[Index] = item;
                        Index++;
                    }

                }
                this.NavigationController.ViewControllers = NewControllers;
            }
            base.ViewWillDisappear(Animated);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        //Custom functions

    }
}

