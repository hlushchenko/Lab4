using System;

namespace Lab4
{
    class Utilities
    {
        public static string GetInfo()
        {
            OutText("Input compress, or decompress, name of the input and, if necessary, output files", true);
            string str = Console.ReadLine();
            OutText("", false, true);
            return str;
        }

        public static void OutText(string str = "", bool upper = false, bool lower = false)
        {
            if (upper) OutEquality();
            if (str != "") Console.WriteLine(str);
            if (lower) OutEquality();
        }

        private static void OutEquality(int count = 30)
        {
            for (int i = 0; i < count; i++) Console.Write('=');
            Console.Write('\n');
        }
    }
}
