using Android;
using System;
using Android.Support.V7.Widget;
using Android.Widget;
using Android.Views;

namespace MakeupMatcher.UI.Droid.DroidServices
{
    public class ProductViewHolder : RecyclerView.ViewHolder
    {
        public ImageView Image { get; private set; }
        public TextView Caption { get; private set; }

        public ProductViewHolder(View itemView) : base(itemView)
        {
            Image = itemView.FindViewById<ImageView>(Resource.Id.profile);
            Caption = itemView.FindViewById<TextView>(Resource.Id.textView);
        }
    }
}