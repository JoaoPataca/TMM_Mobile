using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using TMM_Core;
using TMM.Core.iOS.Linked.TMM.Central;

namespace TMM_iOS
{
	public partial class EditRssScreen : UIViewController
	{
		private static EditRssScreen _instance;

		public static EditRssScreen GetInstance(Service service)
		{
			if (_instance == null) 
			{
				_instance = new EditRssScreen (service);
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

		private EditRssScreen (Service service)
			: base (UserInterfaceIdiomIsPhone ? "EditRssScreen_iPhone" : "EditRssScreen_iPad", null)
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

			NameField.ShouldReturn += (textField) => { 
				textField.ResignFirstResponder();
				return true; 
			};

			UrlField.ShouldReturn += (textField) => { 
				textField.ResignFirstResponder();
				return true; 
			};

			RefreshScreen ();
		}

		private void RefreshScreen()
		{
			NameField.Text = Service.name;
			UrlField.Text = Service.url;
		}

		partial void CancelBtnPressed (NSObject sender)
		{
			UIAlertView _error = new UIAlertView ("Remove service", "Are you sure you want to remove the service \"" + _service.name + "\"?", 
			                                      null, "No", new string[]{"Yes"});
			_error.Show ();
			_error.Clicked += (object clickedSender, UIButtonEventArgs e) => {
				if(e.ButtonIndex != 0)
				{
					TmmManager.Instance.RemoveService(Service);
					NavigationController.PopViewControllerAnimated(true);
				}
			};
		}

		partial void DoneBtnPressed (NSObject sender)
		{
			_service.name = NameField.Text;
			_service.url = UrlField.Text;
			TmmManager.Instance.UpdateService(_service);
			NavigationController.PopViewControllerAnimated(true);
		}
	}
}

