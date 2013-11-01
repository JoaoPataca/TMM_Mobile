using System;
using System.Net;
using System.IO;

namespace TMM_Core
{
	public static class Network
	{
		private const int RETRIEVAL_INTERVAL = 60;

		private static string publicIp;
		private static DateTime lastRetrieval = DateTime.Now;

		public static string GetPublicIP()
		{
			if(publicIp == null ||
			   DateTime.Now.Subtract(lastRetrieval).TotalSeconds > RETRIEVAL_INTERVAL)
			{
				String direction = "";
				WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
				WebResponse response;
				try 
				{
					response = request.GetResponse ();
				} catch(WebException we) {
					response = we.Response;
				}
				StreamReader stream = new StreamReader (response.GetResponseStream ());
				direction = stream.ReadToEnd();

				//Search for the ip in the html
				int first = direction.IndexOf("Address: ") + 9;
				int last = direction.LastIndexOf("</body>");
				direction = direction.Substring(first, last - first);

				publicIp = direction;
				lastRetrieval = DateTime.Now;
			}
			return publicIp;
		}
	}
}

