using System;
using System.IO;

namespace JCommon.FileDatabase.IO
{
    public abstract class DataFile
    {
        public string Path { get; set; }
        public virtual void Deserialize(DataReader reader) { }
        public virtual void Serialize(DataWriter writer) { }
    }
}
