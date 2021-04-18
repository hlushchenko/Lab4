using System;
using System.Text;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            //byte[] arr = { 12, 13, 14, 16, 10, 12, 14};
            //uint[] test = LZW.Encode("ABRACADABRABRABRABRA");
            byte[] bytes = Encoding.ASCII.GetBytes("stas");
            uint[] test = LZW.Encode(bytes);
            //string res = LZW.Decode(test);
        }
    }
}