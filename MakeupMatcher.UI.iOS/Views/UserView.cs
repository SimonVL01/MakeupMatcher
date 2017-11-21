using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MakeupMatcher.Core.ViewModels;
using Airbnb.Lottie;
using MakeupMatcher.Core.Models;
using SQLite;
using CoreGraphics;
using System;
using MakeupMatcher.UI.iOS.iOSServices;

using UIKit;
using Foundation;
using System.IO;

namespace MakeupMatcher.UI.iOS.Views
{
    public partial class UserView : MvxViewController<UserViewModel>
    {
        private SQLiteConnection db;
        private string dbPath;
        private UIImagePickerController ImagePicker;

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

            //image.Layer.CornerRadius = image.Frame.Size.Width / 2;
            //image.ClipsToBounds = true;

            login.TouchUpInside += async (sender, e) =>
            {
                db = new SQLiteConnection(dbPath);

                var table = db.Table<UserModel>();

                db.CreateTable<UserModel>();

                UserModel user = new UserModel();

                user.UserId = table.Count() + 1;
                user.UserName = username.Text;
                user.UserImage = pic.CurrentBackgroundImage.ToString();
                user.UserPassWord = password.Text;

                //Databinding

                //this.CreateBinding().To((UserViewModel uvm) => uvm.UserId);
                this.CreateBinding(username).To((UserViewModel uvm) => uvm.Username).Apply();
                this.CreateBinding(password).To((UserViewModel uvm) => uvm.UserPassword);
                this.CreateBinding(pic.AccessibilityLabel).To((UserViewModel uvm) => uvm.UserImage);

                db.Insert(user);
                db.Close();

                /*var confirmAlertController = UIAlertController.Create("Done!","Your Id is " + user.UserId + ", your profilename is " +
                                                                      user.UserName +  " and your image is " +
                                                                      user.UserImage + " and your password is " +
                                                                      user.UserPassWord, UIAlertControllerStyle.Alert);


                confirmAlertController.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));

                PresentViewController(confirmAlertController, true, null);*/

                 await ViewModel.GoToMakeupCommand.ExecuteAsync();

                //

            };

            pic.Layer.CornerRadius = 65; // this value vary as per your desire
            pic.ClipsToBounds = true;

            pic.TouchUpInside += (sender, e) => {

                if (UIImagePickerController.IsSourceTypeAvailable(UIImagePickerControllerSourceType.PhotoLibrary))
                {
                    ImagePicker = new UIImagePickerController();
                    ImagePicker.AllowsEditing = true;
                    ImagePicker.Delegate = Self;
                    ImagePicker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
                    ImagePicker.MediaTypes = UIImagePickerController
                        .AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary);

                    ImagePicker.FinishedPickingMedia += Handle_FinishedPickingMedia;
                    ImagePicker.Canceled += Handle_Canceled;

                    this.PresentViewController(ImagePicker, true, null);

                }
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

        protected void Handle_FinishedPickingMedia(object _sender, UIImagePickerMediaPickedEventArgs a)
        {
            bool IsImage = false;
            switch (a.Info[UIImagePickerController.MediaType].ToString())
            {
                case "public.image":
                    Console.WriteLine("Image selected");
                    IsImage = true;
                    break;
                case "public.video":
                    Console.WriteLine("Video selected");
                    break;
            }

            NSUrl referenceURL = a.Info[new NSString("UIImagePickerControllerReference")] as NSUrl;
            if (referenceURL != null)
                Console.WriteLine("Url:" + referenceURL.ToString());

            if (IsImage)
            {
                UIImage originalImage =
                    a.Info[UIImagePickerController.OriginalImage] as UIImage;
                if (originalImage != null)
                {
                    Console.WriteLine("Got the original image");
                    pic.SetBackgroundImage(originalImage, UIControlState.Highlighted);
                }
            }
            else
            {
                NSUrl mediaURL = a.Info[UIImagePickerController.MediaURL] as NSUrl;
                if (mediaURL != null)
                {
                    Console.WriteLine(mediaURL.ToString());
                }
            }

            UIImage editedImage = a.Info[UIImagePickerController.EditedImage] as UIImage;

            if (editedImage != null)
            {
                Console.WriteLine("got the edited image");
                pic.SetBackgroundImage(editedImage, UIControlState.Highlighted);
                pic.Layer.CornerRadius = 65; // this value vary as per your desire
                pic.ClipsToBounds = true;
                //= editedImage;
            }

            ImagePicker.DismissViewController(true, null);
        }

        protected void Handle_Canceled(object sender, EventArgs e)
        {
            ImagePicker.DismissViewController(true, null);
        }

    }
}

