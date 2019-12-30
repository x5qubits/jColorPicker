using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace JCommon
{
    public abstract class XmlMarshaller
    {
        public abstract void Write(TextWriter os);
        public abstract void Read(XmlNode os);
        public static string ReadAttribute(XmlNode node, string attribute)
        {
            try
            {
                if (node != null && node.Attributes != null && node.Attributes[attribute] != null)
                {
                    return node.Attributes[attribute].Value;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("attribute:{0} not exist", attribute), ex);
            }

            return "";
        }

        public static XmlNode GetOnlyChild(XmlNode parent, string name)
        {
            XmlNode child = null;
            foreach (XmlNode sub in parent.ChildNodes)
            {
                if (sub.NodeType == XmlNodeType.Element && sub.Name == name)
                {
                    if (child != null)
                        throw new Exception(string.Format("child:{0} duplicate", name));
                    child = sub;
                }
            }
            return child;
        }

        public static List<XmlNode> GetChilds(XmlNode parent)
        {
            var childs = new List<XmlNode>();
            if (parent != null)
            {
                childs.AddRange(parent.ChildNodes.Cast<XmlNode>().Where(sub => sub.NodeType == XmlNodeType.Element));
            }

            return childs;
        }

        public static string ReadContent(XmlNode node)
        {
            return node.InnerText;
        }

        public static bool ReadBool(XmlNode node)
        {
            var str = ReadContent(node).ToLower();
            if (str == "true")
                return true;
            if (str == "false")
                return false;
            throw new Exception(string.Format("'{0}' is not valid bool", str));
        }

        public static int ReadInt(XmlNode node)
        {
            return int.Parse(node.InnerText);
        }

        public static long ReadLong(XmlNode node)
        {
            return long.Parse(node.InnerText);
        }

        public static float ReadFloat(XmlNode node)
        {
            return float.Parse(node.InnerText);
        }

        public static string ReadString(XmlNode node)
        {
            return node.InnerText;
        }

        public static T ReadObject<T>(XmlNode node, string fullTypeName) where T : XmlMarshaller
        {
            var obj = (T)Create(node, fullTypeName);
            obj.Read(node);
            return obj;
        }

        public static T ReadDynamicObject<T>(XmlNode node, string ns) where T : XmlMarshaller
        {
            var fullTypeName = ns + "." + ReadAttribute(node, "type");
            return ReadObject<T>(node, fullTypeName);
        }

        public static object Create(XmlNode node, string type)
        {
            try
            {
                var t = Type.GetType(type);
                return Activator.CreateInstance(t);
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("type:{0} create fail!", type), e);
            }
        }

        public static void Write(TextWriter os, string name, bool x)
        {
            os.WriteLine("<{0}>{1}</{0}>", name, x);
        }

        public static void Write(TextWriter os, string name, int x)
        {
            os.WriteLine("<{0}>{1}</{0}>", name, x);
        }

        public static void Write(TextWriter os, string name, long x)
        {
            os.WriteLine("<{0}>{1}</{0}>", name, x);
        }

        public static void Write(TextWriter os, string name, float x)
        {
            os.WriteLine("<{0}>{1}</{0}>", name, x);
        }

        public static void Write(TextWriter os, string name, string x)
        {
            os.WriteLine("<{0}>{1}</{0}>", name, new System.Xml.Linq.XText(x).ToString());
        }

        public static void Write(TextWriter os, string name, XmlMarshaller x)
        {
            os.WriteLine("<{0} type=\"{1}\">", name, x.GetType().Name);
            x.Write(os);
            os.WriteLine("</{0}>", name);
        }

        public static void Write<V>(TextWriter os, string name, List<V> x)
        {
            os.WriteLine("<{0}>", name);
            x.ForEach(v => Write(os, "item", v));
            os.WriteLine("</{0}>", name);
        }

        public static void Write<V>(TextWriter os, string name, HashSet<V> x)
        {
            os.WriteLine("<{0}>", name);
            foreach (var v in x)
            {
                Write(os, "item", v);
            }
            os.WriteLine("</{0}>", name);
        }

        public static void Write<K, V>(TextWriter os, string name, Dictionary<K, V> x)
        {
            os.WriteLine("<{0}>", name);
            foreach (var e in x)
            {
                os.WriteLine("<item>");
                Write(os, "key", e.Key);
                Write(os, "value", e.Value);
                os.WriteLine("</item>");
            }
            os.WriteLine("</{0}>", name);
        }

        public static void Write(TextWriter os, string name, object x)
        {
            if (x is bool)
            {
                Write(os, name, (bool)x);
            }
            else if (x is int)
            {
                Write(os, name, (int)x);
            }
            else if (x is long)
            {
                Write(os, name, (long)x);
            }
            else if (x is float)
            {
                Write(os, name, (float)x);
            }
            else if (x is string)
            {
                Write(os, name, (string)x);
            }
            else if (x is XmlMarshaller)
            {
                Write(os, name, (XmlMarshaller)x);
            }
            else
            {
                throw new Exception("unknown marshal type;" + x.GetType());
            }
        }

        public void LoadAConfig(string file)
        {
            var doc = new XmlDocument();
            doc.Load(file);
            Read(doc.DocumentElement);
        }

        public void SaveAConfig(string file)
        {
            var os = new StringWriter();
            Write(os, "root", this);
            File.WriteAllText(file, os.ToString());
        }

        public static V LoadSingleConfig<V>(string file) where V : XmlMarshaller
        {
            var datas = new List<V>();
            LoadConfig(datas, file);
            if (datas.Count != 1)
                throw new Exception(string.Format("SingleConfig type:{0} file:{1} size != 1", typeof(V).FullName, file));
            return datas[0];
        }

        public static void SaveSingleConfig<V>(V x, string file) where V : XmlMarshaller
        {
            SaveConfig(new List<V> { x }, file);
        }

        public static void LoadConfig<V>(List<V> x, string file) where V : XmlMarshaller
        {
            var doc = new XmlDocument();
            doc.Load(file);
            x.AddRange(GetChilds(doc.DocumentElement).Select(_ => ReadDynamicObject<V>(_, typeof(V).Namespace)));
        }

        public static void SaveConfig<V>(List<V> x, string file) where V : XmlMarshaller
        {
            var os = new StringWriter();
            Write(os, "root", x);
            File.WriteAllText(file, os.ToString());
        }

        public static void SaveConfig<K, V>(Dictionary<K, V> x, string file) where V : XmlMarshaller
        {
            SaveConfig(x.Values.ToList(), file);
        }
    }
}
