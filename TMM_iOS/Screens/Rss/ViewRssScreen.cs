using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using TMM_Core;

namespace TMM_iOS
{
	public partial class ViewRssScreen : UIViewController
	{
		private static ViewRssScreen _instance;

		public static ViewRssScreen GetInstance(RssFeedService service)
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

		private RssFeedService Service
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
		private RssFeedService _service;

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		private ViewRssScreen (RssFeedService service)
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
			NameLabel.Text = Service.Name;
			UrlLabel.Text = Service.Url;
		}

		partial void AddBtnPressed (NSObject sender)
		{
			TmmManager.Instance.CurrentUser.Services.Add(_service);
			NavigationController.PopViewControllerAnimated(true);
		}
	}
}

