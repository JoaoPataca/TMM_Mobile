using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using TMM_Core;
using TMM_iOS.remote;

namespace TMM_iOS
{
	public partial class CredentialsScreen : UIViewController
	{
		private static CredentialsScreen _instance;
		private TmmService _tmm;

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
			_tmm = new TmmService ();
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
				var user = _tmm.signIn(UsernameField.Text, PasswordField.Text, "100.100.100.1");
				//TmmManager.Instance.SignIn(UsernameField.Text, PasswordField.Text);
				//PopAndPushAccountView();
			}
			catch(InvalidUsernameException)
			{
				UIAlertView _error = new UIAlertView ("Invalid username", "The field \'Username\' cannot be left blank.", null, "Ok", null);
				_error.Show ();
			}
			catch(InvalidPasswordException)
			{
				UIAlertView _error = new UIAlertView ("Invalid password", "The field \'Password\' cannot be left blank.", null, "Ok", null);
				_error.Show ();
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
				PopAndPushAccountView();
			}
			catch(InvalidUsernameException)
			{
				UIAlertView _error = new UIAlertView ("Invalid username", "The field \'Username\' cannot be left blank.", null, "Ok", null);
				_error.Show ();
			}
			catch(InvalidPasswordException)
			{
				UIAlertView _error = new UIAlertView ("Invalid password", "The field \'Password\' cannot be left blank.", null, "Ok", null);
				_error.Show ();
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

