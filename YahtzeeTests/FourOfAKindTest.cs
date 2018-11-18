using System;
using Xunit;
using Yahtzee.model.category;

namespace YahtzeeTests
{
  public class FourOfAKindTest
  {
    [Fact]
    public void ShouldNotAcceptTheFirstTwoArgumentsBeingDifferent()
    {
      Assert.Throws<ArgumentException>(() => new FourOfAKind(1, 3, 3, 3));
    }
  }
}
