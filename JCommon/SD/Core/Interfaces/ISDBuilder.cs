using System;

namespace JCommon.SD.Core.Interfaces
{
    public interface ISDBuilder
    {
        ISD Build(Uri url, int bufferSize, long? offset, long? maxReadBytes);
    }
}