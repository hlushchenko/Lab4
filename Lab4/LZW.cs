using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    class LZW
    {
        private byte[] _data;

        public LZW(byte[] data)
        {
            _data = data;
        }

        public static uint[] Encode(string uncompressed)
        {
            Dictionary<string, uint> dictionary = CreateDictionaryEncode();
            string p = "";
            uint[] result = Array.Empty<uint>();

            foreach (char c in uncompressed)
            {
                if (dictionary.ContainsKey(p + c))
                {
                    p += c;
                }
                else
                {
                    Utilities.ArrayPush(ref result, dictionary[p]);
                    dictionary.Add(p + c, (uint)dictionary.Count);
                    p = c.ToString();
                }
            }
            Utilities.ArrayPush(ref result, dictionary[p]);
            return result;
        }

        public static Dictionary<string, uint> CreateDictionaryEncode()
        {
            Dictionary<string, uint> dictionary = new Dictionary<string, uint>();
            for (int i = 0; i < 256; i++)
                dictionary.Add(((char)i).ToString(), (uint)i);
            return dictionary;
        }
    }
}
