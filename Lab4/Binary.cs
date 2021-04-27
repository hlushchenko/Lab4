using System;
using System.IO;

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
            using (var bw = new BinaryWriter(File.Open(_path, FileMode.Create)))
            {
                bw.Write(data);
            }
        }
        
    }
}