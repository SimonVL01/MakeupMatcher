using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MakeupMatcher.Core.ViewModels;
using Airbnb.Lottie;
using MakeupMatcher.Core.Models;
using SQLite;

using UIKit;
using CoreGraphics;

namespace MakeupMatcher.UI.iOS.Views
{
    public partial class MakeupView : MvxViewController<MakeupViewModel>
    {
        private int TouchX;
        private int TouchY;
        private UIColor FavColor;


        public MakeupView() : base("MakeupView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationItem.HidesBackButton = true;

            NavigationItem.Title = "Pick a color";

            camera.TouchUpInside += (sender, e) => {

                if (UIImagePickerController.IsSourceTypeAvailable(UIImagePickerControllerSourceType.Camera))
                {
                    UIImagePickerController ImagePicker = new UIImagePickerController();
                    ImagePicker.Delegate = Self;
                    ImagePicker.SourceType = UIImagePickerControllerSourceType.Camera;
                    ImagePicker.AllowsEditing = true;
                    this.PresentViewController(ImagePicker, true, null);
                } else {
                }
            };

            library.TouchUpInside += (sender, e) => {

                if (UIImagePickerController.IsSourceTypeAvailable(UIImagePickerControllerSourceType.PhotoLibrary)) 
                {
                    UIImagePickerController ImagePicker = new UIImagePickerController();
                    ImagePicker.AllowsEditing = true;
                    ImagePicker.Delegate = Self;
                    ImagePicker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
                    this.PresentViewController(ImagePicker, true, null);
                } 
            };

        }


        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

