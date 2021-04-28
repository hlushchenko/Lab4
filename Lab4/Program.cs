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
                var uncompressed = new Binary[arg.UncompressedPath.Length];
                for (int i = 0; i < arg.UncompressedPath.Length; i++)
                {
                    uncompressed[i] = new Binary(arg.UncompressedPath[i]);
                }
                var compressed = new Binary(arg.CompressedPath);
                
                var rle = new RLE();
                if (arg.Compress)
                {
                    Console.WriteLine($"Compressing files into {arg.CompressedPath}...");
                    compressed.Write(rle.Compress(rle.FileComposer(uncompressed)));
                }
                else
                {
                    Console.WriteLine($"Decompressing {arg.CompressedPath}...");
                    string[] names;
                    var files = rle.FileDecomposer(rle.Decompress(compressed.Read()), out names);
                    for (int i = 0; i < names.Length; i++)
                    {
                        Binary file1 = new Binary(compressed.Filepath + names[i]);
                        file1.Write(files[i].ToArray());
                    }
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