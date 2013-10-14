using System;
using System.Collections.Generic;

namespace TMM_Core
{
	public class InvalidUsernameException : Exception
	{
		public string Username{ get; private set;}

		public InvalidUsernameException(string username)
		{
			Username = username;
		}
	}
}

