using System.Collections.Generic;
using System.Linq;
using Battleships.Web.Domain.Models;
using Battleships.Web.Extensions;

namespace Battleships.Web.ViewModels
{
    public class BoardViewModel
    {
        public BoardViewModel(Board board)
        {
            Board = board
                .Select(row => row
                    .Select(i => i.Symbol));

            HasWon = board.HasWon();
        }

        public IEnumerable<IEnumerable<char>> Board { get; set; }

        public bool HasWon { get; set; }
    }
}