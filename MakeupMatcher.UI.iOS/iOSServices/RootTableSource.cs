using System;
using Foundation;
using UIKit;
using MakeupMatcher.Core.Models;
using MakeupMatcher.Core.Services;
using MakeupMatcher.UI.iOS.Views;

namespace MakeupMatcher.UI.iOS.iOSServices
{
    public class RootTableSource : UITableViewSource
    {
        protected ProductModel[] _products;
        protected ProductView _productView;
        protected string[] _tableItems;
        protected string _cellIdentifier = "ProductViewCell";

        public RootTableSource(ProductModel[] products)
        {
            _products = products;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return ProductList.GetProductList.Length;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(_cellIdentifier);
            if (cell == null) {
                cell = new UITableViewCell(UITableViewCellStyle.Value2, _cellIdentifier);
                cell.TextLabel.Text = _products[indexPath.Row].ProductName;
                cell.DetailTextLabel.Text = _products[indexPath.Row].ProductBrand;
            }
            return cell;

        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath) {
            UIAlertController okAlertController = UIAlertController.Create("Row Selected",
                                                  _products[indexPath.Row].ProductName,
                                                  UIAlertControllerStyle.Alert);
            okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
            _productView.PresentViewController(okAlertController, true, null);

            tableView.DeselectRow(indexPath, true);
        }
    }
}