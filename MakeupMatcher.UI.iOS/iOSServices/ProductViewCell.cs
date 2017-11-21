using System;

using Foundation;
using UIKit;

namespace MakeupMatcher.UI.iOS.iOSServices
{
    public partial class ProductViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("ProductViewCell");
        public static readonly UINib Nib;

        static ProductViewCell()
        {
            Nib = UINib.FromName("ProductViewCell", NSBundle.MainBundle);
        }

        protected ProductViewCell(IntPtr handle) : base(handle)
        {
            product_image.Layer.CornerRadius = product_image.Frame.Size.Width / 2;
            product_image.ClipsToBounds = true;

            title.Font = UIFont.FromName("Helvetica-Bold", 24);
            subText.Font = UIFont.FromName("Helvetica", 18);
        }
    }
}
