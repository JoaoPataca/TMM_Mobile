using System;
using System.Collections.Generic;

namespace TMM_Core
{
	public class UserAlreadyExistsException : Exception
	{
		public string Username{ get; private set;}

		public UserAlreadyExistsException(string username)
		{
			Username = username;
		}
	}
}

