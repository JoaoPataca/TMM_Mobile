using System;

namespace TMM_Core
{
	public class Item
	{
		public string Title { get; private set;}
		public string ImageUrl { get; private set;}
		public string Description { get; private set;}
		public string Url { get; private set;}

		public Item (string title, string imageUrl, string description, string url)
		{
			Title = title;
			ImageUrl = imageUrl;
			Description = description;
			Url = url;
		}
	}
}