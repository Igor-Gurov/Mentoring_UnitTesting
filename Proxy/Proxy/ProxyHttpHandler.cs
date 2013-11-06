using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
				return false;
			}
		}

		public void ProcessRequest(HttpContext context)
		{
			string query = context.Request.Url.Query.Remove(0,1);
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(query);
			context.Session["Responce"] = request.GetResponse();
			//HttpWebResponse responce = (HttpWebResponse)request.GetResponse();
		}
	}
}