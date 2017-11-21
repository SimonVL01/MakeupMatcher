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
using MakeupMatcher.Core.Services;

namespace MakeupMatcher.UI.iOS.Views
{
    public partial class ProductView : MvxViewController<ProductViewModel>
    {
        //private ProductModel[] _productList;
        //private string[] _tableItems;
        private UITableView tableView;

        public ProductView() : base("ProductView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationItem.Title = "ColorMatch results";

            tableView = new UITableView(View.Bounds);
            Add(tableView);

            tableView.DequeueReusableCell("ProductViewCell");
            tableView.Source = new RootTableSource(ProductList.GetProductList); 
        }

        public override void ViewWillAppear(bool animated)         {             base.ViewWillAppear(animated);

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

        }
    }
}

