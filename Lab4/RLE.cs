using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace Lab4
{
    public class RLE
    {
        public byte[] Compress(byte[] input)
        {
            List<(byte, byte)> rleList = new List<(byte, byte)>();
            byte prev = input[0];
            rleList.Add((prev, 1));
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] != prev || rleList[^1].Item2 == 255)
                {
                    rleList.Add((input[i], 1));
                }
                else
                {
                    rleList[^1] = (input[i], (byte) (rleList[^1].Item2 + 1));
                }

                prev = input[i];
            }

            byte[] output = new byte[rleList.Count * 2];
            for (int i = 0; i < rleList.Count; i++)
            {
                output[i * 2] = rleList[i].Item1;
                output[i * 2 + 1] = rleList[i].Item2;
            }

            return output;
        }
        
        public byte[] Decompress(byte[] input)
        {
            List<byte> output = new List<byte>();
            for (int i = 0; i < input.Length / 2; i++)
            {
                for (int j = 0; j < input[i * 2 + 1]; j++)
                {
                    output.Add(input[i * 2]);
                }
            }
            return output.ToArray();
        }

        public byte[] FileComposer(Binary[] files)
        {
            List<byte> output = new List<byte>();
            foreach (var file in files)
            {
                byte[] header = new byte[32];
                byte[] name = Encoding.ASCII.GetBytes(file.Filename);
                for (int i = 0; i < name.Length; i++)
                {
                    header[32-name.Length+i] = name[i];
                }
                foreach (var bt in header)
                {
                    output.Add(bt);
                }
                foreach (var bt in file.Read())
                {
                    output.Add(bt);
                }
            }
            return output.ToArray();
        }

        public List<List<byte>> FileDecomposer(byte[] input, out string[] filenames)
        {
            List<string> names = new List<string>();
            List<List<byte>> files = new List<List<byte>>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 0 && input[i + 1] == 0)
                {
                    List<byte> currentName = new List<byte>();
                    for (int j = i; j < i + 32; j++)
                    {
                        if (input[j] != 0)
                        {
                            currentName.Add(input[j]);
                        }
                    }
                    names.Add(Encoding.ASCII.GetString(currentName.ToArray()));
                    files.Add(new List<byte>());
                    i += 32;
                }

                files[^1].Add(input[i]);
            }
            

            filenames = names.ToArray();
            return files;
        }
    }
}