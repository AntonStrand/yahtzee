using System;
using Xunit;
using Yahtzee.model;
using Moq;

namespace YahtzeeTests
{
  public class AllAvailableCategoriesTest
  {
    [Fact]
    public void ShouldAcceptDiceAndScoreBoard()
    {
      var fakePlayer = new Mock<ScoreBoard>();
      var fakeDie = new Mock<Die>();
      var fakeDice = new Mock<Dice>(fakeDie.Object, fakeDie.Object, fakeDie.Object, fakeDie.Object, fakeDie.Object);
      var sut = new AllAvailableCategoriesStrategy();
      sut.GetCategories(fakeDice.Object, fakePlayer.Object);
    }

    [Fact]
    public void ShouldNotAcceptNullDice()
    {
      var fakePlayer = new Mock<ScoreBoard>();
      var sut = new AllAvailableCategoriesStrategy();
      Assert.Throws<ArgumentNullException>(() => sut.GetCategories(null, fakePlayer.Object));
    }

    [Fact]
    public void ShouldNotAcceptNullScoreBoard()
    {
      var fakeDie = new Mock<Die>();
      var fakeDice = new Mock<Dice>(fakeDie.Object, fakeDie.Object, fakeDie.Object, fakeDie.Object, fakeDie.Object);
      var sut = new AllAvailableCategoriesStrategy();
      Assert.Throws<ArgumentNullException>(() => sut.GetCategories(fakeDice.Object, null));
    }
  }
}

