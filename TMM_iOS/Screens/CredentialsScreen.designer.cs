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
	[Register ("CredentialsScreen")]
	partial class CredentialsScreen
	{
		[Outlet]
		MonoTouch.UIKit.UITextField PasswordField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField UsernameField { get; set; }

		[Action ("LoginBtnPressed:")]
		partial void LoginBtnPressed (MonoTouch.Foundation.NSObject sender);

		[Action ("SignInBtnPressed:")]
		partial void SignInBtnPressed (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (UsernameField != null) {
				UsernameField.Dispose ();
				UsernameField = null;
			}

			if (PasswordField != null) {
				PasswordField.Dispose ();
				PasswordField = null;
			}
		}
	}
}
