using System;
using MonoTouch.UIKit;
using TMM_Core;
using TMM.Core.iOS.Linked.TMM.Central;

namespace TMM_iOS
{
	public class EditServiceScreenSelector
	{
		private static EditServiceScreenSelector _instance;
		public static EditServiceScreenSelector Instance
		{
			get
			{
				if (_instance == null) 
				{
					_instance = new EditServiceScreenSelector ();
				} 
				return _instance;
			}
		}

		private EditServiceScreenSelector ()
		{
		}

		private UIViewController _editScreen;

		public UIViewController GetEditScreenFor(Service service)
		{
			return EditRssScreen.GetInstance (service);
		}
	}
}

