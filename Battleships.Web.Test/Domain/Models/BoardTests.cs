using System;
using System.Linq;
using Battleships.Web.Domain.Models;
using Battleships.Web.Extensions;
using Battleships.Web.Test.Utils;
using NUnit.Framework;

namespace Battleships.Web.Test.Domain.Models
{
  [Category("Unit")]
  public class BoardTests
  {
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    public void It_can_insert_correct_ship_field_into_board_horizontally_at_level(int yLevel)
    {
      // Arrange
      var board = new Board(6, yLevel + 1);

      // Act
      board.InsertShip(new Coordinates(new Point(0, yLevel), new Point(3, yLevel)));

      // Assert
      var boardArray = board.ToMatrixArray();

      Assert.That(boardArray[yLevel][0], Is.InstanceOf<ShipField>(), board.DebuggerDisplayAt($"0,{yLevel}"));
      Assert.That(boardArray[yLevel][1], Is.InstanceOf<ShipField>(), board.DebuggerDisplayAt($"1,{yLevel}"));
      Assert.That(boardArray[yLevel][2], Is.InstanceOf<ShipField>(), board.DebuggerDisplayAt($"2,{yLevel}"));
      Assert.That(boardArray[yLevel][3], Is.InstanceOf<ShipField>(), board.DebuggerDisplayAt($"3,{yLevel}"));

      Assert.That(boardArray[yLevel][4], Is.InstanceOf<EmptyField>(), board.DebuggerDisplayAt($"4,{yLevel}"));
      Assert.That(boardArray[yLevel][5], Is.InstanceOf<EmptyField>(), board.DebuggerDisplayAt($"5,{yLevel}"));
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    public void It_can_insert_correct_ship_field_into_board_vertically_at_level(int xLevel)
    {
      // Arrange
      var board = new Board(xLevel + 1, 6);

      // Act
      board.InsertShip(new Coordinates(new Point(xLevel, 0), new Point(xLevel, 3)));

      // Assert
      var boardArray = board.ToMatrixArray();

      Assert.That(boardArray[0][xLevel], Is.InstanceOf<ShipField>(), board.DebuggerDisplayAt($"{xLevel}, 0"));
      Assert.That(boardArray[1][xLevel], Is.InstanceOf<ShipField>(), board.DebuggerDisplayAt($"{xLevel}, 1"));
      Assert.That(boardArray[2][xLevel], Is.InstanceOf<ShipField>(), board.DebuggerDisplayAt($"{xLevel}, 2"));
      Assert.That(boardArray[3][xLevel], Is.InstanceOf<ShipField>(), board.DebuggerDisplayAt($"{xLevel}, 3"));

      Assert.That(boardArray[4][xLevel], Is.InstanceOf<EmptyField>(), board.DebuggerDisplayAt($"{xLevel}, 4"));
      Assert.That(boardArray[5][xLevel], Is.InstanceOf<EmptyField>(), board.DebuggerDisplayAt($"{xLevel}, 5"));
    }
  }
}