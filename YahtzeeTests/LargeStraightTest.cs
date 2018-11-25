using System;
using Xunit;
using Yahtzee.model.category;

namespace YahtzeeTests
{
  public class LargeStraightTest
  {
    [Fact]
    public void ShouldNotAcceptMoreThanOneOfEach() => Assert.Throws<ArgumentException>(() => new LargeStraight(1, 1, 1, 1, 1));
  }
}
