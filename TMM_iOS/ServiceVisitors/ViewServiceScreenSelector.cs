using System;
using MonoTouch.UIKit;
using TMM_Core;

namespace TMM_iOS
{
	public class ViewServiceScreenSelector : ServicesVisitor
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
			service.Accept (this);
			return _editScreen;
		}

		public void Visit(RssFeedService service)
		{
			_editScreen = ViewRssScreen.GetInstance (service);
		}
	}
}

