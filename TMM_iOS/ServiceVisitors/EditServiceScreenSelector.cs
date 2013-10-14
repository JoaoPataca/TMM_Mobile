using System;
using MonoTouch.UIKit;
using TMM_Core;

namespace TMM_iOS
{
	public class EditServiceScreenSelector : ServicesVisitor
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
			service.Accept (this);
			return _editScreen;
		}

		public void Visit(RssFeedService service)
		{
			_editScreen = EditRssScreen.GetInstance (service);
		}
	}
}

