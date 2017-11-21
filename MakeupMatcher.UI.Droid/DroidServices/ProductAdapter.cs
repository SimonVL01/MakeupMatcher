using System;
using Android.Support.V7.Widget;
using Android.Views;
using MakeupMatcher.Core.Models;
using MakeupMatcher.Core.Services;

namespace MakeupMatcher.UI.Droid.DroidServices
{
    public class ProductAdapter : RecyclerView.Adapter
    {
        public ProductModel _productModel;

        public override int ItemCount => ProductList.GetProductList.Length;
        //Awaiting mockup data

        public ProductAdapter(ProductModel productModel)
        {
            _productModel = productModel;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context)
                            .Inflate(Resource.Layout.ProductCardView, parent, false);

            ProductViewHolder vh = new ProductViewHolder(itemView);
            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ProductViewHolder vh = holder as ProductViewHolder;

            vh.Image.SetImageResource(Resource.Drawable.profile_pic);

            vh.Caption.Text = ProductList.GetProductList[position].ProductName;
            vh.SubView.Text = ProductList.GetProductList[position].ProductBrand;
        }

    }
}