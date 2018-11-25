using System;
using System.Collections.Generic;
using Xunit;
using Yahtzee.model.category;

namespace YahtzeeTests
{
  public class SmallStraightTest
  {
    [Fact]
    public void ShouldAcceptCorrectInput() => new SmallStraight(1, 2, 3, 4, 5);

    [Fact]
    public void ShouldNotAcceptMoreThanOneOfEach() => Assert.Throws<ArgumentException>(() => new SmallStraight(1, 1, 1, 1, 1));

    [Theory]
    [InlineData(1, 2, 3, 4, 5)]
    [InlineData(4, 3, 2, 5, 1)]
    public void ShouldSetValueIfInputIsCorrect(int v1, int v2, int v3, int v4, int v5)
    {
      var sut = new SmallStraight(v1, v2, v3, v4, v5);
      var actual = sut.GetValue();
      var expected = 15;
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ShouldNotAcceptInvalidInput()
    {
      Assert.Throws<ArgumentException>(() => new SmallStraight(1, 2, 3, 4, 6));
    }
  }
}
