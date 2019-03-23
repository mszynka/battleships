using System;

namespace Battleships.Web.Domain.Exceptions
{
    public class MissingBoardException : Exception
    {
        public MissingBoardException () : base ("No active board was found.")
        { }
    }
}