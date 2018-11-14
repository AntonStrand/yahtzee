using System;
using Xunit;
using Moq;
using Yahtzee.model;

namespace YahtzeeTests
{
  public class AllOptionStrategyTest
  {
    [Fact]
    public void ShouldAcceptDice()
    {
      Die die = new DieImplemented();
      Dice dice = new Dice(die, die, die, die, die);
      var sut = new AllOptionStrategy();

      try
      {
        sut.GetOptions(dice);
        Assert.True(true);
      }
      catch (System.Exception)
      {
        Assert.True(false, "Should not throw Exception");
      }
    }

    public void ShouldNotAcceptNull()
    {
      var sut = new AllOptionStrategy();
      Assert.Throws<ArgumentNullException>(() => sut.GetOptions(null));
    }
  }
}
