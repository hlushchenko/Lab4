using System;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            var file1 = new Binary("D:/пример.bmp");
            var file2 = new Binary("D:/пример2.bmp");
            file2.Write(file1.Read());
        }
    }
}