using System;
using System.IO;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var arg = new ArgsParser(args);
                var uncompressed = new Binary(arg.UncompressedPath);
                var compressed = new Binary(arg.CompressedPath);
                var rle = new RLE();
                if (arg.Compress)
                {
                    Console.WriteLine($"Compressing {arg.UncompressedPath} into {arg.CompressedPath}...");
                    compressed.Write(rle.Compress(uncompressed.Read()));
                }
                else
                {
                    Console.WriteLine($"Decompressing {arg.CompressedPath} into {arg.UncompressedPath}...");
                    uncompressed.Write(rle.Decompress(compressed.Read()));
                }

                Console.WriteLine("Done");
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect arguments");
            }
            catch (IOException)
            {
                Console.WriteLine("No such file");
            }

        }
    }
}