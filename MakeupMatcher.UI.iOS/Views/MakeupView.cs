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

            library.TouchUpInside += (sender, e) => {
                
                UIImagePickerController imagePicker = new UIImagePickerController();
                imagePicker.Delegate = Self;
                imagePicker.SourceType = UIImagePickerControllerSourceType.Camera;
                imagePicker.AllowsEditing = true;
                this.PresentViewController(imagePicker, true, null);
            };

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

