using System.Text;
using Newtonsoft.Json;

namespace Demo.Microservices.Core.Common
{

        public static class ObjectSerialize
        {
            public static byte[] Serialize(this object obj)
            {
                if (obj == null)
                {
                    return null;
                }

                var json = JsonConvert.SerializeObject(obj);
                return Encoding.ASCII.GetBytes(json);
            }

            public static T DeSerialize<T>(this byte[] arrBytes)
            {
                var json = Encoding.Default.GetString(arrBytes);
                return  (T)JsonConvert.DeserializeObject(json, typeof(T));
            }

            public static string DeSerializeText(this byte[] arrBytes)
            {
                return Encoding.Default.GetString(arrBytes);
            }
        }
    
}
