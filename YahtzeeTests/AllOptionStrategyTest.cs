using System;
using Xunit;
using Moq;
using Yahtzee.model;
using Yahtzee.model.category;
using System.Collections.Generic;

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

    [Fact]
    public void ShouldNotAcceptNull()
    {
      var sut = new AllOptionStrategy();
      Assert.Throws<ArgumentNullException>(() => sut.GetOptions(null));
    }

    [Fact]
    public void ShouldAlwaysReturnMinimumOneOption()
    {
      Die die = new DieImplemented();
      Dice dice = new Dice(die, die, die, die, die);
      var sut = new AllOptionStrategy();
      var actual = sut.GetOptions(dice).Count;
      Assert.InRange(actual, 1, 13);
    }

    [Fact]
    public void ShouldReturnListOfCategories()
    {
      Die die = new DieImplemented();
      Dice dice = new Dice(die, die, die, die, die);
      var sut = new AllOptionStrategy();
      var actual = sut.GetOptions(dice);
      Assert.IsType<List<Category>>(actual);
    }
  }
}
