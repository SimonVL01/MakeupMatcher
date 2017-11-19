using System;
using Foundation;
using UIKit;
using MakeupMatcher.Core.Models;

namespace MakeupMatcher.UI.iOS.iOSServices
{
    public class RootTableSource : UITableViewSource
    {
        ProductModel[] _products;

        string _cellIdentifier = "productCell";

        public RootTableSource(ProductModel[] products)
        {
            _products = products;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _products.Length;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(_cellIdentifier);
            cell.TextLabel.Text = _products[indexPath.Row].ProductName;
            if (_products[indexPath.Row].Favorite) {
                cell.Accessory = UITableViewCellAccessory.Checkmark;
            } else {
                cell.Accessory = UITableViewCellAccessory.None;
            }
            return cell;
        }

        public ProductModel GetItem(int id)
        {
            return _products[id];
        }

    }
}