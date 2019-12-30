using System;
using System.Net;
using System.Reflection;
using JCommon.SD.Core.Interfaces;

namespace JCommon.SD.Core.Utils
{
    public class SimpleWebRequestBuilder : ISDRequestBuilder
    {
        public SimpleWebRequestBuilder(IWebProxy proxy)
        {
            this.Proxy = proxy;
        }

        public SimpleWebRequestBuilder()
            : this(null)
        {
        }

        public IWebProxy Proxy { get; private set; }

        public HttpWebRequest CreateRequest(Uri url, long? offset)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);

            if (Proxy != null)
            {
                request.Proxy = Proxy;
            }

            if (offset.HasValue && offset.Value > 0)
            {
                // Only works with long values starting with .NET 4:
                // request.AddRange(offset.Value);

                this.AddLongRangeInDotNet3_5(request, offset.Value);
            }

            return request;
        }

        private void AddLongRangeInDotNet3_5(HttpWebRequest request, long offset)
        {
            var method = typeof(WebHeaderCollection).GetMethod("AddWithoutValidate", BindingFlags.Instance | BindingFlags.NonPublic);

            string key = "Range";
            string val = string.Format("bytes={0}-", offset);

            method.Invoke(request.Headers, new object[] { key, val });
        }
    }
}
