using Android;
using System;
using Android.Support.V7.Widget;
using Android.Widget;
using Android.Views;
using MakeupMatcher.UI.Droid.Views;
using Android.Content;

namespace MakeupMatcher.UI.Droid.DroidServices
{
    public class ProductViewHolder : RecyclerView.ViewHolder
    {
        public ImageView Image { get; set; }
        public TextView Caption { get; set; }
        public TextView SubView { get; set; }
        public CardView cellView { get; set; }

        public ProductViewHolder(View itemView) : base(itemView)
        {
            Image = itemView.FindViewById<ImageView>(Resource.Id.profile);
            Caption = itemView.FindViewById<TextView>(Resource.Id.textView);
            SubView = itemView.FindViewById<TextView>(Resource.Id.subText);
            cellView = itemView.FindViewById<CardView>(Resource.Id.cell);

            cellView.Click += (sender, e) => 
            {
                var context = cellView.Context;
                var intent = new Intent(context, typeof(ProductDetailView));
                intent.PutExtra("Name", Caption.Text);
                intent.PutExtra("Brand", SubView.Text);
                context.StartActivity(intent);
            };
        }
    }
}