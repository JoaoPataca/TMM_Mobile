using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TMM_iOS
{
	public partial class NewServiceSelector : UIViewController
	{
		public readonly string[] Services = { "RSS", "Facebook", "Twitter" };

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public NewServiceSelector ()
			: base (UserInterfaceIdiomIsPhone ? "NewServiceSelector_iPhone" : "NewServiceSelector_iPad", null)
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
			
			ServiceTypeList.Model = new ServicePickerViewModel (this);
		}

		partial void NextBtnPressed (NSObject sender)
		{
			this.NavigationController.PushViewController (new NewRssScreen(), true);
		}

		public class ServicePickerViewModel : UIPickerViewModel
		{
			private NewServiceSelector _nss;

			public ServicePickerViewModel(NewServiceSelector nss)
			{
				_nss = nss;
			}

			public override int GetComponentCount (UIPickerView picker)
			{
				return 1;
			}

			public override int GetRowsInComponent (UIPickerView picker, int component)
			{
				return _nss.Services.Length;
			}

			public override string GetTitle (UIPickerView picker, int row, int component)
			{
				return _nss.Services [row];
			}
		}
	}
}

