using System;
using Xunit;
using Moq;
using Yahtzee.model;

namespace YahtzeeTests
{
  public class AllOptionStrategyTest
  {
    [Fact]
    public void ShouldNotAcceptNull()
    {
      var sut = new AllOptionStrategy();
      Assert.Throws<ArgumentNullException>(() => sut.GetOptions(null));
    }
  }
}
