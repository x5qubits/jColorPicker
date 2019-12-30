using JCommon.Extensions;
using JCommon.FileDatabase.IO;
using System.IO;

namespace JCommon.FileDatabase
{
    /// <summary>
    /// One utility that allows you to read and save binary files based on a defined file structure.
    /// </summary>
    public class FileDatabase
    {
        private static object s_Sync = new object();
        static volatile FileDatabase s_Instance;
        public static FileDatabase Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    lock (s_Sync)
                    {
                        if (s_Instance == null)
                        {
                            s_Instance = new FileDatabase();
                        }
                    }
                }
                return s_Instance;
            }
        }

        public static TMsg ReadFile<TMsg>(string path, bool encrypt = false) where TMsg : DataFile, new()
        {
            return Instance.MReadFile<TMsg>(path, encrypt);
        }

        public static void WriteFile(string path, DataFile msg, bool encrypt = false)
        {
            Instance.MWriteFile(path, msg, encrypt);
        }

        public static void WriteFile(DataFile msg, bool encrypt = false)
        {
            WriteFile(msg.Path, msg, encrypt);
        }

        private TMsg MReadFile<TMsg>(string path, bool encrypt) where TMsg : DataFile, new()
        {
            if (File.Exists(path))
            {
                var msg = new TMsg
                {
                    Path = path
                };
                byte[] data = File.ReadAllBytes(path);

                if (encrypt)
                {
                    data = data.DSAToBytes();
                }

                var reader = new DataReader(data);
                msg.Deserialize(reader);
                return msg;
            }
            return null;
        }

        private void MWriteFile(string path, DataFile msg, bool encrypt)
        {
            msg.Path = path;
            DataWriter writer = new DataWriter();
            msg.Serialize(writer);
            byte[] data = writer.ToArray();

            if (encrypt)
            {
                data = data.BytesToDSA();
            }

            File.WriteAllBytes(msg.Path, data);
        }

    }
}