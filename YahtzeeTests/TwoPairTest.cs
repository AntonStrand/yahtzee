using System;
using Xunit;
using Moq;
using Yahtzee.model.category;

namespace YahtzeeTests
{
  public class TwoPairTest
  {
    [Fact]
    public void ShouldNotAcceptFirstPairToBeNull()
    {
      Assert.Throws<ArgumentNullException>(() => new TwoPair(null, new Pair(1, 1)));
    }

    [Fact]
    public void ShouldNotAcceptSecondPairToBeNull()
    {
      Assert.Throws<ArgumentNullException>(() => new TwoPair(new Pair(1, 1), null));
    }

    [Fact]
    public void ShouldReturnValueOfBothPairs()
    {
      var sut = SetupValueTest(4, 6);

      var expected = 10;
      var actual = sut.GetValue();
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ShouldReturnValueOfBothPairs1()
    {
      var sut = SetupValueTest(12, 10);

      var expected = 22;
      var actual = sut.GetValue();
      Assert.Equal(expected, actual);
    }

    private TwoPair SetupValueTest(int p1Value, int p2Value)
    {
      var input1 = new Mock<Pair>(1, 1);
      var input2 = new Mock<Pair>(2, 2);
      input1.Setup(pair => pair.GetValue()).Returns(p1Value);
      input2.Setup(pair => pair.GetValue()).Returns(p2Value);

      return new TwoPair(input1.Object, input2.Object);
    }
  }
}
