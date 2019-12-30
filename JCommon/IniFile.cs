using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JCommon
{
    public class IniFile
    {
        SortedList<string, string> Properties = new SortedList<string, string>();
        string filename;

        public IniFile(string file)
        {
            Load(file);
        }
        
        public T GetValue<T>(string Key)
        {
            string value = Get(Key);
            Type type = typeof(T);
            if (value != null)
            {
                return (T)Convert.ChangeType(value, type);
            }
            return default;
        }

        string Get(string field)
        {
            if (Properties.TryGetValue(field, out string x))
                return x;

            return null;
        }

        public void SetValue(string field, object value)
        {
            Properties[field] = value.ToString();
        }

        public string[] GetKeys()
        {
            return Properties.Keys.ToArray();
        }

        public void Save()
        {
            Save(filename);
        }

        void Save(string filename)
        {
            this.filename = filename;

            if (!File.Exists(filename))
                File.Create(filename);

            StreamWriter file = new StreamWriter(filename);

            foreach (string prop in Properties.Keys.ToArray())
                if (!string.IsNullOrWhiteSpace(Properties[prop]))
                    file.WriteLine(prop + "=" + Properties[prop]);

            file.Close();
        }

        public void Reload()
        {
            Load(filename);
        }

        public void Load(string filename)
        {
            this.filename = filename;
            Properties = new SortedList<string, string>();

            if (System.IO.File.Exists(filename))
                Parse(filename);
            else
                System.IO.File.Create(filename);
        }

        private void Parse(string file)
        {
            if(File.Exists(file))
            { 
                string[] data = File.ReadAllLines(file);
                if (data.Length == 0)
                    return;

                for (int i = 0; i < data.Length; i++)
                {
                    string line = data[i];
                    if ((!string.IsNullOrEmpty(line)) 
                        && (!line.StartsWith(";")) 
                        && (!line.StartsWith("#")) 
                        && (!line.StartsWith("'")) 
                        && (line.Contains('=')))
                    {
                        try
                        {
                            int index = line.IndexOf('=');
                            string key = line.Substring(0, index).Trim();
                            string value = line.Substring(index + 1).Trim();

                            if ((value.StartsWith("\"") && value.EndsWith("\""))
                                || (value.StartsWith("'") && value.EndsWith("'")))
                            {
                                value = value.Substring(1, value.Length - 2);
                            }
                            Properties[key] = value;
                        }
                        catch
                        {
                            Log.Error("IniFile contains an error on line "+i+".");
                        }
                    }
                }
            }
        }

    }
}
