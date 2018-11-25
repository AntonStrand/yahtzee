using System;
using Xunit;
using Yahtzee.model.category;

namespace YahtzeeTests
{
  public class LargeStraightTest
  {
    [Fact]
    public void ShouldNotAcceptMoreThanOneOfEach() => Assert.Throws<ArgumentException>(() => new LargeStraight(1, 1, 1, 1, 1));

    [Fact]
    public void ShouldAcceptValidInput()
    {
      var sut = new LargeStraight(2, 3, 4, 5, 6);
      var actual = sut.GetValue();
      Assert.Equal(20, actual);
    }

    [Fact]
    public void ShouldAcceptValidInput2()
    {
      var sut = new LargeStraight(4, 3, 2, 6, 5);
      var actual = sut.GetValue();
      Assert.Equal(20, actual);
    }
  }
}
