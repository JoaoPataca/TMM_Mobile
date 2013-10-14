// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace TMM_iOS
{
	[Register ("EditRssScreen")]
	partial class EditRssScreen
	{
		[Outlet]
		MonoTouch.UIKit.UITextField NameField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField UrlField { get; set; }

		[Action ("CancelBtnPressed:")]
		partial void CancelBtnPressed (MonoTouch.Foundation.NSObject sender);

		[Action ("DoneBtnPressed:")]
		partial void DoneBtnPressed (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (NameField != null) {
				NameField.Dispose ();
				NameField = null;
			}

			if (UrlField != null) {
				UrlField.Dispose ();
				UrlField = null;
			}
		}
	}
}
