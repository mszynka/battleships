using System.Linq;
using Battleships.Web.Extensions;
using Battleships.Web.Models;

namespace Battleships.Web.Test.Utils
{
    public static class BoardTestUtils
    {
        public static string DebuggerDisplayAt(this Board board, string coord)
        {
            return $"At {coord} \n" +
                board.ToViewModel()
                .Select(row => string.Join(' ', row.ToArray()))
                .Join('\n');
        }
    }
}