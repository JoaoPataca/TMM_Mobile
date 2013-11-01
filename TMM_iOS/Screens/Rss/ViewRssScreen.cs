using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using TMM_Core;
using TMM.Core.iOS.Linked.TMM.Central;

namespace TMM_iOS
{
	public partial class ViewRssScreen : UIViewController
	{
		private static ViewRssScreen _instance;

		public static ViewRssScreen GetInstance(Service service)
		{
			if (_instance == null) 
			{
				_instance = new ViewRssScreen (service);
			} 
			else 
			{
				_instance.Service = service;
			}
			return _instance;
		}

		private Service Service
		{
			get
			{
				return _service;
			}
			set
			{
				_service = value;
				RefreshScreen ();
			}
		}
		private Service _service;

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		private ViewRssScreen (Service service)
			: base (UserInterfaceIdiomIsPhone ? "ViewRssScreen_iPhone" : "ViewRssScreen_iPad", null)
		{
			_service = service;
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
			
			RefreshScreen ();
		}

		private void RefreshScreen()
		{
			NameLabel.Text = Service.name;
			UrlLabel.Text = Service.url;
		}

		partial void AddBtnPressed (NSObject sender)
		{
			TmmManager.Instance.AddService(Service.name, Service.url);
			NavigationController.PopViewControllerAnimated(true);
		}
	}
}

