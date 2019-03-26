using System.Linq;
using Battleships.Web.Domain.Models;
using Battleships.Web.Extensions;

namespace Battleships.Web.Test.Utils
{
    internal static class BoardTestUtils
    {
        internal static string DebuggerDisplayAt(this Board board, string coord)
        {
            return $"At {coord} \n" +
                board
                .Select(y => y.Select(x => x.Symbol))
                .Select(row => string.Join(' ', row.ToArray()))
                .Join('\n');
        }

        internal static Field[][] ToMatrixArray(this Board board)
        {
            return board
                .Select(row => row.ToArray())
                .ToArray();
        }
    }
}