using System;
using System.Collections.Generic;

namespace TMM_Core
{
	public class UnknownUserException : Exception
	{
		public string Username{ get; private set;}

		public UnknownUserException(string username)
		{
			Username = username;
		}
	}
}

