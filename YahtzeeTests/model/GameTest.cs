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
    public void ShouldReturnTheProvidedDice()
    {
      var fakeDice = new Mock<Dice>();
      var sut = new Game(new AllAvailableCategoriesStrategy(), fakeDice.Object);
      var actual = sut.GetDice();
      Assert.Equal(fakeDice.Object, actual);
    }

    [Fact]
    public void ShouldAcceptAllAvailableCategoriesStrategy() =>
      new Game(new AllAvailableCategoriesStrategy(), null);

    [Fact]
    public void ShouldReturnNumberOfThrowsLeft()
    {
      var sut = new Game(new AllAvailableCategoriesStrategy(), null);
      var expected = 3;
      var actual = sut.GetNumberOfThrowsLeft();
      Assert.Equal(expected, actual);
    }
  }
}