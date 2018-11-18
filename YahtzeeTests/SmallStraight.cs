using System;
using Xunit;
using Yahtzee.model.category;

namespace YahtzeeTests
{
  public class SmallStraightTest
  {
    [Fact]
    public void ShouldNotAcceptNull()
    {
      Assert.Throws<ArgumentNullException>(() => new SmallStraight(null));
    }
  }
}
