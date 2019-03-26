using System.Collections.Generic;
using Battleships.Web.Domain.Models;

namespace Battleships.Web.Services
{
    public interface IShipsGenerator
    {
        IEnumerable<Ship> GenerateShips();
    }

    public class ShipsGenerator : IShipsGenerator
    {
        public IEnumerable<Ship> GenerateShips()
        {
            yield return new Battleship();

            yield return new Destroyer();
            yield return new Destroyer();
        }
    }
}