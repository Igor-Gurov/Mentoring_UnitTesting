using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;

namespace Proxy
{
	public class ProxyHttpHandler : IHttpHandler, IRequiresSessionState
	{
		public ProxyHttpHandler()
		{
 
		}

		public bool IsReusable
		{
			get
			{
				return true;
			}
		}

		public void ProcessRequest(HttpContext context)
		{
			string query;
			if (CheckUrl(context.Request.Url))
			{
				query = context.Request.Url.Query.Remove(0, 1);
			}
			else
			{
				query = context.Request.Url.AbsoluteUri;
			}
			
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(query);
			//context.Session["Responce"] = request.GetResponse();
			HttpWebResponse responce = (HttpWebResponse)request.GetResponse();
			Stream stream = responce.GetResponseStream();
			Encoding encode = Encoding.GetEncoding(responce.CharacterSet);
			StreamReader readStream = new StreamReader(stream, encode);
			Char[] readChar = new Char[256];
			int count = readStream.Read(readChar, 0, 256);
			while (count > 0)
			{
				context.Response.Write(new string(readChar, 0, count));
				count = readStream.Read(readChar, 0, 256);
			}
			readStream.Close();

		}

		private bool CheckUrl(Uri url)
		{
			Regex reg = new Regex(@"\w[.prx]");
			return reg.IsMatch(url.AbsoluteUri);
		}
	}
}