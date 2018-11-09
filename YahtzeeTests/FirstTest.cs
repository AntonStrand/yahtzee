using Xunit;
using yahtzee;

namespace MyFirstUnitTests
{
    public class FirstTest
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }

        [Fact]
        public void yahtzeeTest()
        {
            Assert.Equal(42, TestClass.testingTest());
        }

        int Add(int x, int y)
        {
            return x + y;
        }
    }
}
