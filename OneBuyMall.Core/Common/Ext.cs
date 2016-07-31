using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneBuyMall
{
    public static class Ext
    {
        public static BitArray toBitArray(this int i)
        {
            byte[] b = BitConverter.GetBytes(i);
            BitArray bitArray = new BitArray(b);
            return bitArray;
        }
        public static string ToJson(this object o)
        {
            return JsonConvert.SerializeObject(o);
        }
        public static T ToObject<T>(this string s) where T : class,new()
        {
            return JsonConvert.DeserializeObject<T>(s);
        }
    }
}
