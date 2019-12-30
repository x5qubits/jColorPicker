using System;
using System.Net;
using JCommon.SD.Core.Data;
using JCommon.SD.Core.Interfaces;

namespace JCommon.SD.Core.Utils
{
    public class DownloadChecker : ISDChecker
    {
        public SDCheckData CheckDownload(WebResponse response)
        {
            var result = new SDCheckData();
            var acceptRanges = response.Headers["Accept-Ranges"];
            result.SupportsResume = !string.IsNullOrEmpty(acceptRanges) && acceptRanges.ToLower().Contains("bytes");
            result.Size = response.ContentLength;
            result.StatusCode = (int?)(response as HttpWebResponse)?.StatusCode;
            result.Success = true;
            return result;
        }

        public SDCheckData CheckDownload(Uri url, ISDRequestBuilder requestBuilder)
        {
            try
            {
                var request = requestBuilder.CreateRequest(url, null);

                using (var response = request.GetResponse())
                {
                    return CheckDownload(response);
                }
            }
            catch (WebException ex)
            {
                return new SDCheckData() { Exception = ex, StatusCode = (int)(ex.Response as HttpWebResponse)?.StatusCode };
            }
            catch (Exception ex)
            {
                return new SDCheckData() { Exception = ex };
            }
        }
    }
}