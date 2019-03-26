using Battleships.Web.Services;
using NUnit.Framework;

namespace Battleships.Web.Test.Services
{
    [Category("Unit")]
    public class BoardGeneratorTests
    {
        private BoardGenerator generator;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.generator = new BoardGenerator();
        }

        [Test]
        public void It_can_generate_board_with_correct_dimensions()
        {
            var board = this.generator.GenerateBoard();

            Assert.That(board.Limits.X, Is.EqualTo(9));
            Assert.That(board.Limits.Y, Is.EqualTo(9));

            Assert.That(board, Has.Exactly(10).Items);
            Assert.That(board, Has.All.Exactly(10).Items);
        }
    }
}