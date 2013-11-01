using System;
using MonoTouch.UIKit;
using System.Collections.Generic;
using TMM_Core;
using TMM.Core.iOS.Linked.TMM.Central;

namespace TMM_iOS
{
	public class ServicesTableSource : UITableViewSource 
	{
		private IList<IList<Service>> _services;
		private string[] _sectionTitles;

		private UINavigationController _navigationController;
		string cellIdentifier = "TableCell";
		private bool _hasUserServices;

		public ServicesTableSource (IList<IList<Service>> services, string[] sectionTitles, UINavigationController navigationController,
		                            bool hasUserServices)
		{
			_services = services;
			_sectionTitles = sectionTitles;
			_navigationController = navigationController;
			_hasUserServices = hasUserServices;
		}

		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);
			// if there are no cells to reuse, create a new one
			if (cell == null)
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);
			cell.TextLabel.Text = _services[indexPath.Section][indexPath.Row].name;
			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
			return cell;
		}

		public override void RowSelected (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			if (_hasUserServices && indexPath.Section == 0) {
				_navigationController.PushViewController (EditServiceScreenSelector.Instance.GetEditScreenFor (_services [indexPath.Section] [indexPath.Row]), true);
			} 
			else 
			{
				_navigationController.PushViewController (ViewServiceScreenSelector.Instance.GetEditScreenFor (_services [indexPath.Section] [indexPath.Row]), true);
			}
			tableView.DeselectRow (indexPath, true);
		}

		public override int NumberOfSections (UITableView tableView)
		{
			return _services.Count;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return _services [section].Count;
		}

		public override string TitleForHeader (UITableView tableView, int section)
		{
			return _sectionTitles[section];
		}
	}
}

