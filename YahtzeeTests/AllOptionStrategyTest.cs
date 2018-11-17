using System;
using Xunit;
using Moq;
using Yahtzee.model;
using Yahtzee.model.category;
using System.Collections.Generic;
using System.Linq;

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

    [Fact]
    public void ShouldContainATwoPair()
    {
      Dice dice = SetupPairMock();
      var sut = new AllOptionStrategy();
      var actual = sut.GetOptions(dice);
      Assert.IsType<List<Category>>(actual);
      Assert.NotEmpty(actual.Where(category => category.GetType() == typeof(TwoPair)));
    }

    private Dice SetupPairMock()
    {
      var die1 = new Mock<Die>();
      var die2 = new Mock<Die>();
      var die3 = new Mock<Die>();
      var die4 = new Mock<Die>();
      var die5 = new Mock<Die>();

      die1.Setup(die => die.GetValue()).Returns(4);
      die2.Setup(die => die.GetValue()).Returns(4);
      die3.Setup(die => die.GetValue()).Returns(5);
      die4.Setup(die => die.GetValue()).Returns(5);
      die5.Setup(die => die.GetValue()).Returns(1);

      return new Dice(die1.Object, die2.Object, die3.Object, die4.Object, die5.Object);
    }
  }
}
