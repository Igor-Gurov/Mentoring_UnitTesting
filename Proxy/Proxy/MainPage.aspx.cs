using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proxy
{
	public partial class MainPage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void btnConfirm_Click(object sender, EventArgs e)
		{
			//HttpWebRequest request = WebRequest.CreateHttp(inpAddress.Value);
			//HttpWebResponse response = (HttpWebResponse)request.GetResponse();

			HttpRequest request = new HttpRequest("ProxyHttpHandler.cs", inpAddress.Value, null);
			HttpResponse response = Context.Response;
			HttpContext context = new HttpContext(request, response);
			ProxyHttpHandler proxy = new ProxyHttpHandler();
			proxy.ProcessRequest(context);
		}
	}
}