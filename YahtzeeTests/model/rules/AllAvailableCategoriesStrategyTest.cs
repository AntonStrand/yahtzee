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
    public void ShouldReturnOnlyFirstSectionPairAndChance() =>
      Assert.Equal(expected: 8, actual: ExerciseSUT(new List<int>() { 1, 1, 2, 5, 6 }).Count);

    [Fact]
    public void ShouldNotReturnPairIfAlreadyTaken()
    {
      var diceValues = new List<int>() { 5, 5, 1, 3, 4 };
      var occupied = new List<Category> { new Pair(1, 1) };

      var categories = ExersciseSUTWithScoreBoard(diceValues, occupied);
      Assert.IsNotType<Pair>(categories.Find(IsOfType<Pair>));
    }

    [Fact]
    public void ShouldNotReturnPairIfAlreadyTakenButShouldReturnTwoPair()
    {
      var categories = ExersciseSUTWithScoreBoard(
        diceValues: new List<int>() { 5, 5, 1, 1, 4 },
        occupied: new List<Category> { new Pair(1, 1) }
      );
      Assert.IsNotType<Pair>(categories.Find(IsOfType<Pair>));
      Assert.IsType<TwoPair>(categories.Find(IsOfType<TwoPair>));
    }

    [Fact]
    public void ShouldRemoveAllOccupiedCategories()
    {
      var diceValues = new List<int>() { 5, 1, 1, 2, 2 };
      var occupied = new List<Category> {
        new Pair(1, 1),
        new TwoPair(new Pair(5, 5), new Pair(6, 6))
      };

      var categories = ExersciseSUTWithScoreBoard(diceValues, occupied);
      Assert.IsNotType<Pair>(categories.Find(IsOfType<Pair>));
      Assert.IsNotType<TwoPair>(categories.Find(IsOfType<TwoPair>));
    }

    [Fact]
    public void ShouldRemoveOccupiedCategories()
    {
      var categories = ExersciseSUTWithScoreBoard(
        diceValues: new List<int>() { 3, 3, 3, 6, 6 },
        occupied: new List<Category> { new TwoPair(new Pair(5, 5), new Pair(6, 6)) }
      );

      Assert.IsNotType<TwoPair>(categories.Find(IsOfType<TwoPair>));
      Assert.IsType<Pair>(categories.Find(IsOfType<Pair>));
      Assert.IsType<ThreeOfAKind>(categories.Find(IsOfType<ThreeOfAKind>));
    }

    [Fact]
    public void ShouldReturnTwosWithCorrectValue() =>
      AssertValueFromType<Twos>(new List<int>() { 1, 2, 4, 2, 2 }, 6);

    [Fact]
    public void ShouldReturnThreesWithCorrectValue() =>
      AssertValueFromType<Threes>(new List<int>() { 3, 3, 3, 2, 1 }, 9);

    [Fact]
    public void ShouldReturnFoursWithCorrectValue() =>
      AssertValueFromType<Fours>(new List<int>() { 4, 3, 4, 2, 4 }, 12);

    [Fact]
    public void ShouldReturnFivesWithCorrectValue() =>
      AssertValueFromType<Fives>(new List<int>() { 4, 5, 5, 2, 5 }, 15);

    [Fact]
    public void ShouldReturnSixesWithCorrectValue() =>
      AssertValueFromType<Sixes>(new List<int>() { 6, 5, 6, 2, 6 }, 18);

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

    private List<Category> ExerciseSUT(List<int> diceValues)
    {
      var player = new Player();
      var fakeDice = new Mock<Dice>();
      fakeDice.Setup(d => d.GetValues()).Returns(diceValues);

      var sut = new AllAvailableCategoriesStrategy();
      return sut.GetCategories(fakeDice.Object, player);
    }

    private List<Category> ExersciseSUTWithScoreBoard(List<int> diceValues, List<Category> occupied)
    {
      var fakePlayer = new Mock<ScoreBoard>();
      fakePlayer.Setup(p => p.GetOccupiedCategories()).Returns(occupied);

      var fakeDice = new Mock<Dice>();
      fakeDice.Setup(d => d.GetValues()).Returns(diceValues);

      var sut = new AllAvailableCategoriesStrategy();
      return sut.GetCategories(fakeDice.Object, fakePlayer.Object);
    }

    private bool IsOfType<T>(Category c) => c.GetType() == typeof(T);
  }
}

