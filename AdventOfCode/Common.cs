﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Common
    {
        // == == == == == Parsing == == == == ==
        public static int[] ParseIntArray(string input, string delim=null)
        {
            if (delim != null)
            {
                return input.Split(new[] { delim }, StringSplitOptions.None).Select(i => Convert.ToInt32(i)).ToArray();
            }
            return input.Split(new[] { Environment.NewLine }, StringSplitOptions.None).Select(i => Convert.ToInt32(i)).ToArray();
        }

        public static string[] ParseStringArray(string input)
        {
            return input.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        }

        public static (int x, int y)[] ParseIntTupleArray(string input)
        {
            return input.Split(new[] { Environment.NewLine }, StringSplitOptions.None)
                .Select(line => line.Split(new[] { "," }, StringSplitOptions.None))
                .Select(xy => xy.Select(i => Convert.ToInt32(i)).ToArray())
                .Select(xy => (x: xy[0], y: xy[1])).ToArray();
        }

        public static (char a, char b)[] ParseCharSubstringTupleArray(string input, int indexA, int indexB)
        {
            return input.Split(new[] { Environment.NewLine }, StringSplitOptions.None)
                .Select(ab => (a: ab[indexA], b: ab[indexB])).ToArray();
        }

        // == == == == == Conversion == == == == ==
        public static int LetterToIndex(char s)
        {
            return s - 65;
        }

        public static char IndexToLetter(int i)
        {
            return (char)(65 + i);
        }
    }
}
