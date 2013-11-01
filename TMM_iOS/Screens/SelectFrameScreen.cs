using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Threading;
using TMM_Core;
using System.Collections.Generic;

namespace TMM_iOS
{
	public partial class SelectFrameScreen : UIViewController
	{
		private LoadingOverlay loadingOverlay;
		private delegate void FramesFetchedHandler ();

			private event FramesFetchedHandler OnFramesFetched;

			private IList<Frame> Frames;
			private FrameScreen _frameScreen;

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public SelectFrameScreen ()
			: base (UserInterfaceIdiomIsPhone ? "SelectFrameScreen_iPhone" : "SelectFrameScreen_iPad", null)
		{
			Title = "Frames";
			OnFramesFetched += () => {
				InvokeOnMainThread (() => {
					if (Frames.Count == 1) {
						LoadFrameScreen (Frames [0]);
					}
					UpdateTable ();
				});};
			OnFramesFetched += HideLoadingOverlay;
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewWillAppear (bool animated)
		{
			if(TmmManager.Instance.CurrentUser == null)
			{
				AccountBtn.Title = "Account";
			}
			else
			{
				AccountBtn.Title = "Logged in as: " + TmmManager.Instance.CurrentUser.name;
			}
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Bring up loading overlay
			loadingOverlay = new LoadingOverlay ("Looking for available frames...");
			View.Add (loadingOverlay);

			// Look for available frames
			ThreadPool.QueueUserWorkItem (o => FetchFrames());
		}

		private void FetchFrames()
		{
			Thread.Sleep (1000);
			Frames = TmmManager.Instance.ReachableFrames;
			FramesFetched ();
		}

		private void FramesFetched()
		{
			if (OnFramesFetched != null) 
			{
				OnFramesFetched ();
			}
		}

		private void UpdateTable()
		{
			FrameList.Source = new FrameTableSource(Frames, this.NavigationController); 
			FrameList.ReloadData();
		}

		private void HideLoadingOverlay()
		{
			loadingOverlay.Hide ();
		}

		private void LoadFrameScreen(Frame frame)
		{
			_frameScreen = FrameScreen.GetInstance(frame);
			this.NavigationController.PushViewController (_frameScreen, true);
		}

		partial void AccountBtnPressed (NSObject sender)
		{
			if(TmmManager.Instance.CurrentUser == null)
			{
				this.NavigationController.PushViewController (CredentialsScreen.Instance, true);
			}
			else
			{
				this.NavigationController.PushViewController (AccountScreen.Instance, true);
			}
		}
	}
}

