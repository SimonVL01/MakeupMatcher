using System;
using Airbnb.Lottie;
using UIKit;
using SQLitePCL;

namespace MakeupMatcher.UI.iOS.Views
{
    public partial class UserView : UIViewController
    {
        //private SQLConnection db;

        public UserView() : base("UserView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            LOTAnimationView animation = LOTAnimationView.AnimationNamed("heart");
            this.View.AddSubview(animation);
            animation.Play();

            storedata.TouchUpInside += (sender, e) => 
            {
                
            };
        }

        /*button.Click += delegate {
                
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


            EditText usernameField = FindViewById<EditText>(Resource.Id.username);
userName = usernameField.Text;
            EditText userImageField = FindViewById<EditText>(Resource.Id.userimage);
userImage = userImageField.Text;*/

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

