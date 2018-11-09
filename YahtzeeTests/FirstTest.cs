using Xunit;
using yahtzee;

namespace MyFirstUnitTests
{
    public class FirstTest
    {

        [Fact]
        public void yahtzeeTestTestTestReturningTen()
        {
            Assert.Equal(10, TestClass.testingTestReturningTen());
        }
    }
}
