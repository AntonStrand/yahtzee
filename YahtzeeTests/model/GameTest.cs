using System;
using Xunit;
using Moq;
using YahtzeeApp.model;
using YahtzeeApp.model.rules;
using System.Collections.Generic;
using YahtzeeApp.model.category;
using System.Linq;

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

    [Fact]
    public void ShouldReturnAllPossibleCategories()
    {
      var dice = new Mock<Dice>();
      dice.Setup(d => d.GetValues()).Returns(new List<int> { 1, 1, 1, 1, 1 });
      var sut = new Game(new AllAvailableCategoriesStrategy(), dice.Object);
      var categories = sut.GetAvailableCategories();
      Assert.Equal(10, categories.Count);
    }

    [Fact]
    public void ShouldReturnNotReturnOccupiedCategory()
    {
      var dice = new Mock<Dice>();
      dice.Setup(d => d.GetValues()).Returns(new List<int> { 2, 3, 5, 5, 1 });
      var sut = new Game(new AllAvailableCategoriesStrategy(), dice.Object);
      sut.KeepCategory(new Pair(4, 4));
      var categories = sut.GetAvailableCategories();
      Assert.Null(categories.Find(IsOfType<Pair>));
    }

    [Fact]
    public void ShouldReturnNotReturnOccupiedCategories()
    {
      var dice = new Mock<Dice>();
      dice.Setup(d => d.GetValues()).Returns(new List<int> { 5, 5, 5, 5, 5 });
      var sut = new Game(new AllAvailableCategoriesStrategy(), dice.Object);
      sut.KeepCategory(new Pair(4, 4));
      sut.KeepCategory(new Yahtzee(5, 5, 5, 5, 5));
      var categories = sut.GetAvailableCategories();
      Assert.Empty(categories.Where(c => IsOfType<Pair>(c) || IsOfType<Yahtzee>(c)));
    }

    [Fact]
    public void ShouldKeepCategoriesBetweenThrows()
    {
      var dice = new Mock<Dice>();
      dice.Setup(d => d.GetValues()).Returns(new List<int> { 2, 3, 5, 5, 1 });
      var sut = new Game(new AllAvailableCategoriesStrategy(), dice.Object);
      sut.KeepCategory(new Pair(4, 4));
      sut.Throw();
      var categories = sut.GetAvailableCategories();
      Assert.Null(categories.Find(IsOfType<Pair>));
    }

    private bool IsOfType<T>(Object o) => o.GetType() == typeof(T);
  }
}