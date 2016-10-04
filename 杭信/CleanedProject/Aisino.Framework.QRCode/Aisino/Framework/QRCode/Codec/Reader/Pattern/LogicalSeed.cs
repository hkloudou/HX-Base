﻿namespace Aisino.Framework.QRCode.Codec.Reader.Pattern
{
    using System;

    public class LogicalSeed
    {
        private static int[][] seed = new int[][] { 
            new int[] { 6, 14 }, new int[] { 6, 0x12 }, new int[] { 6, 0x16 }, new int[] { 6, 0x1a }, new int[] { 6, 30 }, new int[] { 6, 0x22 }, new int[] { 6, 0x16, 0x26 }, new int[] { 6, 0x18, 0x2a }, new int[] { 6, 0x1a, 0x2e }, new int[] { 6, 0x1c, 50 }, new int[] { 6, 30, 0x36 }, new int[] { 6, 0x20, 0x3a }, new int[] { 6, 0x22, 0x3e }, new int[] { 6, 0x1a, 0x2e, 0x42 }, new int[] { 6, 0x1a, 0x30, 70 }, new int[] { 6, 0x1a, 50, 0x4a }, 
            new int[] { 6, 30, 0x36, 0x4e }, new int[] { 6, 30, 0x38, 0x52 }, new int[] { 6, 30, 0x3a, 0x56 }, new int[] { 6, 0x22, 0x3e, 90 }, new int[] { 6, 0x1c, 50, 0x48, 0x5e }, new int[] { 6, 0x1a, 50, 0x4a, 0x62 }, new int[] { 6, 30, 0x36, 0x4e, 0x66 }, new int[] { 6, 0x1c, 0x36, 80, 0x6a }, new int[] { 6, 0x20, 0x3a, 0x54, 110 }, new int[] { 6, 30, 0x3a, 0x56, 0x72 }, new int[] { 6, 0x22, 0x3e, 90, 0x76 }, new int[] { 6, 0x1a, 50, 0x4a, 0x62, 0x7a }, new int[] { 6, 30, 0x36, 0x4e, 0x66, 0x7e }, new int[] { 6, 0x1a, 0x34, 0x4e, 0x68, 130 }, new int[] { 6, 30, 0x38, 0x52, 0x6c, 0x86 }, new int[] { 6, 0x22, 60, 0x56, 0x70, 0x8a }, 
            new int[] { 6, 30, 0x3a, 0x56, 0x72, 0x8e }, new int[] { 6, 0x22, 0x3e, 90, 0x76, 0x92 }, new int[] { 6, 30, 0x36, 0x4e, 0x66, 0x7e, 150 }, new int[] { 6, 0x18, 50, 0x4c, 0x66, 0x80, 0x9a }, new int[] { 6, 0x1c, 0x36, 80, 0x6a, 0x84, 0x9e }, new int[] { 6, 0x20, 0x3a, 0x54, 110, 0x88, 0xa2 }, new int[] { 6, 0x1a, 0x36, 0x52, 110, 0x8a, 0xa6 }, new int[] { 6, 30, 0x3a, 0x56, 0x72, 0x8e, 170 }
         };

        public static int[] getSeed(int version)
        {
            return seed[version - 1];
        }

        public static int getSeed(int version, int patternNumber)
        {
            return seed[version - 1][patternNumber];
        }
    }
}

