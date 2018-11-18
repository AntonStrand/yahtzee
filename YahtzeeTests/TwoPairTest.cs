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
      var expected = 10;
      var input1 = new Mock<Pair>(3, 3);
      var input2 = new Mock<Pair>(4, 4);
      input1.Setup(pair => pair.GetValue()).Returns(6);
      input2.Setup(pair => pair.GetValue()).Returns(4);

      var sut = new TwoPair(input1.Object, input2.Object);
      var actual = sut.GetValue();
      Assert.Equal(expected, actual);
    }
  }
}
