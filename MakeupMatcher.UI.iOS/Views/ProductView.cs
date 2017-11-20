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
using MvvmCross.Binding.iOS.Views;
using System.Collections.Generic;

namespace MakeupMatcher.UI.iOS.Views
{
    public partial class ProductView : MvxTableViewController<ProductViewModel>
    {
        private List<ProductModel> _productList;

        public ProductView() : base("ProductView", null)
        {
            _productList = new List<ProductModel>
            {
                new ProductModel { ProductId = 1, ProductBrand = "Pantone, because you're worth it", ProductName="Pantone Fresh & Fruity", ProductPrice= 20.05, Favorite=false},
                new ProductModel { ProductId = 2, ProductBrand = "Vichy", ProductName="Glossy skintone", ProductPrice= 19.56, Favorite=false},
                new ProductModel { ProductId = 3, ProductBrand = "Loreal Paris", ProductName="50 shades of brown", ProductPrice= 29.75, Favorite=false},
                new ProductModel { ProductId = 4, ProductBrand = "Vichy", ProductName="Peach Blossom", ProductPrice= 35.34, Favorite=false},
                new ProductModel { ProductId = 5, ProductBrand = "Dove", ProductName="Natural Beauty", ProductPrice= 14.56, Favorite=false},
            };
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationItem.Title = "Color results";

            /*var tableSource = new MvxStandardTableViewSource(
                                   TableView,
                                   UITableViewCellStyle.Default,
                                   new NSString("ItemCell"),
                "TitleText Title; ");

            TableView.Source = tableSource;

            var set = this.CreateBindingSet<ProductView, ProductViewModel>();

            set.Bind(tableSource).To(vm => vm.ProductName);
            set.Bind(tableSource).For(s => s.SelectionChangedCommand).To(s => s.ProductName);
            set.Apply();*/


        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            TableView.Source = new RootTableSource(_productList.ToArray());
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

