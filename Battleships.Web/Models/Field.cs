using System;
using System.Collections.Generic;

namespace Battleships.Web.Models
{
    public abstract class Field : IEquatable<Field>
    {
        protected char symbol;

        public Field (char symbol)
        {
            this.symbol = symbol;
        }

        internal virtual char ToViewModel () => symbol;

        internal abstract void Visit ();

        internal void TransitionTo (Field next)
        {
            this.symbol = next.symbol;
        }

        public bool Equals (Field other)
        {
            return symbol == other.symbol;
        }
    }

    public sealed class EmptyField : Field
    {
        public EmptyField () : base ('_') { }

        internal override void Visit ()
        {
            TransitionTo (new TestedField ());
        }
    }

    public sealed class ShipField : Field
    {
        public ShipField () : base ('O') { }

        internal override char ToViewModel () => 'S';

        internal override void Visit ()
        {
            TransitionTo (new DestroyedShipField ());
        }
    }

    public sealed class DestroyedShipField : Field
    {
        public DestroyedShipField () : base ('#') { }

        internal override void Visit ()
        { }
    }

    public sealed class TestedField : Field
    {
        public TestedField () : base ('^') { }

        internal override void Visit ()
        { }
    }
}