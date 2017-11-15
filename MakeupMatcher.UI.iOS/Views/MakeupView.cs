using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MakeupMatcher.Core.ViewModels;
using Airbnb.Lottie;
using MakeupMatcher.Core.Models;
using SQLite;
using MakeupMatcher.UI.iOS.iOSServices;

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
        private byte[] alphaPixel = { 0, 0, 0, 0 };


        public MakeupView() : base("MakeupView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ImagePicker = new UIImagePickerController();

            NavigationItem.HidesBackButton = true;

            NavigationItem.Title = "Pick a color";

            color.Layer.CornerRadius = 30;
            color.Layer.MasksToBounds = true;

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

            filter.TouchUpInside += async (sender, e) => {
                await ViewModel.GoToFilterCommand.ExecuteAsync();
            };

            //LibraryAccess = new LibraryAccessService();
            //library.TouchUpInside += (sender, e) => {
            //imageView.Image = LibraryAccessService.GetAccess(library, this, ImagePicker, imageView.Image);

                //imageView.Image = AccessService.GetAccess();
            //};

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

        protected UIColor GetColorAtTouchPoint(CGPoint Point)
        {
            var colorSpace = CGColorSpace.CreateDeviceRGB();
            var bitmapContext = new CGBitmapContext(alphaPixel, 1, 1, 8, 4, colorSpace, CGBitmapFlags.PremultipliedLast);
            bitmapContext.TranslateCTM(-Point.X, -Point.Y);
            View.Layer.RenderInContext(bitmapContext);
            return UIColor.FromRGBA(alphaPixel[0], alphaPixel[1], alphaPixel[2], alphaPixel[3]);
        }

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);

            var touch = touches.AnyObject as UITouch;
            var location = touch.LocationInView(this.View);

            //color.BackgroundColor = GetColorAtTouchPoint(evt.TouchesForView().);
            color.BackgroundColor = GetColorAtTouchPoint(location);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

