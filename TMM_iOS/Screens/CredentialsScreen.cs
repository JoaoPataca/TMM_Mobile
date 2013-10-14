using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using TMM_Core;

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
				this.NavigationController.PushViewController (AccountScreen.Instance, true);
			}
			catch(UserAlreadyExistsException uaee)
			{
				UIAlertView _error = new UIAlertView ("User already exists", "A user with the name \"" + uaee.Username + "\" already exists. " +
					"Please choose a different username.", null, "Ok", null);
				_error.Show ();
			}
		}

		partial void LoginBtnPressed (NSObject sender)
		{
			try
			{
				TmmManager.Instance.LogIn(UsernameField.Text, PasswordField.Text);
				this.NavigationController.PushViewController (AccountScreen.Instance, true);
			}
			catch(UnknownUserException uue)
			{
				UIAlertView _error = new UIAlertView ("Unknown user", "There is no user with the name \"" + uue.Username + "\".", null, "Ok", null);
				_error.Show ();
			}
			catch(WrongPasswordException wpe)
			{
				UIAlertView _error = new UIAlertView ("Wrong password", "The password provided for the user \"" + wpe.Username + "\" is incorrect.", null, "Ok", null);
				_error.Show ();
			}
		}
	}
}

