using System;
using System.Collections.Generic;

namespace TMM_Core
{
	public class User
	{
		public string Name { get; private set; }
		public string Password { get; private set; }
		public IList<Service> Services { get; private set;}

		public User (string name, string password)
		{
			Name = name;
			Password = password;
			Services = new List<Service> ();
			Services.Add(new RssFeedService("A Bola", "aaaa"));
		}
	}
}

