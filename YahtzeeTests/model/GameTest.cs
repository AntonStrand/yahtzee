using System;
using Xunit;
using Moq;
using YahtzeeApp.model;
using YahtzeeApp.model.rules;

namespace YahtzeeTests
{
  public class GameTest
  {
    [Fact]
    public void ShouldNotAcceptNullStrategy()
    {
      var fakeDice = new Mock<Dice>();
      Assert.Throws<ArgumentNullException>(() => new Game(null, fakeDice.Object));
    }

    [Fact]
    public void ShouldNotAcceptNullStrategyIfNotDiceIsProvided() =>
      Assert.Throws<ArgumentNullException>(() => new Game(null));

    [Fact]
    public void ShouldReturnTheProvidedDice()
    {
      var fakeDice = new Mock<Dice>();
      var sut = new Game(new AllAvailableCategoriesStrategy(), fakeDice.Object);
      var actual = sut.GetDice();
      Assert.Equal(fakeDice.Object, actual);
    }

    [Fact]
    public void ShouldInitDiceIfNotProvided()
    {
      var sut = new Game(new AllAvailableCategoriesStrategy(), null);
      var output = sut.GetDice();
      Assert.True(output is Dice);
    }

    [Fact]
    public void ShouldNoNeedToProvideDiceAsNull()
    {
      var sut = new Game(new AllAvailableCategoriesStrategy());
      var output = sut.GetDice();
      Assert.True(output is Dice);
    }

    [Fact]
    public void ShouldAcceptAllAvailableCategoriesStrategy() =>
      new Game(new AllAvailableCategoriesStrategy());

    [Fact]
    public void ShouldThrowDice()
    {
      var mockDice = new Mock<Dice>();
      var sut = new Game(new AllAvailableCategoriesStrategy(), mockDice.Object);
      sut.Throw();
      mockDice.Verify(dice => dice.Throw(), Times.Once);
    }

    [Fact]
    public void ShouldThrowAnExceptionIfTheRoundIsDone()
    {
      var sut = new Game(new AllAvailableCategoriesStrategy());
      sut.Throw();
      sut.Throw();
      sut.Throw();
      Assert.Throws<InvalidOperationException>(() => sut.Throw());

    }

    [Fact]
    public void ShouldReturnNumberOfThrowsLeft()
    {
      var sut = new Game(new AllAvailableCategoriesStrategy());
      Assert.Equal(expected: 3, actual: sut.GetNumberOfThrowsLeft());
    }

    [Fact]
    public void ShouldDecreaseNumberOfThrowsAfterEachThrow()
    {
      var sut = new Game(new AllAvailableCategoriesStrategy());
      sut.Throw();
      Assert.Equal(expected: 2, actual: sut.GetNumberOfThrowsLeft());
    }

    [Fact]
    public void ShouldKeepSpecifiedDie()
    {
      var mockDie = new Mock<Die>();
      var stubDie = new Mock<Die>();
      var dice = new DiceImplemented(mockDie.Object, stubDie.Object, stubDie.Object, stubDie.Object, stubDie.Object);
      var sut = new Game(new AllAvailableCategoriesStrategy(), dice);
      sut.KeepDie(DiceList.Die1);
      sut.Throw();
      mockDie.Verify(die => die.Throw(), Times.Never);
    }

    [Fact]
    public void ShouldKeepSpecifiedDice()
    {
      var mockDie1 = new Mock<Die>();
      var mockDie3 = new Mock<Die>();
      var stubDie = new Mock<Die>();
      var dice = new DiceImplemented(mockDie1.Object, stubDie.Object, mockDie3.Object, stubDie.Object, stubDie.Object);
      var sut = new Game(new AllAvailableCategoriesStrategy(), dice);
      sut.KeepDie(DiceList.Die1);
      sut.KeepDie(DiceList.Die3);
      sut.Throw();
      mockDie1.Verify(die => die.Throw(), Times.Never);
      mockDie3.Verify(die => die.Throw(), Times.Never);
    }

    [Fact]
    public void ShouldReturnFalseIfThereIsStillAvailableThrowsForTheRound()
    {
      var sut = new Game(new AllAvailableCategoriesStrategy());
      Assert.False(sut.IsRoundDone());
    }

    [Fact]
    public void ShouldReturnTrueIfThereIsNoMoreThrowsForTheRound()
    {
      var sut = new Game(new AllAvailableCategoriesStrategy());
      sut.Throw();
      sut.Throw();
      sut.Throw();
      Assert.True(sut.IsRoundDone());
    }

    [Fact]
    public void ShouldResetTheNumberOfThrows()
    {
      var sut = new Game(new AllAvailableCategoriesStrategy());
      sut.Throw();
      sut.Throw();
      sut.Throw();
      sut.StartNextRound();
      Assert.False(sut.IsRoundDone());
    }
  }
}