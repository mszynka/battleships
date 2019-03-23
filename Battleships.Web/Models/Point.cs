using System;

namespace Battleships.Web.Models
{
    public struct Point
    {
        public Point (int x, int y)
        {
            if (x < 0)
                throw new ArgumentException (nameof (x));

            if (y < 0)
                throw new ArgumentException (nameof (y));

            X = x;
            Y = y;
        }

        public int X { get; }

        public int Y { get; }
    }

    public struct Coordinates
    {
        public Coordinates (Point start, Point end)
        {
            Start = start;
            End = end;
        }

        public Point Start { get; }

        public Point End { get; }
    }
}