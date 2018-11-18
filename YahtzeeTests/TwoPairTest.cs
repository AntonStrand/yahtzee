using System;
using Xunit;
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
  }
}
