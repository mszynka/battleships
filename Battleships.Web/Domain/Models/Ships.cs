namespace Battleships.Web.Domain.Models
{
  public abstract class Ship
  {
    public Ship(int length)
    {
      Length = length;
    }

    public int Length { get; }
  }

  public class Battleship : Ship
  {
    public Battleship() : base(5) { }
  }

  public class Destroyer : Ship
  {
    public Destroyer() : base(4) { }
  }
}