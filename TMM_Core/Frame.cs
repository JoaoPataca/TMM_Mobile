using System;
using System.Collections.Generic;

namespace TMM_Core
{
	public class Frame
	{
		public string Name {get; private set;}
		public string Location { get; private set;}

		public Item CurrentItem { get; private set;}

		public IList<Service> Services { get; private set; }

		public Frame (string name, string location)
		{
			Name = name;
			Location = location;
		}

		/// <summary>
		/// So para teste!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		/// TIRAR ISTO DAQUI NA VERSAO FINAL!!!!!!!!!!!!!!!!!!!!!
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="location">Location.</param>
		/// <param name="item">Item.</param>
		public Frame(string name, string location, Item item)
		{
			Name = name;
			Location = location;
			CurrentItem = item;

			Services = new List<Service> ();
			Services.Add(new RssFeedService("Record","aaah pois"));
		}
	}
}