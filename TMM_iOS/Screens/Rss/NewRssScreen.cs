using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using TMM_Core;

namespace TMM_iOS
{
	public partial class NewRssScreen : UIViewController
	{
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public NewRssScreen ()
			: base (UserInterfaceIdiomIsPhone ? "NewRssScreen_iPhone" : "NewRssScreen_iPad", null)
		{
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
			
			NameField.ShouldReturn += (textField) => { 
				textField.ResignFirstResponder();
				return true; 
			};

			UrlField.ShouldReturn += (textField) => { 
				textField.ResignFirstResponder();
				return true; 
			};
		}

		partial void AddBtnPressed (NSObject sender)
		{
			TmmManager.Instance.CurrentUser.Services.Add(new RssFeedService(NameField.Text, UrlField.Text));
			NavigationController.PopToViewController(AccountScreen.Instance, true);
		}
	}
}

