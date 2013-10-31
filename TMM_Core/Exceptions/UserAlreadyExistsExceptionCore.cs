using System;
using System.Collections.Generic;

namespace TMM_Core
{
	public class UserAlreadyExistsExceptionCore : Exception
	{
		public string Username{ get; private set;}

		public UserAlreadyExistsExceptionCore(string username)
		{
			Username = username;
		}
	}
}

