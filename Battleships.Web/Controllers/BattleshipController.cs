using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Battleships.Web.Controllers
{
    [Route ("api/[controller]")]
    public sealed class BattleshipController : Controller
    {
        private readonly Lazy<IBoardGenerator> boardGenerator;
        private readonly Lazy<IShipsGenerator> shipsGenerator;
        private readonly IBoardCache boardCache;

        public BattleshipController (
            Lazy<IBoardGenerator> boardGenerator,
            Lazy<IShipsGenerator> shipsGenerator,
            IBoardCache boardCache)
        {
            this.boardGenerator = boardGenerator;
            this.shipsGenerator = shipsGenerator;
            this.boardCache = boardCache;
        }

        [HttpGet ("[action]")]
        public IEnumerable<IEnumerable<char>> Board ()
        {
            if (boardCache.HasBoard ())
                return boardCache.Get ().ToViewModel ();

            var board = boardGenerator.Value.GenerateBoard ();
            var ships = shipsGenerator.Value.GenerateShips ();

            boardGenerator.Value.InsertShips (board, ships);

            boardCache.Set (board);

            return board.ToViewModel ();
        }

        public StrikeResult Strike (string field)
        {
            return StrikeResult.Miss;
        }
    }

    public enum StrikeResult
    {
        Hit,
        Miss
    }
}