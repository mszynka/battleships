using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.Web.Domain.Exceptions;
using Battleships.Web.Models;

namespace Battleships.Web.Models
{
    public class Board : List<List<Field>>
    {
        public readonly Point Limits;

        public Board (int x, int y)
        {
            Limits = new Point (x, y);
            foreach (var _ in Enumerable.Range (0, y))
                Add (Enumerable.Repeat (new EmptyField () as Field, x).ToList ());
        }

        public void InsertShip (Coordinates coord)
        {
            if (!CanInsert (coord))
                throw new ShipInsertionException ();

            foreach (var y in Enumerable.Range (coord.Start.Y, coord.End.Y - coord.Start.Y))
            {
                foreach (var x in Enumerable.Range (coord.Start.X, coord.End.X - coord.Start.X))
                {
                    this [x][y] = new ShipField ();
                }
            }
        }

        public void Visit (Point point)
        {
            Read (point).Visit ();
        }

        public Field Read (Point point)
        {
            return this [point.X][point.Y];
        }

        public IEnumerable<IEnumerable<char>> ToViewModel ()
        {
            return this
                .Select (row => row
                    .Select (i => i.ToViewModel ()));
        }

        private bool CanInsert (Coordinates coord)
        {
            var emptyField = new EmptyField ();
            return Enumerable.Range (coord.Start.Y, coord.End.Y - coord.Start.Y)
                .All (y => Enumerable.Range (coord.Start.X, coord.End.X - coord.Start.X)
                    .All (x => this [x][y] == emptyField));
        }

        public Field[][] ToMatrixArray ()
        {
            return this
                .Select(row => row.ToArray())
                .ToArray();
        }
    }
}