using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using TMM_Core;

namespace TMM_iOS
{
	public partial class FrameScreen : UIViewController
	{
		private static FrameScreen _instance;

		public static FrameScreen GetInstance()
		{
			if (_instance == null) 
			{
				_instance = new FrameScreen ();
			}
			return _instance;
		}

		public static FrameScreen GetInstance(Frame frame)
		{
			if (_instance == null) 
			{
				_instance = new FrameScreen (frame);
			} 
			else 
			{
				_instance.Frame = frame;
			}
			return _instance;
		}

		private Frame Frame
		{
			get
			{
				return _frame;
			}
			set
			{
				_frame = value;
				RefreshScreen ();
			}
		}

		private Frame _frame;
		private WebScreen _webScreen;

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		private FrameScreen (){}

		private FrameScreen (Frame frame)
			: base (UserInterfaceIdiomIsPhone ? "FrameScreen_iPhone" : "FrameScreen_iPad", null)
		{
			_frame = frame;
			_webScreen = new WebScreen ();
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
			var url = new NSUrl (_frame.CurrentItem.ImageUrl);
			var data = NSData.FromUrl (url);
			this.ItemImage.Image = UIImage.LoadFromData (data);

			this.ItemTitle.Text = _frame.CurrentItem.Title;
			this.ItemDescription.Text = _frame.CurrentItem.Description;
		}

		partial void TellMeMoreBtnPressed (NSObject sender)
		{
			_webScreen.Url = _frame.CurrentItem.Url;
			this.NavigationController.PushViewController (_webScreen, true);
		}
	}
}

