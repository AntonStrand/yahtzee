using System;
using Xunit;
using YahtzeeApp.model;
using YahtzeeApp.model.rules;
using YahtzeeApp.model.category;
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
    public void ShouldReturnSmallStraight() => AssertType<SmallStraight>(new List<int>() { 1, 2, 3, 4, 5 });

    [Fact]
    public void ShouldReturnLargeStraight() => AssertType<LargeStraight>(new List<int>() { 2, 3, 4, 5, 6 });

    [Fact]
    public void ShouldReturnFullHouse() => AssertType<FullHouse>(new List<int>() { 1, 1, 1, 4, 4 });

    [Fact]
    public void ShouldReturnYahtzee() => AssertType<Yahtzee>(new List<int>() { 1, 1, 1, 1, 1 });

    [Fact]
    public void ShouldOnlyReturnAPairAndChance()
    {
      var actual = ExerciseSUT(new List<int>() { 1, 1, 2, 4, 6 })
        .Where(c => IsOfType<Pair>(c) || IsOfType<Chance>(c))
        .ToList().Count;
      Assert.Equal(2, actual);
    }

    [Fact]
    public void ShouldReturnAcesWithCorrectValue() =>
      AssertValueFromType<Aces>(new List<int>() { 1, 1, 4, 1, 3 }, expected: 3);

    [Fact]
    public void ShouldReturnTwosWithCorrectValue() =>
      AssertValueFromType<Twos>(new List<int>() { 1, 2, 4, 2, 2 }, expected: 6);

    [Fact]
    public void ShouldReturnThreesWithCorrectValue() =>
      AssertValueFromType<Threes>(new List<int>() { 3, 3, 3, 2, 1 }, expected: 9);

    [Fact]
    public void ShouldReturnFoursWithCorrectValue() =>
      AssertValueFromType<Fours>(new List<int>() { 4, 3, 4, 2, 4 }, expected: 12);

    [Fact]
    public void ShouldReturnFivesWithCorrectValue() =>
      AssertValueFromType<Fives>(new List<int>() { 4, 5, 5, 2, 5 }, expected: 15);

    [Fact]
    public void ShouldReturnSixesWithCorrectValue() =>
      AssertValueFromType<Sixes>(new List<int>() { 6, 5, 6, 2, 6 }, expected: 18);

    [Theory]
    [InlineData(5, 6, 6, 2, 4, 12)]
    [InlineData(4, 1, 6, 2, 4, 8)]
    public void ShouldReturnPairWithCorrectValue(int v1, int v2, int v3, int v4, int v5, int expected) =>
      AssertValueFromType<Pair>(new List<int>() { v1, v2, v3, v4, v5 }, expected);

    [Theory]
    [InlineData(1, 1, 2, 2, 3, 6)]
    [InlineData(4, 4, 3, 2, 3, 14)]
    [InlineData(4, 4, 3, 4, 3, 14)]
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
    [InlineData(1, 3, 2, 4, 5, 15)]
    public void ShouldReturnSmallStraightWithCorrectValue(int v1, int v2, int v3, int v4, int v5, int expected) =>
      AssertValueFromType<SmallStraight>(new List<int>() { v1, v2, v3, v4, v5 }, expected);

    [Theory]
    [InlineData(6, 3, 2, 4, 5, 20)]
    [InlineData(5, 3, 2, 6, 4, 20)]
    public void ShouldReturnLargeStraightWithCorrectValue(int v1, int v2, int v3, int v4, int v5, int expected) =>
      AssertValueFromType<LargeStraight>(new List<int>() { v1, v2, v3, v4, v5 }, expected);

    [Theory]
    [InlineData(2, 50)]
    [InlineData(4, 50)]
    public void ShouldReturnYahtzeeWithCorrectValue(int v, int expected) =>
      AssertValueFromType<Yahtzee>(new List<int>() { v, v, v, v, v }, expected);

    [Theory]
    [InlineData(6, 3, 2, 4, 5, 20)]
    [InlineData(4, 3, 1, 1, 5, 14)]
    public void ShouldReturnChanceWithCorrectValue(int v1, int v2, int v3, int v4, int v5, int expected) =>
      AssertValueFromType<Chance>(new List<int>() { v1, v2, v3, v4, v5 }, expected);

    [Theory]
    [InlineData(6, 3, 6, 6, 3, 24)]
    [InlineData(2, 2, 4, 4, 2, 14)]
    public void ShouldReturnFullHouseWithCorrectValue(int v1, int v2, int v3, int v4, int v5, int expected) =>
      AssertValueFromType<FullHouse>(new List<int>() { v1, v2, v3, v4, v5 }, expected);

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
      var player = new Player();
      var fakeDice = new Mock<Dice>();
      fakeDice.Setup(d => d.GetValues()).Returns(diceValues);

      var sut = new AllAvailableCategoriesStrategy();
      return sut.GetCategories(fakeDice.Object, player);
    }

    private bool IsOfType<T>(Category c) => c.GetType() == typeof(T);
  }
}

