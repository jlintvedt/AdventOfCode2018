using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Day09
    {
        public class MarbleGame
        {
            public List<int> Marbles;
            private int activeMarblePos = 0;
            private int numPlayers;
            private int[] playerScores;

            public MarbleGame(int numPlayers)
            {
                Marbles = new List<int>() { 0 };
                this.numPlayers = numPlayers;
                playerScores = new int[numPlayers];
            }

            public int PlayGame(int lastMarble)
            {
                for (int currentMarble = 1; currentMarble <= lastMarble; currentMarble++)
                {
                    NextMove(currentMarble);
                }

                return playerScores.Max();
            }

            private void NextMove(int marbleValue)
            {
                // Special rules and scoring applies if marble is multiple of 23
                if (marbleValue%23 == 0)
                {
                    activeMarblePos = activeMarblePos<7 ? activeMarblePos+Marbles.Count-7 : (activeMarblePos - 7) % Marbles.Count;
                    // Give the active player points for marble + bonus marble
                    playerScores[marbleValue % numPlayers]+= marbleValue + Marbles[activeMarblePos];
                    Marbles.RemoveAt(activeMarblePos);
                    // Need to re-check active marble in case the last marble was removed
                    activeMarblePos %= Marbles.Count;
                    return;
                }
                // Normal move by adding marble to circle
                activeMarblePos = (activeMarblePos + 2) % Marbles.Count;
                Marbles.Insert(activeMarblePos, marbleValue);
            }
        }

        public static int Puzzle1(int numPlayers, int lastMarble)
        {
            var mg = new MarbleGame(numPlayers);
            return mg.PlayGame(lastMarble);
        }

        public static int Puzzle2(string s)
        {
            return 0;
        }
    }
}
