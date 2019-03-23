using System;
using System.Collections.Generic;
using Battleships.Web.Domain.Exceptions;
using Battleships.Web.Models;

namespace Battleships.Web.Services
{
  public interface IBoardGenerator
    {
        Board GenerateBoard ();
        Board InsertShips (Board board, IEnumerable<Ship> ships);
    }

    public class BoardGenerator : IBoardGenerator
    {
        public Board GenerateBoard ()
        {
            return new Board (10, 10);
        }

        public Board InsertShips (Board board, IEnumerable<Ship> ships)
        {
            foreach (var ship in ships)
            {
                while (true)
                {
                    try
                    {
                        var coordinates = GeneratePointsFor (board, ship);
                        board.InsertShip (coordinates);
                        break;
                    }
                    catch (ShipInsertionException)
                    {
                        //NOTE: Retry on insertion failure
                    }
                }
            }

            return board;
        }

        //TODO: Refactor this to OOP/simpler design
        private Coordinates GeneratePointsFor (Board board, Ship ship)
        {
            var direction = new Random ().Next (0, 1) == 1;
            var startX = new Random ().Next (0, direction ? board.Limits.X : board.Limits.X - ship.Length);
            var startY = new Random ().Next (0, direction ? board.Limits.Y - ship.Length : board.Limits.Y);

            return new Coordinates (
                new Point (startX, startY),
                new Point (
                    direction ? startX : startX + ship.Length,
                    direction ? startY + ship.Length : startY
                ));
        }
    }
}