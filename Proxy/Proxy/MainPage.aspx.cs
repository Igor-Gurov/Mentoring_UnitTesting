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
			Server.TransferRequest("~/PrxReq.prx?" + inpAddress.Value);
		}
	}
}