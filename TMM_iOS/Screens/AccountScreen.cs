using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using TMM_Core;
using System.Collections.Generic;

namespace TMM_iOS
{
	public partial class AccountScreen : UIViewController
	{
		private static AccountScreen _instance;

		public static AccountScreen Instance
		{
			get
			{
				if (_instance == null) 
				{
					_instance = new AccountScreen ();
				} 
				return _instance;
			}
		}

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		private AccountScreen ()
			: base (UserInterfaceIdiomIsPhone ? "AccountScreen_iPhone" : "AccountScreen_iPad", null)
		{
			Title = "My Account";
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			RefreshData ();
		}

		public override void ViewWillAppear (bool animated)
		{
			RefreshData ();
		}

		private void RefreshData()
		{
			var reachableFrames = TmmManager.Instance.ReachableFrames;
			var servicesList = new List<IList<Service>> ();
			var sectionTitles = new string[1 + reachableFrames.Count];
			servicesList.Add (TmmManager.Instance.CurrentUser.Services);
			sectionTitles [0] = "My Services";

			for (var i = 0; i < reachableFrames.Count; i++) 
			{
				servicesList.Add (reachableFrames [i].Services);
				sectionTitles [i + 1] = reachableFrames [i].Name + " Services";
			}

			ServicesTable.Source = new ServicesTableSource (servicesList, sectionTitles, this.NavigationController);
			ServicesTable.ReloadData ();
		}

		partial void AddServiceBtnPressed (NSObject sender)
		{
			this.NavigationController.PushViewController (new NewServiceSelector(), true);
		}
	}
}

