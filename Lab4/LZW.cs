using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class LZW
    {
        private string _type;
        public string _archieveName;
        public string _file;

        public string Type
        {
            get => _type;
            set
            {
                if (value == "compress" || value == "decompress")
                    _type = value;
            }
        }

        public LZW(string type, string archieveName, string file = null)
        {
            _type = type;
            _archieveName = archieveName;
        }

        private void ArgsParser(string str)
        {
            string[] words = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string type = words[0];
            string archive = words[1];
            if (type == "compress")
            {
                string input = words[2];
            }
        }
    }
}
