using System;
using System.Net;

namespace JCommon.SD.Core.Interfaces
{
    public interface ISDRequestBuilder
    {
        HttpWebRequest CreateRequest(Uri url, long? offset);
    }
}
