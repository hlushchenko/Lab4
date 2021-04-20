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

        public static string Decode(uint[] compressed)
        {
            Dictionary<uint, string> dictionary = CreateDictionaryDecode();
            string decompressed = dictionary[compressed[0]];
            string w = dictionary[compressed[0]];
            compressed = Utilities.RemoveByIndex(ref compressed, 0);

            foreach (int k in compressed)
            {
                string entrance = "";
                if (dictionary.ContainsKey((uint)k))
                    entrance = dictionary[(uint)k];
                else if (k == dictionary.Count)
                    entrance = w + w[0];
                decompressed += entrance;
                dictionary.Add((uint)dictionary.Count, w + entrance[0]);
                w = entrance;
            }
            return decompressed;
        }

        public static Dictionary<string, uint> CreateDictionaryEncode()
        {
            Dictionary<string, uint> dictionary = new Dictionary<string, uint>();
            for (int i = 0; i < 256; i++)
                dictionary.Add(((char)i).ToString(), (uint)i);
            return dictionary;
        }

        public static Dictionary<uint, string> CreateDictionaryDecode()
        {
            Dictionary<uint, string> dictionary = new Dictionary<uint, string>();
            for (int i = 0; i < 256; i++)
                dictionary.Add((uint)i, ((char)i).ToString());
            return dictionary;
        }
    }
}