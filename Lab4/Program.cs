using System;
using System.Text;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            uint[] test = LZW.Encode("stas");
            string stas = LZW.Decode(test);
        }
    }
}