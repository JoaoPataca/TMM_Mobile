using System;

namespace TMM_Core
{
	public class RssFeedService : Service
	{
		public string Url;

		public RssFeedService (string name, string url)
			:base(name)
		{
			Url = url;
		}

		public override void Accept (ServicesVisitor visitor)
		{
			visitor.Visit (this);
		}
	}
}

