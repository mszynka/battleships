using System;
using System.Collections.Generic;
using Battleships.Web.Domain.Exceptions;
using Battleships.Web.Domain.Models;

namespace Battleships.Web.Services
{
  public interface IBoardGenerator
  {
    Board GenerateBoard();
    Board InsertShips(Board board, IEnumerable<Ship> ships);
  }

  public class BoardGenerator : IBoardGenerator
  {
    public Board GenerateBoard()
    {
      return new Board(9, 9);
    }

    public Board InsertShips(Board board, IEnumerable<Ship> ships)
    {
      foreach (var ship in ships)
      {
        while (true)
        {
          var coordinates = GeneratePointsFor(board, ship);

          if (!board.CanInsert(coordinates))
            continue;

          board.InsertShip(coordinates);
          break;
        }
      }

      return board;
    }

    private Coordinates GeneratePointsFor(Board board, Ship ship)
    {
      var rand = new Random(Guid.NewGuid().GetHashCode());

      var direction = rand.Next(0, 2) == 1;
      var startX = rand.Next(0, direction ? board.Limits.X : board.Limits.X - ship.Length);
      var startY = rand.Next(0, direction ? board.Limits.Y - ship.Length : board.Limits.Y);

      return new Coordinates(
        new Point(startX, startY),
        new Point(
          direction ? startX : startX + ship.Length - 1,
          direction ? startY + ship.Length - 1 : startY
        ));
    }
  }
}