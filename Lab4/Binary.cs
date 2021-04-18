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

        private byte[] IntsToBytes(uint[] ints)
        {
            List<byte> output = new List<byte>();
            byte currentSize = 8;
            
            return null;
        }

        public static bool[] IntToBits(uint n)
        {
            List<bool> bits = new List<bool>();
            while (n > 0)
            {
                bits.Add(n%2 != 0);
                n /= 2;
            }
            return bits.ToArray();
        }
    }
}