using System;
using System.Linq;
using Battleships.Web.Extensions;
using Battleships.Web.Models;
using Battleships.Web.Test.Utils;
using NUnit.Framework;

namespace Battleships.Web.Test.Models
{
    [Category ("Unit")]
    public class BoardTests
    {
        [TestCase (0)]
        [TestCase (1)]
        [TestCase (2)]
        [TestCase (3)]
        public void It_can_insert_correct_ship_field_into_board_horizontally_at_level (int yLevel)
        {
            // Arrange
            var board = new Board (6, yLevel + 1);

            // Act
            board.InsertShip (new Coordinates (new Point (0, yLevel), new Point (4, yLevel)));

            // Assert
            var boardArray = board.ToMatrixArray ();

            Assert.That (boardArray[0][yLevel], Is.InstanceOf<ShipField> (), board.DebuggerDisplayAt ($"0,{yLevel}"));
            Assert.That (boardArray[1][yLevel], Is.InstanceOf<ShipField> (), board.DebuggerDisplayAt ($"1,{yLevel}"));
            Assert.That (boardArray[2][yLevel], Is.InstanceOf<ShipField> (), board.DebuggerDisplayAt ($"2,{yLevel}"));
            Assert.That (boardArray[3][yLevel], Is.InstanceOf<ShipField> (), board.DebuggerDisplayAt ($"3,{yLevel}"));

            Assert.That (boardArray[4][yLevel], Is.InstanceOf<EmptyField> (), board.DebuggerDisplayAt ($"4,{yLevel}"));
            Assert.That (boardArray[5][yLevel], Is.InstanceOf<EmptyField> (), board.DebuggerDisplayAt ($"5,{yLevel}"));
        }

        [TestCase (0)]
        [TestCase (1)]
        [TestCase (2)]
        [TestCase (3)]
        public void It_can_insert_correct_ship_field_into_board_vertically_at_level (int xLevel)
        {
            // Arrange
            var board = new Board (xLevel + 1, 6);

            // Act
            board.InsertShip (new Coordinates (new Point (xLevel, 0), new Point (xLevel, 4)));

            // Assert
            var boardArray = board.ToMatrixArray ();

            Assert.That (boardArray[xLevel][0], Is.InstanceOf<ShipField> (), board.DebuggerDisplayAt ($"{xLevel}, 0"));
            Assert.That (boardArray[xLevel][1], Is.InstanceOf<ShipField> (), board.DebuggerDisplayAt ($"{xLevel}, 1"));
            Assert.That (boardArray[xLevel][2], Is.InstanceOf<ShipField> (), board.DebuggerDisplayAt ($"{xLevel}, 2"));
            Assert.That (boardArray[xLevel][3], Is.InstanceOf<ShipField> (), board.DebuggerDisplayAt ($"{xLevel}, 3"));

            Assert.That (boardArray[xLevel][4], Is.InstanceOf<EmptyField> (), board.DebuggerDisplayAt ($"{xLevel}, 4"));
            Assert.That (boardArray[xLevel][5], Is.InstanceOf<EmptyField> (), board.DebuggerDisplayAt ($"{xLevel}, 5"));
        }
    }
}