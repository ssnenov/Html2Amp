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
            else
            {
                var resultUrl = host + url;

                if (Uri.IsWellFormedUriString(resultUrl, UriKind.Absolute))
                {
                    return resultUrl;
                }
            }

            return null;
        }
    }
}