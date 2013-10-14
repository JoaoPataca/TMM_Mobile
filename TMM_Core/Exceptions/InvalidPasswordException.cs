using System;
using System.Collections.Generic;

namespace TMM_Core
{
	public class InvalidPasswordException : Exception
	{
		public string Password{ get; private set;}

		public InvalidPasswordException(string password)
		{
			Password = password;
		}
	}
}

