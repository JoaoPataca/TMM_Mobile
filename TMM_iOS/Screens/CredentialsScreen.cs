using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using TMM_Core;
using System.Web.Services.Protocols;

namespace TMM_iOS
{
	public partial class CredentialsScreen : UIViewController
	{
		private static CredentialsScreen _instance;

		public static CredentialsScreen Instance
		{
			get
			{
				if (_instance == null) 
				{
					_instance = new CredentialsScreen ();
				} 
				return _instance;
			}
		}

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public CredentialsScreen ()
			: base (UserInterfaceIdiomIsPhone ? "CredentialsScreen_iPhone" : "CredentialsScreen_iPad", null)
		{
			Title = "Account";
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
			
			UsernameField.ShouldReturn += (textField) => { 
				textField.ResignFirstResponder();
				return true; 
			};

			PasswordField.ShouldReturn += (textField) => { 
				textField.ResignFirstResponder();
				return true; 
			};
		}

		partial void SignInBtnPressed (NSObject sender)
		{
			try
			{
				TmmManager.Instance.SignIn(UsernameField.Text, PasswordField.Text);
				PopAndPushAccountView();
			}
			catch(SoapException se)
			{
				UIAlertView _error = new UIAlertView ("", se.Message, null, "OK", null);
				_error.Show ();
			}
			catch(InvalidUsernameException)
			{
				UIAlertView _error = new UIAlertView ("Invalid username", "The field \'Username\' cannot be left blank.", null, "OK", null);
				_error.Show ();
			}
			catch(InvalidPasswordException)
			{
				UIAlertView _error = new UIAlertView ("Invalid password", "The field \'Password\' cannot be left blank.", null, "OK", null);
				_error.Show ();
			}
		}

		partial void LoginBtnPressed (NSObject sender)
		{
			try
			{
				TmmManager.Instance.LogIn(UsernameField.Text, PasswordField.Text);
				PopAndPushAccountView();
			}
			catch(SoapException se)
			{
				UIAlertView _error = new UIAlertView ("", se.Message, null, "OK", null);
				_error.Show ();
			}
			catch(InvalidUsernameException)
			{
				UIAlertView _error = new UIAlertView ("Invalid username", "The field \'Username\' cannot be left blank.", null, "OK", null);
				_error.Show ();
			}
			catch(InvalidPasswordException)
			{
				UIAlertView _error = new UIAlertView ("Invalid password", "The field \'Password\' cannot be left blank.", null, "OK", null);
				_error.Show ();
			}
		}

		private void PopAndPushAccountView()
		{
			var viewControllers = NavigationController.ViewControllers;
			var newViewControllers = new UIViewController[viewControllers.Length-1];
			for(var i = 0; i < viewControllers.Length-1; i++)
			{
				newViewControllers[i] = viewControllers[i];
			}
			var navigationController = this.NavigationController;
			this.NavigationController.ViewControllers = newViewControllers;
			navigationController.PushViewController (AccountScreen.Instance, true);
		}
	}
}

