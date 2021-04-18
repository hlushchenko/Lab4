using System;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] arr = { 12, 13, 14, 16, 10, 12, 14};
            uint[] test = LZW.Encode("ABRACADABRABRABRABRA");
            string res = LZW.Decode(test);
        }
    }
}