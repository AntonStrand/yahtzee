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

    [Fact]
    public void ShouldSetValueIfInputIsCorrect()
    {
      var sut = new SmallStraight(1, 2, 3, 4, 5);
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
