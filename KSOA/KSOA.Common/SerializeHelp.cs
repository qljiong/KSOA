using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace U1City.Shop.Unit
{
    public class SerializeHelp
    {
        /// <summary>
        /// 序列化对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="t">对象</param>
        /// <returns></returns>
        public static string Serialize<T>(T t)
        {
            if (t == null)
            {
                return "";
            }

            using (StringWriter sw = new StringWriter())
            {
                XmlSerializer xz = new XmlSerializer(t.GetType());
                xz.Serialize(sw, t);
                return sw.ToString();
            }

        }



        /// <summary>
        /// 反序列化为对象
        /// </summary>
        /// <param name=" T">对象类型</param>
        /// <param name="s">对象序列化后的Xml字符串</param>
        /// <returns></returns>
        public static T Deserialize<T>(string s)
        {
            if (s == string.Empty)
            {
                return default(T);
            }

            using (StringReader sr = new StringReader(s))
            {
                XmlSerializer xz = new XmlSerializer(typeof(T));
                return (T)xz.Deserialize(sr);
            }

        }
    }
}
