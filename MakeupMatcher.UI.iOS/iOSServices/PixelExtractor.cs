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
            int BitmapBytesPerPixel = 4;
            int BitmapPerComponent = BitmapBytesPerPixel * 2;

            var IntBytes = PixelsWide * PixelsHigh * BitmapBytesPerPixel;
            var ColorSpace = CGColorSpace.CreateDeviceRGB();
            byte[] PixelData = new byte[IntBytes];

            CGContext Context = new CGBitmapContext(PixelData, PixelsWide, PixelsHigh, BitmapPerComponent, PixelsWide * BitmapBytesPerPixel, ColorSpace, CGImageAlphaInfo.First);

            CGRect Rect = new CGRect(0, 0, PixelsWide, PixelsHigh);
            Context.DrawImage(Rect, Image);

            return Context;
        }/*

        //public UIColor GetPixelColorAtPoint(CGPoint point, UIView sourceView) {
            //var Pixel = sourceView.;
            /*var ColorSpace2 = CGColorSpace.CreateDeviceRGB();
            var BitmapInfo = new CGBitmapContext(4, 1, 1, 8, 4, ColorSpace2, CGImageAlphaInfo.First);

            Context.TranslateCTM(point.X, point.Y);
            sourceView.Layer.RenderInContext(Context);
            UIColor Color = new UIColor((Pixel[0]) / 255.0,
                                        (Pixel[1]) / 255.0,
                                        (Pixel[2]) / 255.0,
                                        (Pixel[3]) / 255.0);

            Pixel.Deallocate(4);

            return Color;*/

            /*byte[] alphaPixel = { 0, 0, 0, 0 };
            protected UIColor GetColorAtTouchPoint(CGPoint Point)
            {
                var colorSpace = CGColorSpace.CreateDeviceRGB();
                var bitmapContext = new CGBitmapContext(alphaPixel, 1, 1, 8, 4, colorSpace, CGBitmapFlags.PremultipliedLast);
                bitmapContext.TranslateCTM(-Point.X, -Point.Y);
                View.Layer.RenderInContext(bitmapContext);
                return UIColor.FromRGBA(alphaPixel[0], alphaPixel[1], alphaPixel[2], alphaPixel[3]);
            }
        //}

    }        
}*/