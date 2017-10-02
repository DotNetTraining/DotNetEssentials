﻿using System;
namespace OOPCChapter1
{
    public static class ShiftOperators
    {
        public static void LeftShift()
        {
            int value = 1242194743;
            Console.WriteLine("{0} = {1}",
                GetIntBinaryString(value), value);
            for (int i = 0; i < 31; i++)
            {
                int shift = value >> i;
                Console.WriteLine("{0} = {1}",
                GetIntBinaryString(shift), shift);
            }

            /*
             * OUTPUT:
                01001010000010100110001100110111 = 1242194743
                00100101000001010011000110011011 = 621097371
                00010010100000101001100011001101 = 310548685
                00001001010000010100110001100110 = 155274342
                00000100101000001010011000110011 = 77637171
                00000010010100000101001100011001 = 38818585
                00000001001010000010100110001100 = 19409292
                00000000100101000001010011000110 = 9704646
                00000000010010100000101001100011 = 4852323
                00000000001001010000010100110001 = 2426161
                00000000000100101000001010011000 = 1213080
                00000000000010010100000101001100 = 606540
                00000000000001001010000010100110 = 303270
                00000000000000100101000001010011 = 151635
                00000000000000010010100000101001 = 75817
                00000000000000001001010000010100 = 37908
                00000000000000000100101000001010 = 18954
                00000000000000000010010100000101 = 9477
                00000000000000000001001010000010 = 4738
                00000000000000000000100101000001 = 2369
                00000000000000000000010010100000 = 1184
                00000000000000000000001001010000 = 592
                00000000000000000000000100101000 = 296
                00000000000000000000000010010100 = 148
                00000000000000000000000001001010 = 74
                00000000000000000000000000100101 = 37
                00000000000000000000000000010010 = 18
                00000000000000000000000000001001 = 9
                00000000000000000000000000000100 = 4
                00000000000000000000000000000010 = 2
                00000000000000000000000000000001 = 1
                00000000000000000000000000000000 = 0
            */
        }

        public static void RightShift()
        {
            int value = 1242194743;
            Console.WriteLine("{0} = {1}",
                GetIntBinaryString(value), value);
            for (int i = 0; i < 31; i++)
            {
                int shift = value << i;
                Console.WriteLine("{0} = {1}",
                GetIntBinaryString(shift), shift);
            }
            /*
             * OUTPUT:
                01001010000010100110001100110111 = 1242194743
                10010100000101001100011001101110 = -1810577810
                00101000001010011000110011011100 = 673811676
                01010000010100110001100110111000 = 1347623352
                10100000101001100011001101110000 = -1599720592
                01000001010011000110011011100000 = 1095526112
                10000010100110001100110111000000 = -2103915072
                00000101001100011001101110000000 = 87137152
                00001010011000110011011100000000 = 174274304
                00010100110001100110111000000000 = 348548608
                00101001100011001101110000000000 = 697097216
                01010011000110011011100000000000 = 1394194432
                10100110001100110111000000000000 = -1506578432
                01001100011001101110000000000000 = 1281810432
                10011000110011011100000000000000 = -1731346432
                00110001100110111000000000000000 = 832274432
                01100011001101110000000000000000 = 1664548864
                11000110011011100000000000000000 = -965869568
                10001100110111000000000000000000 = -1931739136
                00011001101110000000000000000000 = 431489024
                00110011011100000000000000000000 = 862978048
                01100110111000000000000000000000 = 1725956096
                11001101110000000000000000000000 = -843055104
                10011011100000000000000000000000 = -1686110208
                00110111000000000000000000000000 = 922746880
                01101110000000000000000000000000 = 1845493760
                11011100000000000000000000000000 = -603979776
                10111000000000000000000000000000 = -1207959552
                01110000000000000000000000000000 = 1879048192
                11100000000000000000000000000000 = -536870912
                11000000000000000000000000000000 = -1073741824
                10000000000000000000000000000000 = -2147483648
            */
        }

        static string GetIntBinaryString(int n)
        {
            char[] b = new char[32];
            int pos = 31;
            int i = 0;

            while (i < 32)
            {
                if ((n & (1 << i)) != 0)
                {
                    b[pos] = '1';
                }
                else
                {
                    b[pos] = '0';
                }
                pos--;
                i++;
            }
            return new string(b);
        }
    }
}
