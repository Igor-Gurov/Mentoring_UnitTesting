using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;
using HtmlAgilityPack;

namespace ProxyServer
{
	/// <summary>
	/// ProxyHandler
	/// </summary>
	public class ProxyHandler : IHttpHandler
	{
		private string UrlSite;

		public void ProcessRequest(HttpContext context)
		{
			string url = context.Request.QueryString["url"];

			if (!url.Contains(@"http:") && !url.Contains(@"https:"))
				url = @"http://" + url;

			if (url.Contains("?"))
				url = url.Substring(0, url.IndexOf("?"));

			UrlSite = ReturnUrlSite(url);

			string responseFromServer = this.GetResponseString(url);
			string cachedResponse;

			cachedResponse = MakeProxyResponse(responseFromServer);

			context.Response.Write(cachedResponse);
		}

		private string GetResponseString(string url)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			WebResponse response = request.GetResponse();
			Stream dataStream = response.GetResponseStream();
			StreamReader reader = new StreamReader(dataStream);
			string responseFromServer = reader.ReadToEnd();
			reader.Close();
			dataStream.Close();
			response.Close();
			return responseFromServer;
		}

		private string MakeProxyResponse(string response)
		{
			HtmlAgilityPack.HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(response);

			SaveReferences(ref response, "a", "href", doc);
			return response;
		}

		private void SaveReferences(ref string cachedResponse, string SearchedTag, string SearchedAttribute, HtmlAgilityPack.HtmlDocument doc)
		{
			var references = doc.DocumentNode.SelectNodes("//" + SearchedTag + "[@" + SearchedAttribute + "]");
			if (references == null)
				return;
			foreach (var reference in references)
			{
				string refUrl = reference.Attributes[SearchedAttribute].Value;
				string originalUrl;
				if (refUrl.Length == 0 || refUrl.Contains("#") || refUrl.Contains("/?") || refUrl == "/" || refUrl.Contains("javascript"))
					continue;

				if (refUrl.Contains("?"))
					refUrl = refUrl.Substring(0, refUrl.IndexOf("?"));

				originalUrl = refUrl;

				if (!refUrl.Contains(UrlSite))
					refUrl = UrlSite + refUrl;

				string refUrlWithHandler =@"http://localhost:53047/ProxyHandler.ashx?url=";

				cachedResponse = cachedResponse.Replace(SearchedAttribute + "=\"" + originalUrl, SearchedAttribute + "=\"" + refUrlWithHandler + refUrl);				
			}
		}

		private string ReturnUrlSite(string url)
		{
			Regex reg = new Regex(@"\b(http://)[a-zA-Z.]*");
			return reg.Match(url, 0).Value;
		}

		public bool IsReusable
		{
			get
			{
				return true;
			}
		}
	}
}