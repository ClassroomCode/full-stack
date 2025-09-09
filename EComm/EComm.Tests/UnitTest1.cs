using EComm.Controllers;
using EComm.DataAccess;

namespace EComm.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var c = new Calculator();

            // Action
            var sum = c.Add(3, 4);

            // Assert
            Assert.Equal(7, sum);
        }
    }
}
