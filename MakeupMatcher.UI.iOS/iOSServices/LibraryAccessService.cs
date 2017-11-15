using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MakeupMatcher.Core.ViewModels;
using Airbnb.Lottie;
using MakeupMatcher.Core.Models;
using SQLite;

using UIKit;
using CoreGraphics;
using Foundation;

namespace MakeupMatcher.UI.iOS.iOSServices
{
    public class LibraryAccessService
    {
        private MvxViewController _controller;
        private UIImagePickerController _imagePicker;
        public UIImage _image;

        public LibraryAccessService(MvxViewController controller, UIImagePickerController imagePicker, UIImage image) {
            _controller = controller;
            _imagePicker = imagePicker;
            _image = image;
        }

        /*public UIImage GetAccess() {
            //viewAccess.TouchUpInside += (sender, e) => {

                if (UIImagePickerController.IsSourceTypeAvailable(UIImagePickerControllerSourceType.PhotoLibrary))
                {
                    _imagePicker = new UIImagePickerController();
                    _imagePicker.AllowsEditing = true;
                    _imagePicker.Delegate = _controller;
                    _imagePicker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
                    _imagePicker.MediaTypes = UIImagePickerController
                        .AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary);

                    _imagePicker.FinishedPickingMedia += Handle_FinishedPickingMedia;
                    _imagePicker.Canceled += Handle_Canceled;
                    
                    //_controller.PresentViewController(_imagePicker, true, null);

                }

            return _image;
            //};
        }*/

        public void Handle_FinishedPickingMedia(object _sender, UIImagePickerMediaPickedEventArgs a)
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
                    _image = originalImage;
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
                _image = editedImage;
            }

            _imagePicker.DismissViewController(true, null);
        }

        public void Handle_Canceled(object sender, EventArgs e)
        {
            _imagePicker.DismissViewController(true, null);

        }
    }
}