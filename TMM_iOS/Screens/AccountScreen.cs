using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using TMM_Core;
using System.Collections.Generic;
using TMM.Core.iOS.Linked.TMM.Central;

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
			var userServices = TmmManager.Instance.GetServicesForCurrentUser ();
			var startingTitleIndex = 0;
			if (userServices.Count > 0) {
				servicesList.Add (userServices);
				sectionTitles [0] = "My Services";
				startingTitleIndex++;
			}

			for (var i = 0; i < reachableFrames.Count; i++) 
			{
				servicesList.Add (reachableFrames [i].Services);
				sectionTitles [i + startingTitleIndex] = reachableFrames [i].Name + " Services";
			}

			ServicesTable.Source = new ServicesTableSource (servicesList, sectionTitles, this.NavigationController, startingTitleIndex == 1);
			ServicesTable.ReloadData ();
		}

		partial void LogOutBtnPressed (NSObject sender)
		{
			TmmManager.Instance.LogOut();
			NavigationController.PopViewControllerAnimated(true);
		}

		partial void AddServiceBtnPressed (NSObject sender)
		{
			this.NavigationController.PushViewController (new NewServiceSelector(), true);
		}
	}
}

