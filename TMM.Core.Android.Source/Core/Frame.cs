using System;
using System.Collections.Generic;

#if __ANDROID__
using TMM.Core.Android.Source.TMM.Central;
#elif __IOS__
using TMM.Core.iOS.Linked.TMM.Central;
#endif

namespace TMM_Core
{
	public class Frame
	{
		public string Name {get; private set;}
		public string Location { get; private set;}

		public Item CurrentItem { get; private set;}

		public List<Service> Services { get; private set;}

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
			var sampleService = new Service ();
			sampleService.owner = "an owner";
			sampleService.name = "Record";
			sampleService.url = "www.record.pt";
			Services.Add(sampleService);
		}
	}
}