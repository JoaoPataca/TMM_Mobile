using System;
using MonoTouch.UIKit;
using TMM_Core;
using TMM.Core.iOS.Linked.TMM.Central;

namespace TMM_iOS
{
	public class ViewServiceScreenSelector
	{
		private static ViewServiceScreenSelector _instance;
		public static ViewServiceScreenSelector Instance
		{
			get
			{
				if (_instance == null) 
				{
					_instance = new ViewServiceScreenSelector ();
				} 
				return _instance;
			}
		}

		private ViewServiceScreenSelector ()
		{
		}

		private UIViewController _editScreen;

		public UIViewController GetEditScreenFor(Service service)
		{
			return ViewRssScreen.GetInstance (service);
		}
	}
}

