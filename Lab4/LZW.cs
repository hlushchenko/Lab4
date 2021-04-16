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

        public string Compress()
        {
            List<byte> table = CreateTable();
            return null;
        }

        private List<byte> CreateTable()
        {
            List<byte> table = new List<byte>();
            foreach (var bt in _data)
            {
                if(!table.Contains(bt)) table.Add(bt);
            }
            return table;
        }
    }
}
