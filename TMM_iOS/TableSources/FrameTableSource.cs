using System;
using MonoTouch.UIKit;
using System.Collections.Generic;
using TMM_Core;

namespace TMM_iOS
{
	public class FrameTableSource : UITableViewSource 
	{
		private IList<Frame> _tableItems;
		private UINavigationController _navigationController;
		string cellIdentifier = "TableCell";

		public FrameTableSource (IList<Frame> items, UINavigationController navigationController)
		{
			_tableItems = items;
			_navigationController = navigationController;
		}

		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);
			// if there are no cells to reuse, create a new one
			if (cell == null)
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);
			cell.TextLabel.Text = _tableItems[indexPath.Row].Name;
			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
			return cell;
		}

		public override void RowSelected (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			_navigationController.PushViewController(FrameScreen.GetInstance (_tableItems [indexPath.Row]), true);
			tableView.DeselectRow (indexPath, true);
		}

		public override int NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return _tableItems.Count;
		}
	}
}