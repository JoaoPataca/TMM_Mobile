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
	[Register ("SelectScreenScreen")]
	partial class SelectFrameScreen
	{
		[Outlet]
		MonoTouch.UIKit.UITableView FrameList { get; set; }

		[Action ("AccountBtnPressed:")]
		partial void AccountBtnPressed (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (FrameList != null) {
				FrameList.Dispose ();
				FrameList = null;
			}
		}
	}
}
