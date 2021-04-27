﻿using System.Collections.Generic;

namespace Lab4
{
    public class RLE
    {
        private byte[] Compress(byte[] input)
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
    }
}