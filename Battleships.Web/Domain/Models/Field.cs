using System;
using System.Collections.Generic;

namespace Battleships.Web.Domain.Models
{
    public abstract class Field : IEquatable<Field>
    {
        public char Symbol { get; }

        public Field(char symbol)
        {
            this.Symbol = symbol;
        }

        internal abstract Field Strike();

        public bool Equals(Field other)
        {
            return Symbol == other.Symbol;
        }
    }

    public sealed class EmptyField : Field
    {
        internal static char SymbolDescriptor = 'e';

        public EmptyField() : base(EmptyField.SymbolDescriptor) { }

        internal override Field Strike() => new TestedField();
    }

    public sealed class ShipField : Field
    {
        public ShipField() : base(EmptyField.SymbolDescriptor) { }

        internal override Field Strike() => new DestroyedShipField();
    }

    public sealed class DestroyedShipField : Field
    {
        public DestroyedShipField() : base('d') { }

        internal override Field Strike() => this;
    }

    public sealed class TestedField : Field
    {
        public TestedField() : base('t') { }

        internal override Field Strike() => this;
    }
}