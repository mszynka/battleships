using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.Web.Services;
using Battleships.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Battleships.Web.Controllers
{
    [Route("api/[controller]")]
    public sealed class BattleshipController : Controller
    {
        private readonly IBoardGenerator boardGenerator;
        private readonly IShipsGenerator shipsGenerator;
        private readonly IBoardCache boardCache;
        private readonly IFieldToPointConverter fieldToPointConverter;

        public BattleshipController(
            IBoardGenerator boardGenerator,
            IShipsGenerator shipsGenerator,
            IBoardCache boardCache,
            IFieldToPointConverter fieldToPointConverter)
        {
            this.boardGenerator = boardGenerator;
            this.shipsGenerator = shipsGenerator;
            this.boardCache = boardCache;
            this.fieldToPointConverter = fieldToPointConverter;
        }

        [HttpGet("[action]")]
        public BoardViewModel Board()
        {
            if (boardCache.HasBoard())
                return new BoardViewModel(boardCache.Get());

            var board = GenerateNewBoard();

            return new BoardViewModel(board);
        }

        private Domain.Models.Board GenerateNewBoard()
        {
            var board = boardGenerator.GenerateBoard();
            var ships = shipsGenerator.GenerateShips();

            boardGenerator.InsertShips(board, ships);

            boardCache.Set(board);

            return board;
        }

        [HttpPost("[action]")]
        public void Restart()
        {
            GenerateNewBoard();
        }

        [HttpPost("[action]")]
        public void Strike([FromQuery] string field)
        {
            if (!boardCache.HasBoard())
                return;

            var board = boardCache.Get();
            var point = fieldToPointConverter.ConvertFrom(field);
            board.Strike(point);

            boardCache.Set(board);
        }
    }
}