using System;
using Xunit;
using Yahtzee.model.category;

namespace YahtzeeTests
{
  public class FullHouseTest
  {
    [Fact]
    public void ShouldNotAcceptNull()
    {
      Assert.Throws<ArgumentNullException>(() => new FullHouse(null, null));
    }
  }
}
