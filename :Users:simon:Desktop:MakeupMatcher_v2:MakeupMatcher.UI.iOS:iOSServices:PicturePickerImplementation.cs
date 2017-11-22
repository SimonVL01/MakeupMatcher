using System;
using System.IO;
using System.Threading.Tasks;
using MakeupMatcher.Core.Services;
using UIKit;

namespace MakeupMatcher.UI.iOS.iOSServices
{
    public class PicturePickerImplementation : IPicturePicker
    {
        TaskCompletionSource<Stream> taskCompletionSource;
        UIImagePickerController imagePicker;

        public Task<Stream> GetImageStreamAsync()
        {
            imagePicker = new UIImagePickerController
            {
                SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
                MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary);
            }:

            imagePicker.FinishedPickingMedia += OnImagePickerFinishedPickingMedia;
            imagePicker.Canceled += OnImagePickerCancelled;

            UIWindow window = UIApplication.SharedApplication.KeyWindow;
            var viewController = Root
        }
    }
}
