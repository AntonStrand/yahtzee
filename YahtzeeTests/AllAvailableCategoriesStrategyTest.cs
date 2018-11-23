using System;
using Xunit;
using Yahtzee.model;
using Yahtzee.model.category;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace YahtzeeTests
{
  public class AllAvailableCategoriesTest
  {
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
      var fakeDice = new Mock<Dice>();
      var sut = new AllAvailableCategoriesStrategy();
      Assert.Throws<ArgumentNullException>(() => sut.GetCategories(fakeDice.Object, null));
    }

    [Fact]
    public void ShouldReturnPair() => AssertType<Pair>(new List<int>() { 5, 5, 1, 2, 4 });

    [Fact]
    public void ShouldReturnTwoPair() => AssertType<TwoPair>(new List<int> { 1, 1, 2, 2, 4 });

    [Theory]
    [InlineData(5, 6, 6, 2, 4, 12)]
    [InlineData(4, 1, 6, 2, 4, 8)]
    public void ShouldReturnPairWithCorrectValue(int v1, int v2, int v3, int v4, int v5, int expected) =>
      Assert.Equal(expected, ExerciseSUT(new List<int>() { v1, v2, v3, v4, v5 })[0].GetValue());

    [Theory]
    [InlineData(1, 1, 1, 1, 4, 1)]
    [InlineData(1, 1, 2, 2, 4, 2)]
    [InlineData(1, 2, 5, 6, 4, 0)]
    public void ShouldReturnMaxTwoOfTypePair(int v1, int v2, int v3, int v4, int v5, int expected)
    {
      var actual = ExerciseSUT(new List<int>() { v1, v2, v3, v4, v5 }).FindAll(IsOfType<Pair>).Count;
      Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, 1, 2, 2, 3, 6)]
    [InlineData(4, 4, 3, 2, 3, 14)]
    public void ShouldCombineValuesFromPairToTwoPair(int v1, int v2, int v3, int v4, int v5, int expected)
    {
      var actual = ExerciseSUT(new List<int>() { v1, v2, v3, v4, v5 }).Find(IsOfType<TwoPair>).GetValue();
      Assert.Equal(expected, actual);
    }

    private void AssertType<T>(List<int> diceValues) =>
      Assert.IsType<T>(ExerciseSUT(diceValues).Find(IsOfType<T>));

    private List<Category> ExerciseSUT(List<int> diceValues)
    {
      var fakePlayer = new Mock<ScoreBoard>();
      var fakeDice = new Mock<Dice>();
      fakeDice.Setup(d => d.GetValues()).Returns(diceValues);

      var sut = new AllAvailableCategoriesStrategy();
      return sut.GetCategories(fakeDice.Object, fakePlayer.Object);
    }

    private bool IsOfType<T>(Category c) => c.GetType() == typeof(T);
  }
}

