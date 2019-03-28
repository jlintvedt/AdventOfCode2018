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
            public LinkedList<int> Marbles;
            private LinkedListNode<int> activeMarble;
            private int activeMarblePos = 0;
            private int numPlayers;
            private long[] playerScores;

            public MarbleGame(int numPlayers)
            {
                Marbles = new LinkedList<int>();
                activeMarble = Marbles.AddFirst(0);
                this.numPlayers = numPlayers;
                playerScores = new long[numPlayers];
            }

            public long PlayGame(int lastMarble)
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
                    int backJumps = 7;
                    // If at start of list => wrap around to end
                    if (activeMarblePos < 7)
                    {
                        backJumps -= (activeMarblePos+1);
                        activeMarblePos = Marbles.Count-1;
                        activeMarble = Marbles.Last;
                    }
                    for (int i = 0; i < backJumps; i++)
                    {
                        activeMarble = activeMarble.Previous;
                    }
                    activeMarblePos -= backJumps;
                    // Give the active player points for marble + bonus marble.
                    playerScores[marbleValue % numPlayers]+= marbleValue + activeMarble.Value;
                    var removeMarble = activeMarble;
                    activeMarble = activeMarble.Next;
                    Marbles.Remove(removeMarble);
                    // Need to wrap around list if last marble was removed
                    if (activeMarble == null)
                    {
                        activeMarble = Marbles.First;
                        activeMarblePos = 0;
                    }
                } else
                {
                    // Normal move by adding marble to circle.
                    if (activeMarblePos++ + 1 >= Marbles.Count)
                    {
                        activeMarble = Marbles.First;
                        activeMarblePos = 0;
                    }
                    else
                    {
                        activeMarble = activeMarble.Next;
                    }
                    activeMarble = Marbles.AddAfter(activeMarble, marbleValue);
                    activeMarblePos++;
                }
            }
        }

        public static long Puzzle1(int numPlayers, int lastMarble)
        {
            var mg = new MarbleGame(numPlayers);
            return mg.PlayGame(lastMarble);
        }
    }
}
