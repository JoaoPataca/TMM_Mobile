using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TMM_iOS
{
	public partial class WebScreen : UIViewController
	{
		private string _url;
		public string Url
		{
			set
			{
				_url = value;
				if(_viewLoaded)
					RefreshScreen ();
			}
		}

		private bool _viewLoaded;

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public WebScreen ()
			: base (UserInterfaceIdiomIsPhone ? "WebScreen_iPhone" : "WebScreen_iPad", null)
		{
			_viewLoaded = false;
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
			_viewLoaded = true;
			RefreshScreen ();
		}

		private void RefreshScreen()
		{
			WebView.ScalesPageToFit = true;
			View.AddSubview(WebView);
			WebView.LoadRequest(new NSUrlRequest(new NSUrl(_url)));
		}
	}
}

