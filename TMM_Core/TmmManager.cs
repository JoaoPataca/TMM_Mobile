using System;
using System.Collections.Generic;
using System.Threading;

namespace TMM_Core
{
	public class TmmManager
	{
		private static TmmManager _instance;

		public static TmmManager Instance
		{
			get
			{
				if (_instance == null) 
				{
					_instance = new TmmManager ();
				} 
				return _instance;
			}
		} 

		private TmmManager () 
		{
			_lastFrameFetch = new DateTime ();
			FRAME_FETCH_INTERVAL = new TimeSpan (0, 0, 30);
			KnownUsers = new Dictionary<string, User> ();
			//KnownUsers ["joao"] = new User("joao", "aa");
		}

		public TimeSpan FRAME_FETCH_INTERVAL;

		public User CurrentUser { get; private set; }
		public IDictionary<string, User> KnownUsers;

		private IList<Frame> _reachableFrames;
		private DateTime _lastFrameFetch;
		public IList<Frame> ReachableFrames
		{
			get
			{
				if (DateTime.Now.Subtract (_lastFrameFetch).TotalMilliseconds > 
				    FRAME_FETCH_INTERVAL.TotalMilliseconds) 
				{
					FetchFrames ();
					_lastFrameFetch = DateTime.Now;
				}
				return _reachableFrames;
			}
		}

		public void SignIn(string username, string password)
		{
			if (username.Equals (""))
				throw new InvalidUsernameException (username);
			if (password.Equals (""))
				throw new InvalidPasswordException (password);

			if (!KnownUsers.ContainsKey (username)) 
			{
				KnownUsers [username] = new User (username, password);
				CurrentUser = KnownUsers [username];
			} 
			else 
			{
				throw new UserAlreadyExistsExceptionCore (username);
			}
		}

		public void LogIn(string username, string password)
		{
			if (username.Equals (""))
				throw new InvalidUsernameException (username);
			if (password.Equals (""))
				throw new InvalidPasswordException (password);

			if (KnownUsers.ContainsKey (username)) 
			{
				if (KnownUsers [username].Password.Equals (password)) 
				{
					CurrentUser = KnownUsers [username];
				} else 
				{
					throw new WrongPasswordException (username);
				}
			} 
			else 
			{
				throw new UnknownUserException (username);
			}
		}

		public void LogOut()
		{
			CurrentUser = null;
		}

		public void FetchFrames()
		{
			//TODO just a stub for now

			var frame1 = new Frame ("ID_Screen1", "0.0.0.0", new Item("Egypt condemns US aid suspension", 
			                                                          "http://news.bbcimg.co.uk/media/images/70385000/jpg/_70385849_tank_afp.jpg",
			                                                          "Egypt's army-backed government condemns a decision by the US to suspend some of its financial and military aid over a crackdown on Islamists.",
			                                                          "http://www.bbc.co.uk/news/world-middle-east-24471148#sa-ns_mchannel=rss&amp;ns_source=PublicRSS20-sa"));

			var frame2 = new Frame ("ID_Screen2", "0.0.0.1", new Item("Computer chemists win Nobel prize", 
			                                                          "http://news.bbcimg.co.uk/media/images/70370000/jpg/_70370958_nobels.jpg",
			                                                          "The Nobel Prize in chemistry is awarded to three scientists, including a US-Israeli citizen, who \"took the chemical experiment into cyberspace\".",
			                                                          "http://www.bbc.co.uk/news/science-environment-24458534#sa-ns_mchannel=rss&amp;ns_source=PublicRSS20-sa"));

			var frameList = new List<Frame> ();
			frameList.Add (frame1);
			//frameList.Add (frame2);

			_reachableFrames = frameList;
		}
	}
}

