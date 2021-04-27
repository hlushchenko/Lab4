using System;

namespace Lab4
{
    public class ArgsParser
    {
        public bool Compress;
        public string CompressedPath;
        public string UncompressedPath;

        public ArgsParser(string[] input)
        {
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
            if(input.Length > 2)UncompressedPath = input[2];
        }
    }
}