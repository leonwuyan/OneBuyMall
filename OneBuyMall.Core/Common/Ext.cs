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
    }
}
