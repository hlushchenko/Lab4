using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab4
{
    public class Binary
    {
        private string _path;

        public Binary(string path)
        {
            _path = path;
        }

        public byte[] Read()
        {
            byte[] data;
            using (var br = new BinaryReader(File.Open(_path, FileMode.Open)))
            {
                data = br.ReadBytes(Convert.ToInt32(br.BaseStream.Length));
            }
            return data;
        }

        public void Write(byte[] data)
        {
            using (var bw = new BinaryWriter(File.Open(_path, FileMode.OpenOrCreate)))
            {
                bw.Write(data);
            }
        }

        public void Write(uint[] data)
        {
            Write(IntsToBytes(data));
        }

        public static byte[] IntsToBytes(uint[] ints)
        {
            List<byte> output = new List<byte>();
            int currentSize = 8;
            int pos = 0;
            foreach (var number in ints)
            {
                if (number >= Math.Pow(2, currentSize)) currentSize++;
                foreach (var bit in NormalizeBits(IntToBits(number), currentSize))
                {
                    if (pos % 8 == 0)
                    {
                        output.Add(0);
                    }
                    if (bit)
                    {
                        output[^1] = (byte) (output[^1] | Pow2((byte) (7-pos%8)));
                    }

                    pos++;
                }
            }
            
            return output.ToArray();
        }

        public static byte Pow2(byte power)
        {
            return power == 0 ? 1 : (byte) ((byte)2 * Pow2((byte) (power-1)));
        }

        public static bool[] IntToBits(uint n)
        {
            List<bool> bits = new List<bool>();
            while (n > 0)
            {
                bits.Add(n%2 != 0);
                n /= 2;
            }
            for (int i = 0; i < bits.Count/2; i++)
            {
                bits[i] = bits[i] ^ bits[^(i+1)];
                bits[^(i+1)] = bits[^(i+1)] ^ bits[i];
                bits[i] = bits[i] ^ bits[^(i+1)];
            }
            return bits.ToArray();
        }

        public static bool[] NormalizeBits(bool[] bits, int size)
        {
            bool[] result = new bool[size];
            for (int i = 1; i <= bits.Length; i++)
            {
                result[^i] = bits[^i];
            }
            return result;
        }
    }
}