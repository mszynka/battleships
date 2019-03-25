using Battleships.Web.Domain.Exceptions;
using Battleships.Web.Models;

namespace Battleships.Web.Services
{
    public interface IBoardCache
    {
        bool HasBoard();
        Board Get();
        void Set(Board board);
        void Reset();
    }

    public class BoardCache : IBoardCache
    {
        private Board board = null;

        public bool HasBoard()
        {
            return board != null;
        }

        public Board Get()
        {
            if (!HasBoard())
                throw new MissingBoardException();

            return board;
        }

        public void Set(Board board)
        {
            this.board = board;
        }

        public void Reset()
        {
            this.board = null;
        }
    }
}