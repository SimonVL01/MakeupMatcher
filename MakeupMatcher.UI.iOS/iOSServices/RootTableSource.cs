using System;
using Foundation;
using UIKit;
using MakeupMatcher.Core.Models;

namespace MakeupMatcher.UI.iOS.iOSServices
{
    public class RootTableSource : UITableViewSource
    {
        //protected ProductModel[] _products;
        protected string[] _tableItems;
        protected string _cellIdentifier = "productCell";

        public RootTableSource(string[] tableItems)
        {
            _tableItems = tableItems;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _tableItems.Length;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(_cellIdentifier);
            if (cell == null) {
                cell = new UITableViewCell(UITableViewCellStyle.Default, _cellIdentifier);
                cell.TextLabel.Text = _tableItems[indexPath.Row];
            }
            return cell;

        }

        /*public ProductModel GetItem(int id)
        {
            return _products[id];
        }*/

    }
}