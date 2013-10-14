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
	[Register ("NewRssScreen")]
	partial class NewRssScreen
	{
		[Outlet]
		MonoTouch.UIKit.UITextField NameField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField UrlField { get; set; }

		[Action ("AddBtnPressed:")]
		partial void AddBtnPressed (MonoTouch.Foundation.NSObject sender);
		
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
