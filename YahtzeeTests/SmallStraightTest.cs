using System;
using System.Collections.Generic;
using Xunit;
using Yahtzee.model.category;

namespace YahtzeeTests
{
  public class SmallStraightTest
  {
    [Fact]
    public void ShouldAcceptCorrectInput() => new SmallStraight(new List<int>() { 1, 2, 3, 4, 5 });

    [Fact]
    public void ShouldNotAcceptNull() => Assert.Throws<ArgumentNullException>(() => new SmallStraight(null));

    [Fact]
    public void ShouldNotAcceptLessThan5Items() => AssertArgumentOutOfRangeException(new List<int>());

    [Fact]
    public void ShouldNotAcceptMoreThan5Items() => AssertArgumentOutOfRangeException(new List<int>() { 1, 2, 3, 4, 5, 6 });

    [Fact]
    public void ShouldNotAcceptMoreThanOneOfEach()
    {
      Assert.Throws<ArgumentException>(() => new SmallStraight(new List<int>() { 1, 1, 1, 1, 1 }));

    }

    private void AssertArgumentOutOfRangeException(List<int> input) =>
      Assert.Throws<ArgumentOutOfRangeException>(() => new SmallStraight(input));
  }
}
