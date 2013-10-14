using System;
using System.Collections.Generic;

namespace TMM_Core
{
	public class WrongPasswordException : Exception
	{
		public string Username{ get; private set;}

		public WrongPasswordException(string username)
		{
			Username = username;
		}
	}
}

