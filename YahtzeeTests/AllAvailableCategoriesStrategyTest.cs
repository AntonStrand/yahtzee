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

    [Theory]
    [InlineData(1, 1, 2, 2, 4)]
    [InlineData(1, 1, 1, 1, 4)]
    public void ShouldReturnTwoPair(int v1, int v2, int v3, int v4, int v5) =>
      AssertType<TwoPair>(new List<int>() { v1, v2, v3, v4, v5 });

    [Fact]
    public void ShouldReturnThreeOfAKind() => AssertType<ThreeOfAKind>(new List<int>() { 1, 1, 1, 2, 4 });

    [Fact]
    public void ShouldReturnFourOfAKind() => AssertType<FourOfAKind>(new List<int>() { 1, 1, 1, 1, 4 });

    [Fact]
    public void ShouldOnlyReturnAPair()
    {
      var actual = ExerciseSUT(new List<int>() { 1, 1, 2, 4, 6 }).Where(c => !IsOfType<Pair>(c)).ToList().Count;
      Assert.Equal(0, actual);
    }

    [Theory]
    [InlineData(5, 6, 6, 2, 4, 12)]
    [InlineData(4, 1, 6, 2, 4, 8)]
    public void ShouldReturnPairWithCorrectValue(int v1, int v2, int v3, int v4, int v5, int expected) =>
      AssertValueFromType<Pair>(new List<int>() { v1, v2, v3, v4, v5 }, expected);

    [Theory]
    [InlineData(1, 1, 2, 2, 3, 6)]
    [InlineData(4, 4, 3, 2, 3, 14)]
    public void ShouldCombineValuesFromPairToTwoPair(int v1, int v2, int v3, int v4, int v5, int expected) =>
      AssertValueFromType<TwoPair>(new List<int>() { v1, v2, v3, v4, v5 }, expected);

    [Theory]
    [InlineData(6, 6, 6, 2, 4, 18)]
    [InlineData(6, 2, 2, 2, 4, 6)]
    public void ShouldReturnThreeOfAKindWithCorrectValue(int v1, int v2, int v3, int v4, int v5, int expected) =>
      AssertValueFromType<ThreeOfAKind>(new List<int>() { v1, v2, v3, v4, v5 }, expected);

    [Theory]
    [InlineData(6, 6, 6, 6, 4, 24)]
    [InlineData(2, 2, 6, 2, 2, 8)]
    public void ShouldReturnFourOfAKindWithCorrectValue(int v1, int v2, int v3, int v4, int v5, int expected) =>
      AssertValueFromType<FourOfAKind>(new List<int>() { v1, v2, v3, v4, v5 }, expected);

    [Theory]
    [InlineData(1, 1, 1, 1, 4, 1)]
    [InlineData(1, 1, 2, 2, 4, 2)]
    [InlineData(1, 2, 5, 6, 4, 0)]
    public void ShouldReturnMaxTwoOfTypePair(int v1, int v2, int v3, int v4, int v5, int expected)
    {
      var actual = ExerciseSUT(new List<int>() { v1, v2, v3, v4, v5 }).FindAll(IsOfType<Pair>).Count;
      Assert.Equal(expected, actual);
    }

    private void AssertValueFromType<T>(List<int> diceValues, int expected) =>
      Assert.Equal(expected, ExerciseSUT(diceValues).Find(IsOfType<T>).GetValue());

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

