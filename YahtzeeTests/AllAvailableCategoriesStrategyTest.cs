using System;
using Xunit;
using Yahtzee.model;
using Yahtzee.model.category;
using Moq;
using System.Collections.Generic;

namespace YahtzeeTests
{
  public class AllAvailableCategoriesTest
  {
    [Fact]
    public void ShouldAcceptDiceAndScoreBoard()
    {
      var fakePlayer = new Mock<ScoreBoard>();
      var fakeDice = new Mock<Dice>();
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
      var fakeDice = new Mock<Dice>();
      var sut = new AllAvailableCategoriesStrategy();
      Assert.Throws<ArgumentNullException>(() => sut.GetCategories(fakeDice.Object, null));
    }

    [Fact]
    public void ShouldReturnPair()
    {
      var fakePlayer = new Mock<ScoreBoard>();
      var fakeDice = new Mock<Dice>();
      fakeDice.Setup(d => d.GetValues()).Returns(new List<int>() { 5, 5, 1, 2, 4 });

      var sut = new AllAvailableCategoriesStrategy();
      var actual = sut.GetCategories(fakeDice.Object, fakePlayer.Object)[0];
      Assert.IsType<Pair>(actual);
    }

    [Fact]
    public void ShouldReturnPairOf6()
    {
      var fakePlayer = new Mock<ScoreBoard>();
      var fakeDice = new Mock<Dice>();
      fakeDice.Setup(d => d.GetValues()).Returns(new List<int>() { 5, 6, 6, 2, 4 });

      var sut = new AllAvailableCategoriesStrategy();
      var actual = sut.GetCategories(fakeDice.Object, fakePlayer.Object)[0].GetValue();
      var expected = 12;
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ShouldReturnPairOf4()
    {
      var fakePlayer = new Mock<ScoreBoard>();
      var fakeDice = new Mock<Dice>();
      fakeDice.Setup(d => d.GetValues()).Returns(new List<int>() { 4, 1, 6, 2, 4 });

      var sut = new AllAvailableCategoriesStrategy();
      var actual = sut.GetCategories(fakeDice.Object, fakePlayer.Object)[0].GetValue();
      var expected = 8;
      Assert.Equal(expected, actual);
    }
  }
}

