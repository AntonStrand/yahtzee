using System;
using Xunit;
using Yahtzee.model.category;

namespace YahtzeeTests
{
  public class FourOfAKindTest
  {
    [Fact]
    public void ShouldAcceptIfAllMatch()
    {
      var input = 1;
      new FourOfAKind(input, input, input, input);
    }

    [Fact]
    public void ShouldNotAcceptTheFirstTwoArgumentsBeingDifferent()
    {
      Assert.Throws<ArgumentException>(() => new FourOfAKind(1, 3, 3, 3));
    }
  }
}
