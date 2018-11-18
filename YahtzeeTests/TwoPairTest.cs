using System;
using Xunit;
using Moq;
using Yahtzee.model.category;

namespace YahtzeeTests
{
  public class TwoPairTest
  {
    [Fact]
    public void ShouldNotAcceptFirstPairToBeNull() => AssertArgumentNullException(null, new Pair(1, 1));

    [Fact]
    public void ShouldNotAcceptSecondPairToBeNull() => AssertArgumentNullException(new Pair(1, 1), null);

    [Fact]
    public void ShouldReturnValueOfBothPairs() => AssertValue(10, 4, 6);

    [Fact]
    public void ShouldReturnValueOfBothPairs1() => AssertValue(22, 12, 10);

    private void AssertValue(int expected, int p1Value, int p2Value)
    {
      var input1 = new Mock<Pair>(1, 1);
      var input2 = new Mock<Pair>(2, 2);
      input1.Setup(pair => pair.GetValue()).Returns(p1Value);
      input2.Setup(pair => pair.GetValue()).Returns(p2Value);

      var sut = new TwoPair(input1.Object, input2.Object);

      var actual = sut.GetValue();
      Assert.Equal(expected, actual);
    }

    private void AssertArgumentNullException(Pair input1, Pair input2) =>
      Assert.Throws<ArgumentNullException>(() => new TwoPair(input1, input2));
  }
}
