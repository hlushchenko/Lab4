using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class LZW
    {
        private void TypeOfWork(string str)
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
