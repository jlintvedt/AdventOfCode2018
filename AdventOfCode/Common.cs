using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Common
    {
        public static int[] ParseIntArray(string input)
        {
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
    }
}
