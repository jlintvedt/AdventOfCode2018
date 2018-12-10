using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeTests
{
    public class Helper
    {
        public static int[] LoadResourceIntArray(string resourceName, string delim)
        {
            var rawInput = InputData.ResourceManager.GetObject(resourceName);
            var stringInput = rawInput.ToString().Split(new[] { delim }, StringSplitOptions.None);
            int[] intInput = new int[stringInput.Length];
            for (int i = 0; i < stringInput.Length; i++)
            {
                intInput[i] = Int32.Parse(stringInput[i]);
            }
            return intInput;
        }

        public static string[] LoadResourceStringArray(string resourceName, string delim)
        {
            var rawInput = InputData.ResourceManager.GetObject(resourceName);
            return rawInput.ToString().Split(new[] { delim }, StringSplitOptions.None);
        }
    }
}
