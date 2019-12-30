using JCommon.SD.Core.Data;
using System;
using System.Net;

namespace JCommon.SD.Core.Interfaces
{
    public interface ISDChecker
    {
        SDCheckData CheckDownload(WebResponse response);

        SDCheckData CheckDownload(Uri url, ISDRequestBuilder requestBuilder);
    }
}
