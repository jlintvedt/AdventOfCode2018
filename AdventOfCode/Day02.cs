﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day02
    {
        public static int Puzzle1(string[] boxIDs)
        {
            int doubles = 0, triples = 0;
            int totalDoubles = 0, totalTriples = 0;
            foreach (var id in boxIDs)
            {
                FindDoublesAndTriples(id, out doubles, out triples);
                totalDoubles += doubles;
                totalTriples += triples;
            }
            return totalDoubles*totalTriples;
        }

        public static void FindDoublesAndTriples(string ID, out int doubles, out int triples)
        {
            var chars = Encoding.ASCII.GetBytes(ID);
            int occurences;
            doubles = triples = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                occurences = 1;
                for (int j = i+1; j < chars.Length; j++)
                {
                    if (chars[i]==chars[j])
                    {
                        occurences++;
                    }
                }
                // If a letter occurs 4 times, it should not be counted as a tripple
                if (occurences == 4)
                {
                    triples--;
                // If a letter occurs 3 times, it can't also be a double
                } else if (occurences==3)
                {
                    triples++;
                    doubles--;
                } else if (occurences==2) {
                    doubles++;
                }
            }
            // We are not interested in the number of occurences, just if it exists or not
            doubles = doubles >= 1 ? 1 : 0;
            triples = triples >= 1 ? 1 : 0;
        }
    }
}
