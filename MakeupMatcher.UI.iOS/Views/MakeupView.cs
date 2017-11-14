﻿using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MakeupMatcher.Core.ViewModels;
using Airbnb.Lottie;
using MakeupMatcher.Core.Models;
using SQLite;

using UIKit;
using CoreGraphics;
using Foundation;

namespace MakeupMatcher.UI.iOS.Views
{
    public partial class MakeupView : MvxViewController<MakeupViewModel>
    {
        private int TouchX;
        private int TouchY;
        private UIColor FavColor;
        private UIImagePickerController ImagePicker;


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
                    ImagePicker = new UIImagePickerController();
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

        }

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
                    imageView.Image = originalImage;
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

            if (editedImage != null) {
                Console.WriteLine("got the edited image");
                imageView.Image = editedImage;
            }

            ImagePicker.DismissViewController(true, null);
        }

        protected void Handle_Canceled(object sender, EventArgs e) {
            ImagePicker.DismissViewController(true, null);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

