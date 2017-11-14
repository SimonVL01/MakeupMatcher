/*using Foundation;
using CoreGraphics;
using UIKit;

namespace MakeupMatcher.UI.iOS.iOSServices
{
    public class PixelExtractor : NSObject
    {
        //Global variables

        CGImage _image;

        public CGImage Image
        {
            get { return _image; }
            set
            {
                _image = value;
            }
        }

        CGContext _context;

        public CGContext Context
        {
            get { return _context; }
            set
            {
                _context = value;
            }
        }

        public PixelExtractor(CGImage Image)
        {
            _image = Image;
            //Context = 
        }

        public CGContext CreateBitmapContext(CGImage Image) {
            int PixelsWide = (int)Image.Width;
            int PixelsHigh = (int)Image.Height;

            int BitmapBytesPerRow = PixelsWide * 4;
            int BitmapByteCount = BitmapBytesPerRow * PixelsHigh;

            CGColorSpace colorSpace = new CGColorSpaceCreateDeviceRGB();

            var BitmapData = new Malloc(BitmapData);
            var BitmapInfo = new CGBitmapInfo(CGImageAlphaInfo.PremultipliedFirst);
            var Size = new CGSize(PixelsWide, PixelsHigh);
            UIGraphicsBeginImageContextWithOptions(Size, false, 0.0);

            CGContext Context = new CGContext(BitmapData,
                                          PixelsWide, PixelsHigh, 8, BitmapBytesPerRow, colorSpace, BitmapInfo);

            CGRect Rect = new CGRect(0, 0, PixelsWide, PixelsHigh);
            Context.DrawImage(Image, Rect);

            return Context;
        }

        public UIColor GetPixelColorAtPoint(CGPoint point, UIView sourceView) {
            var Pixel = new UnsafeMutablePointer<char>.Allocate(4);
            var ColorSpace = new CGColorSpaceCreateDeviceRGB();
            var BitmapInfo = CGBitmapContext(Pixel, 1, 1, 8, 4, ColorSpace, BitmapInfo);

            Context.TranslateCTM(NSLayoutXAxisAnchor, NSLayoutYAxisAnchor);
            sourceView.Layer.RenderInContext(Context);
            UIColor Color = new UIColor((Pixel[0]) / 255.0,
                                        (Pixel[1]) / 255.0,
                                        (Pixel[2]) / 255.0,
                                        (Pixel[3]) / 255.0);

            Pixel.Deallocate(4);

            return Color;
        }

    }        
}*/