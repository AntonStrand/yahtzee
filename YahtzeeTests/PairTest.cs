using System;
using Xunit;
using Yahtzee.model.category;

namespace YahtzeeTests
{
  public class PairTest
  {

    [Fact]
    public void ShouldNotAcceptDifferentValues()
    {
      Assert.Throws<ArgumentException>(() => new Pair(1, 3));
    }
  }
}
