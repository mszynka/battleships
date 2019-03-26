using System;
using System.Text.RegularExpressions;
using Battleships.Web.Domain.Models;

namespace Battleships.Web.Services
{
    public interface IFieldToPointConverter
    {
        Point ConvertFrom(string fieldName);
    }

    public class FieldToPointConverter : IFieldToPointConverter
    {
        public Point ConvertFrom(string fieldName)
        {
            if (fieldName == null)
                throw new ArgumentNullException(nameof(fieldName));

            var x = (int) fieldName.Substring(0, 1) [0] - (int) 'A';
            var y = int.Parse(fieldName.Substring(1, fieldName.Length - 1)) - 1;
            return new Point(x, y);
        }
    }
}