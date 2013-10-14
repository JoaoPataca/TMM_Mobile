using System;

namespace TMM_Core
{
	public abstract class Service
	{
		public string Name;

		public Service (string name)
		{
			Name = name;
		}

		public abstract void Accept(ServicesVisitor visitor);
	}
}

