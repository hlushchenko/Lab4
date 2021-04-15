using System;
using System.IO;

namespace Lab4
{
    public class Binary
    {
        private string _path;
        public byte[] Data;

        public Binary(string path)
        {
            _path = path;
        }

        public void Read()
        {
            using (var br = new BinaryReader(File.Open(_path, FileMode.Open)))
            {
                Data = br.ReadBytes(Convert.ToInt32(br.BaseStream.Length));
            }
        }
    }
}