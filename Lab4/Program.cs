using System;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = new Binary("D:/пример3.dat");
            file.Write(new []{ 255u, 511u, 625u, 12u});
            var a = file.ReadInts();
            foreach (var b in a)
            {
                Console.WriteLine(b);
            }
        }
    }
}