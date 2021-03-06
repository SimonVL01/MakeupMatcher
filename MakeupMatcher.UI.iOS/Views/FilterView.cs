﻿using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MakeupMatcher.Core.ViewModels;
using Airbnb.Lottie;
using MakeupMatcher.Core.Models;
using SQLite;
using MakeupMatcher.UI.iOS.iOSServices;
using UIKit;
using CoreImage;
using Foundation;
using CoreGraphics;

namespace MakeupMatcher.UI.iOS.Views
{
    public partial class FilterView : MvxViewController<FilterViewModel>
    {
        private UIImage imageView;
        private int _itemCount = 0;
        
        public FilterView() : base("FilterView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationItem.Title = "Apply Filter";
            //NavigationController.NavigationBar.BackItem.Title = "cancel";
            var saveButton = new UIBarButtonItem("Save",
                                                 UIBarButtonItemStyle.Done,
                                                 null);

            var cancelButton = new UIBarButtonItem();
            cancelButton.Title = "Cancel";

            var set = 


            NavigationItem.RightBarButtonItem = saveButton;
            NavigationItem.BackBarButtonItem = cancelButton;

            //CGRect frame = new CGRect(15, 15, View.Frame.Width - 15, View.Frame.Height - 15);


            int _xCoord = 5;
            int _yCoord = 5;
            int _buttonWidth = 70;
            int _buttonHeight = 70;
            int _gapBetweenButtons = 5;

            //int 

            for (int i = 0; i < CIFilterNames.Length; i++) {
                _itemCount = i;

                UIButton filterButton = new UIButton();
                filterButton.Frame = new CoreGraphics.CGRect(View.Frame.Width - 20, _yCoord, _buttonWidth, _buttonHeight);
                filterButton.Tag = _itemCount;
                filterButton.TouchUpInside += (sender, e) => FilterButtonTapped(filterButton);

                imageView = ResizeUIImage(UIImage.FromBundle("Image"), 350, 350);

                CIContext ciContext = new CIContext(null);
                CIImage coreImage = new CIImage((ResizeUIImage(imageView, 70, 70)));

                var filter = new CISepiaTone();
                filter.Image = coreImage;

                UIImage imageForButton = new UIImage(filter.Image.CreateByFiltering(CIFilterNames[i]));
                filterButton.SetBackgroundImage(imageForButton, UIControlState.Normal);

                _yCoord += _buttonHeight + _gapBetweenButtons;
                scrollview.AddSubview(filterButton);

            }

            scrollview.ContentSize = new CoreGraphics.CGSize(_buttonHeight * (float)_itemCount + 2, _xCoord);

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

        }

        public UIImage ResizeUIImage(UIImage sourceImage, float widthToScale, float heightToScale)
        {
            var sourceSize = sourceImage.Size;
            var maxResizeFactor = Math.Max(widthToScale / sourceSize.Width, heightToScale / sourceSize.Height);
            if (maxResizeFactor > 1) return sourceImage;
            var width = maxResizeFactor * sourceSize.Width;
            var height = maxResizeFactor * sourceSize.Height;
            UIGraphics.BeginImageContext(new CGSize(width, height));

            sourceImage.Draw(new CGRect(0, 0, width, height));
            var resultImage = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();
            return resultImage;

        }

        public void FilterButtonTapped(UIButton button)
        {
            button = button as UIButton;
            var filter = new CISepiaTone();
            CIImage coreImage = new CIImage((ResizeUIImage(imageView, 500, 500)));
            filter.Image = coreImage;

            image.Image = new UIImage(filter.Image.CreateByFiltering(CIFilterNames[button.Tag]));
        }

        public void SavePicButton(UIButton button)
        {
            UIImage _filteredImage = new UIImage();
            _filteredImage.SaveToPhotosAlbum((image, err2) => { 
                if (err2 != null) Console.WriteLine("error saving image: {0}", 
                err2); else Console.WriteLine("image saved to photo album"); });

            //UIImageWriteToSavedPhotosAlbum(image.Image, null, null, null);

            UIAlertController alert = UIAlertController.Create("Image filtered",
                                                       "Your image has been saved to your library",
                                                           UIAlertControllerStyle.Alert);

            alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));

            PresentViewController(alert, true, null);
        }

        NSString[] CIFilterNames = {
            (NSString)"CIPhotoEffectChrome",
            (NSString)"CIPhotoEffectFade",
            (NSString)"CIPhotoEffectInstant",
            (NSString)"CIPhotoEffectNoir",
            (NSString)"CIPhotoEffectProcess",
            (NSString)"CIPhotoEffectTonal",
            (NSString)"CIPhotoEffectTransfer",
            (NSString)"CISepiaTone"
        };
    }
}

