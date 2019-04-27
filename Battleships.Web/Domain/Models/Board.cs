using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.Web.Domain.Exceptions;
using Battleships.Web.Extensions;

namespace Battleships.Web.Domain.Models
{
    public sealed class Board : List<List<Field>>
    {
        public readonly Point Limits;

        public Board(int x, int y)
        {
            Limits = new Point(x, y);

            foreach (var _ in 0. To(y))
                Add(Enumerable.Range(0, x + 1)
                    .Select(i => new EmptyField() as Field)
                    .ToList()
                );
        }

        public void InsertShip(Coordinates coord)
        {
            foreach (var y in coord.Start.Y.To(coord.End.Y))
            {
                foreach (var x in coord.Start.X.To(coord.End.X))
                {
                    this [y][x] = new ShipField();
                }
            }
        }

        public void Strike(Point point)
        {
            this [point.Y][point.X] = this [point.Y][point.X].Strike();
        }

        public bool CanInsert(Coordinates coordinates)
        {
            if (!coordinates.IsInLimits(Limits))
                return false;

            foreach (var y in coordinates.Start.Y.To(coordinates.End.Y))
            {
                foreach (var x in coordinates.Start.X.To(coordinates.End.X))
                {
                    if (!(this [y][x] is EmptyField))
                        return false;
                }
            }

            return true;
        }

        public bool HasWon()
        {
            return !this.Any(y => y.Any(x => x is ShipField));
        }
    }
}