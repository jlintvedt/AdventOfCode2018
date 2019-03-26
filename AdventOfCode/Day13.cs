using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Day13
    {
        public enum Track
        {
            empty,          // 
            horizontal,     // -
            vertical,       // |
            curveForward,   // /
            curveBackward,  // \
            intersection    // +
        }

        public enum Directions
        {
            north,  // ^
            east,   // >
            south,  // V
            west    // <
        }

        public class Cart
        {
            public Directions Direction;
            private int x, y;
            private int timesTurned;

            public int X { get { return x; } }
            public int Y { get { return y; } }

            public Cart(Directions dir, int startX, int startY)
            {
                Direction = dir;
                x = startX;
                y = startY;
            }

            public void Move(Track nextTrack)
            {
                // Move cart
                switch (Direction)
                {
                    case Directions.north:
                        y--;
                        break;
                    case Directions.south:
                        y++;
                        break;
                    case Directions.west:
                        x--;
                        break;
                    case Directions.east:
                        x++;
                        break;
                    default:
                        break;
                }
                // Update direction
                if (nextTrack == Track.intersection)
                {    // +
                    switch (timesTurned++ % 3)
                    {
                        case 0:
                            TurnLeft();
                            break;
                        case 2:
                            TurnRight();
                            break;
                        default:
                            break;
                    }
                }
                else if (nextTrack == Track.curveBackward)
                {  // \
                    if (Direction == Directions.north || Direction == Directions.south){
                        TurnLeft();
                    } else {
                        TurnRight();
                    }
                }
                else if (nextTrack == Track.curveForward)
                {   // /
                    if (Direction == Directions.north || Direction == Directions.south){
                        TurnRight();
                    } else {
                        TurnLeft();
                    }
                }
            }

            public void TurnLeft()
            {
                Direction--;
                // Wrap around
                if (Direction < 0){
                    Direction = Directions.west;
                }
            }

            public void TurnRight()
            {
                Direction++;
                // Wrap around
                if (Direction >= (Directions)4){
                    Direction = Directions.north;
                }
            }
        }

        public class TrackSystem
        {
            private int height, width;
            private Track[,] tracks;
            private bool[,] occupiedTrack;
            private List<Cart> carts;
            private List<Cart> crashedCarts;
            

            public int NumTracks
            {
                get
                {
                    var numTracks = 0;
                    foreach (var track in tracks){
                        if (track != Track.empty){
                            numTracks++;
                        }
                    }
                    return numTracks;
                }
            }

            public int NumCarts { get { return carts.Count; } }

            public Cart FirstCart { get { return carts.First(); } }

            public TrackSystem(string[] rawSystem)
            {
                height = rawSystem.Length;
                width = rawSystem[0].Length;
                tracks = new Track[height, width];
                occupiedTrack = new bool[height,width];
                carts = new List<Cart>();
                crashedCarts = new List<Cart>();

                // Parse input
                for (int h = 0; h < height; h++)
                {
                    var row = rawSystem[h].ToCharArray();
                    for (int w = 0; w < width; w++)
                    {
                        switch (row[w])
                        {
                            case ' ':
                                tracks[h,w] = Track.empty;
                                break;
                            // horizontal
                            case '<':
                                carts.Add(new Cart(Directions.west, w, h));
                                occupiedTrack[h, w] = true;
                                goto case '-';
                            case '>':
                                carts.Add(new Cart(Directions.east, w, h));
                                occupiedTrack[h, w] = true;
                                goto case '-';
                            case '-':
                                tracks[h, w] = Track.horizontal;
                                break;
                            // vertical
                            case '^':
                                carts.Add(new Cart(Directions.north, w, h));
                                occupiedTrack[h, w] = true;
                                goto case '|';
                            case 'v':
                                carts.Add(new Cart(Directions.south, w, h));
                                occupiedTrack[h, w] = true;
                                goto case '|';
                            case '|':
                            // curve
                                tracks[h, w] = Track.vertical;
                                break;
                            case '/':
                                tracks[h, w] = Track.curveForward;
                                break;
                            case '\\':
                                tracks[h, w] = Track.curveBackward;
                                break;
                            // intersection
                            case '+':
                                tracks[h, w] = Track.intersection;
                                break;
                            default:
                                throw new ArgumentException($"Unknown symbol in input map [{row[w]}]");
                        }
                    }
                }
            }

            public void NextTick(out string crashCoordinates)
            {
                crashCoordinates = "";
                carts = carts.OrderBy(c => c.Y).ThenBy(c => c.X).ToList();
                foreach (var cart in carts)
                {
                    // Remove cart from previous position
                    occupiedTrack[cart.Y, cart.X] = false;
                    // Move cart
                    cart.Move(FetchNextTrack(cart));
                    // Check for collisions
                    if (occupiedTrack[cart.Y, cart.X]==true)
                    {
                        CrashOccured(cart);
                        crashCoordinates += $"{cart.X},{cart.Y}";
                    }
                    occupiedTrack[cart.Y, cart.X] = true;
                }
                // Remove crashed carts
                foreach (var cart in crashedCarts)
                {
                    carts.Remove(cart);
                    occupiedTrack[cart.Y, cart.X] = false;
                }
                crashedCarts.Clear();
            }

            private Track FetchNextTrack(Cart cart)
            {
                switch (cart.Direction)
                {
                    case Directions.north:
                        return tracks[cart.Y-1, cart.X];
                    case Directions.east:
                        return tracks[cart.Y, cart.X+1];
                    case Directions.south:
                        return tracks[cart.Y+1, cart.X];
                    case Directions.west:
                        return tracks[cart.Y, cart.X-1];
                    default:
                        return Track.empty;
                }
            }

            private void CrashOccured(Cart crashingCart)
            {
                // Find self and other cart
                foreach (var cart in carts)
                {
                    if (cart.X == crashingCart.X && cart.Y == crashingCart.Y)
                    {
                        crashedCarts.Add(cart);
                    }
                }
            }
        }

        public static string Puzzle1(string input)
        {
            var ts = new TrackSystem(Common.ParseStringArray(input));
            string crashCoordinate;
            for (int i = 0; i < 1000; i++)
            {
                ts.NextTick(out crashCoordinate);
                if (crashCoordinate != "")
                {
                    return crashCoordinate;
                }
            }
            return "No crash in 1000 ticks";
        }

        public static string Puzzle2(string input)
        {
            var ts = new TrackSystem(Common.ParseStringArray(input));
            for (int i = 0; i < 100000; i++)
            {
                ts.NextTick(out string crashCoordinates);
                if (ts.NumCarts==1)
                {
                    return $"{ts.FirstCart.X},{ts.FirstCart.Y}";
                }
            }
            return $"No solution after 100000 ticks, still {ts.NumCarts} in system";
        }
    }
}
