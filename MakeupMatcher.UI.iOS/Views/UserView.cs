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
using MvvmCross.Plugins.PictureChooser;
using MvvmCross.Platform;

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

            var set = this.CreateBindingSet<UserView, UserViewModel>();
            set.Bind(username).For(t => t.Text).To(vm => vm.Username);
            set.Bind(password).For(t => t.Text).To(vm => vm.UserPassword);
            //set.Bind(login).For(b => b.KeyCommands).To(vm => vm.User)
            set.Apply();

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
                    var task = Mvx.Resolve<IMvxPictureChooserTask>();
                    task.ChoosePictureFromLibrary(500, 90,
                                                  stream => {
                                                      var memoryStream = new MemoryStream();
                                                      stream.CopyTo(memoryStream);
                                                      ViewModel.ImageData = memoryStream.ToArray();
                                                      var data = NSData.FromArray(memoryStream.ToArray());
                                                      pic.SetBackgroundImage(UIImage.LoadFromData(data), UIControlState.Normal);
                                                      }, () => { });

                }
            };

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

