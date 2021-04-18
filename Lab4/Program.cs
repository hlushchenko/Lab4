using System;
using System.IO;
using System.Net;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = new Binary("D:/пример3.dat");
            file.Write(new []{255u, 12u, 13u, 511u, 67u});
            var a = file.ReadInts();
            foreach (var b in a)
            {
                Console.WriteLine(b);
            }
            File.Delete("D:/пример3.dat");
        }
    }
}