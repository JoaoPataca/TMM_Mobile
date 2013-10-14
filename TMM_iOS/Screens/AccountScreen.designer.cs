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
	[Register ("LoginScreen")]
	partial class AccountScreen
	{
		[Outlet]
		MonoTouch.UIKit.UITableView ServicesTable { get; set; }

		[Action ("AddServiceBtnPressed:")]
		partial void AddServiceBtnPressed (MonoTouch.Foundation.NSObject sender);

		[Action ("LogOutBtnPressed:")]
		partial void LogOutBtnPressed (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (ServicesTable != null) {
				ServicesTable.Dispose ();
				ServicesTable = null;
			}
		}
	}
}
