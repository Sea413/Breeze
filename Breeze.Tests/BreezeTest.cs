using Breeze.Models;
using Xunit;

namespace Breeze.Tests
{
    public class BreezeTest
    {
        [Fact]
        public void GetDescriptionTest()
        {
            //Arrange
            var game = new Game();
            game.Description = "PanicMode";

            //Act
            var result = game.Description;

            //Assert
            Assert.Equal("PanicMode", result);
        }
    }
}