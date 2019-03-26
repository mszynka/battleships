using System.Linq;
using Battleships.Web.Domain.Models;

namespace Battleships.Web.Extensions
{
    internal static class BoardExtensions
    {
        internal static bool HasWon(this Board board)
        {
            return !board.Any(y => y.Any(x => x is ShipField));
        }

        internal static bool HasAllEmptyFieldsIn(this Board board, Coordinates coord)
        {
            return coord.Start.Y.To(coord.End.Y)
                .All(y => coord.Start.X.To(coord.End.X)
                    .All(x => board[y][x] is EmptyField));
        }
    }
}