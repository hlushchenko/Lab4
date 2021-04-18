using System;
using System.Collections.Generic;

namespace Lab4
{
    class LZW
    {
        private byte[] _data;

        public LZW(byte[] data)
        {
            _data = data;
        }
        
        //41 42 52 41 43 41 44 41 42 52 41 42 52 41 42 52
        //41 42 52 4143 4144 4142 5241 4252 414252

        public static uint[] Compress(byte[] decompressedFileBytes)
        {
            uint[] dictionary = CreateDictionary(decompressedFileBytes);
            byte prev = 0, next;
            int index = -1;
            while(index != decompressedFileBytes.Length)
            {
                next = decompressedFileBytes[index++];
                if (Utilities.ArrayContains(dictionary, Convert.ToUInt32(prev+next)))
                    prev += next;
                else
                {
                    Utilities.ArrayPush(ref dictionary, Convert.ToUInt32(prev + next));
                    prev = next;
                }
            }
            
            /*uint[] arr = System.Array.Empty<uint>();
            foreach (var singleByte in decompressedFileBytes)
            {
                if (Utilities.ArrayContains(arr, singleByte))
                {
                    Utilities.ArrayPush(ref arr, singleByte);
                }
                else
                    Utilities.ArrayPush(ref arr, singleByte);
            }
            return arr;*/
            Console.ReadLine();
            return dictionary;
        }

        public static uint[] CreateDictionary(byte[] decompressedFileBytes)
        {
            uint[] dictionary = new uint[0];
            for (int i = 0; i < decompressedFileBytes.Length; i++)
            {
                Utilities.ArrayPush(ref dictionary, decompressedFileBytes[i]);
            }
            return dictionary;
        }

    }
}
