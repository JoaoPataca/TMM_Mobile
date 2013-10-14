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
	[Register ("NewServiceSelector")]
	partial class NewServiceSelector
	{
		[Outlet]
		MonoTouch.UIKit.UIPickerView ServiceTypeList { get; set; }

		[Action ("NextBtnPressed:")]
		partial void NextBtnPressed (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (ServiceTypeList != null) {
				ServiceTypeList.Dispose ();
				ServiceTypeList = null;
			}
		}
	}
}
