using System;

namespace Lab4
{
    public class ArgsParser
    {
        public bool Compress;
        public string CompressedPath;
        public string[] UncompressedPath;

        public ArgsParser(string[] input)
        {
            UncompressedPath = new string[input.Length - 2];
            switch (input[0])
            {
                case "--compress":
                    Compress = true;
                    break;
                case "--decompress":
                    Compress = false;
                    break;
                default:
                    throw new FormatException();
            }
            CompressedPath = input[1];
            for (int i = 2; i < input.Length; i++)
            {
                UncompressedPath[i - 2] = input[i];
            }
        }
    }
}