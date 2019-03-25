using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.Web.Domain.Exceptions;
using Battleships.Web.Extensions;
using Battleships.Web.Models;

namespace Battleships.Web.Models
{
    public sealed class Board : List<List<Field>>
    {
        public readonly Point Limits;

        public Board(int x, int y)
        {
            Limits = new Point(x, y);

            foreach (var _ in 0. To(y))
                Add(Enumerable.Repeat(new EmptyField() as Field, x + 1).ToList());
        }

        public void InsertShip(Coordinates coord)
        {
            if (!CanInsert(coord))
                throw new ShipInsertionException();

            foreach (var y in coord.Start.Y.To(coord.End.Y))
            {
                foreach (var x in coord.Start.X.To(coord.End.X))
                {
                    this [y][x] = new ShipField();
                }
            }
        }

        public void Visit(Point point)
        {
            Read(point).Visit();
        }

        public Field Read(Point point)
        {
            return this [point.Y][point.X];
        }

        public IEnumerable<IEnumerable<char>> ToViewModel()
        {
            return this
                .Select(row => row
                    .Select(i => i.ToViewModel()));
        }

        private bool CanInsert(Coordinates coord)
        {
            if (0 > coord.Start.X || coord.Start.X > this.Limits.X ||
                0 > coord.Start.Y || coord.Start.Y > this.Limits.Y ||
                0 > coord.End.X || coord.End.X > this.Limits.X ||
                0 > coord.End.Y || coord.End.Y > this.Limits.Y)
                return false;

            return coord.Start.Y.To(coord.End.Y)
                .All(y => coord.Start.X.To(coord.End.X)
                    .All(x => this [y][x] is EmptyField));
        }

        public Field[][] ToMatrixArray()
        {
            return this
                .Select(row => row.ToArray())
                .ToArray();
        }
    }
}