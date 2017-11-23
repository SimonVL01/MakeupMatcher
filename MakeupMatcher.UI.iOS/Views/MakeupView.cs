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
using MakeupMatcher.Core.Enum;
using MvvmCross.Plugins.PictureChooser;
using MvvmCross.Platform;
using System.IO;

namespace MakeupMatcher.UI.iOS.Views
{
    public partial class MakeupView : MvxViewController<MakeupViewModel>
    {
        private UIImagePickerController ImagePicker;
        private Colors _chosenColor;
        private byte[] alphaPixel = { 0, 0, 0, 0 };
        private string _colorValue;


        public MakeupView() : base("MakeupView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ImagePicker = new UIImagePickerController();

            NavigationItem.HidesBackButton = true;

            NavigationItem.Title = ViewModel.User;

            color.Layer.CornerRadius = 30;
            color.Layer.MasksToBounds = true;

            //color.SetTitle(_colorValue, UIControlState.Normal);

            var set = this.CreateBindingSet<MakeupView, MakeupViewModel>();
            set.Bind(imageView).For(t => t.Image).To(vm => vm.ImageBytes).WithConversion("InMemoryImage");
            //set.Bind(password).For(t => t.Text).To(vm => vm.UserPassword);
            //set.Bind(login).For(b => b.KeyCommands).To(vm => vm.User)
            //set.Bind(library).To("BrowseLibrary");
            set.Apply();

            camera.TouchUpInside += (sender, e) =>
            {

                if (UIImagePickerController.IsSourceTypeAvailable(UIImagePickerControllerSourceType.Camera))
                {
                    /*ImagePicker = new UIImagePickerController();
                    ImagePicker.Delegate = Self;
                    ImagePicker.SourceType = UIImagePickerControllerSourceType.Camera;
                    ImagePicker.AllowsEditing = true;
                    this.PresentViewController(ImagePicker, true, null);
                } */
                    var task = Mvx.Resolve<IMvxPictureChooserTask>();
                    task.TakePicture(500, 90,
                                                  stream =>
                                                  {
                                                      var memoryStream = new MemoryStream();
                                                      stream.CopyTo(memoryStream);
                                                      ViewModel.ImageBytes = memoryStream.ToArray();
                                                  }, () => { });
                }
            };

            library.TouchUpInside += (sender, e) => {

                if (UIImagePickerController.IsSourceTypeAvailable(UIImagePickerControllerSourceType.PhotoLibrary)) 
                {

                    var task = Mvx.Resolve<IMvxPictureChooserTask>();
                    task.ChoosePictureFromLibrary(500, 90,
                                                  stream => {
                                                      var memoryStream = new MemoryStream();
                                                      stream.CopyTo(memoryStream);
                                                      ViewModel.ImageBytes = memoryStream.ToArray();
                                                      var data = NSData.FromArray(memoryStream.ToArray());
                                                      imageView.Image = UIImage.LoadFromData(data);
                                                  }, () => { });

                } 
            };

            filter.TouchUpInside += async (sender, e) => {
                await ViewModel.GoToFilterCommand.ExecuteAsync();
            };

            color.TouchUpInside += async (sender, e) => {

                //this.CreateBinding(_chosenColor).To((MakeupViewModel vm) => vm.ColorName).Apply();
                await ViewModel.GoToProductCommand.ExecuteAsync();
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

        protected UIColor GetColorAtTouchPoint(CGPoint Point)
        {
            var colorSpace = CGColorSpace.CreateDeviceRGB();
            var bitmapContext = new CGBitmapContext(alphaPixel, 1, 1, 8, 4, colorSpace, CGBitmapFlags.PremultipliedLast);
            bitmapContext.TranslateCTM(-Point.X, -Point.Y);
            View.Layer.RenderInContext(bitmapContext);

            var newColor = UIColor.FromRGBA(alphaPixel[0], alphaPixel[1], alphaPixel[2], alphaPixel[3]);

            /*if (newColor.CIColor.Red <= 200 && newColor.CIColor.Blue >= 75 && newColor.CIColor.Green >= 75)
                _chosenColor = Colors.Red;
            else if (newColor.CIColor.Red <= 210 && newColor.CIColor.Blue >= 210 && newColor.CIColor.Green <= 50)
                _chosenColor = Colors.Magenta;
            if (newColor.CIColor.Red <= 225 && newColor.CIColor.Green <= 150 && newColor.CIColor.Green >= 200 && newColor.CIColor.Blue >= 200)
                _chosenColor = Colors.Pink;
            else if (newColor.CIColor.Red >= 100 && newColor.CIColor.Blue >= 100 && newColor.CIColor.Green >= 100)
                _chosenColor = Colors.DarkBrown;
            else if (newColor.CIColor.Red >= 225 && newColor.CIColor.Blue >= 225 && newColor.CIColor.Green >= 225)
                _chosenColor = Colors.TannedBrown;
            else if (newColor.CIColor.Red >= 200 && newColor.CIColor.Blue <= 200 && newColor.CIColor.Blue >= 100 && newColor.CIColor.Green >= 200)
                _chosenColor = Colors.Ochre;
            else if (newColor.CIColor.Red <= 120 && newColor.CIColor.Blue <= 225 && newColor.CIColor.Green <= 150 && newColor.CIColor.Green >= 225)
                _chosenColor = Colors.LittleBlue;*/

            //_colorValue = _chosenColor.ToString();

            return newColor;
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

        public void BrowseLibrary() {
            var task = Mvx.Resolve<IMvxPictureChooserTask>();
            task.ChoosePictureFromLibrary(500, 90,
                                          stream => {
                                          var memoryStream = new MemoryStream();
                                          stream.CopyTo(memoryStream);
                                          ViewModel.ImageBytes = memoryStream.ToArray();
                                          }, () => { });
        }
    }
}

