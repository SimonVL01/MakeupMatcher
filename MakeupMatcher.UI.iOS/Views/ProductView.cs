using System;
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
using System.Collections.Generic;
using MvvmCross.Binding.iOS.Views;

namespace MakeupMatcher.UI.iOS.Views
{
    public partial class ProductView : MvxViewController<ProductViewModel>
    {
        // private ProductModel[] _productList;
        private string[] _tableItems;
        private UITableView tableView;

        public ProductView() : base("ProductView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationItem.Title = "ColorMatch results";

            _tableItems = new string[]
            {
                "Pantone",
                "Vichy",
                "Loreal",
                "Vichy",
                "Dove"
            };

            /*_productList = new ProductModel[]             {                 new ProductModel(1, "Pantone, because you're worth it", "Pantone Fresh & Fruity", 20.05, false),                 new ProductModel(2, "Vichy", "Glossy skintone", 19.56, false),                 new ProductModel(3, "Loreal Paris", "50 shades of brown", 29.75, false),                 new ProductModel(4, "Vichy", "Cherry Blossom", 35.34, false),                 new ProductModel(5, "Dove", "Natural Beauty", 14.56, false),             };*/

            tableView = new UITableView(View.Bounds);
            Add(tableView);

            tableView.Source = new RootTableSource(_tableItems); 
        }

        public override void ViewWillAppear(bool animated)         {             base.ViewWillAppear(animated);

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

        }
    }
}

