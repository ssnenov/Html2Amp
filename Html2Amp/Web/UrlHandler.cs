using System;

namespace Html2Amp.Web
{
	public class UrlHandler
	{
		public string TryResolveUrl(string host, string url)
		{
			if (string.IsNullOrEmpty(host))
			{
				if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
				{
					return url;
				}
			}
			else if (url.StartsWith("//")) // Protocol invariant url
			{
				return new UriBuilder(new Uri(host).Scheme, url.TrimStart('/')).ToString().TrimEnd('/');
			}
			else
			{
				var resultUrl = host.Trim('/') + "/" + url.Trim('/');

				if (Uri.IsWellFormedUriString(resultUrl, UriKind.Absolute))
				{
					return resultUrl;
				}
			}

			return null;
		}
	}
}