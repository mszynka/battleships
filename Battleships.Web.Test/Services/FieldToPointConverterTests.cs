using Battleships.Web.Services;
using NUnit.Framework;

namespace Battleships.Web.Test.Services
{
    [Category("Unit")]

    public class FieldToPointConverterTests
    {
        private FieldToPointConverter converter;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.converter = new FieldToPointConverter();
        }

        [TestCaseSource(nameof(TestCases))]
        public void It_can_correctly_translate_field_name_to_point(string field, int x, int y)
        {
            var point = converter.ConvertFrom(field);

            Assert.That(point, Is.Not.Null);
            Assert.That(point.X, Is.EqualTo(x));
            Assert.That(point.Y, Is.EqualTo(y));
        }

        private static object[] TestCases = {
            new object[] { "A1", 0, 0 },
            new object[] { "A2", 0, 1 },
            new object[] { "B1", 1, 0 },
            new object[] { "B2", 1, 1 },
            new object[] { "F10", 5, 9 }
        };
    }
}