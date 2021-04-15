using System;

namespace Lab4
{
    class Utilities
    {
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
