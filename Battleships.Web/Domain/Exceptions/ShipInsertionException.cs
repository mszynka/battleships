using System;

namespace Battleships.Web.Domain.Exceptions
{
  public class ShipInsertionException : Exception
  {
    public ShipInsertionException() : base("Cannot insert ship in current location.")
    { }
  }
}