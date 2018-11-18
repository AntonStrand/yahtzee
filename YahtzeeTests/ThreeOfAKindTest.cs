using System;
using Xunit;
using Yahtzee.model.category;

namespace YahtzeeTests
{
  public class ThreeOfAKindTest
  {
    [Fact]
    public void ShouldNotAcceptTheFirstTwoArgumentsBeingDifferent()
    {
      Assert.Throws<ArgumentException>(() => new ThreeOfAKind(1, 3, 1));
    }
  }
}
