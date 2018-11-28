using System;
using Xunit;
using YahtzeeApp.model;
using YahtzeeApp.model.rules;

namespace YahtzeeTests
{
  public class GameTest
  {
    [Fact]
    public void ShouldNotAcceptNullStrategy() =>
      Assert.Throws<ArgumentNullException>(() => new Game(null));

    [Fact]
    public void ShouldAcceptAllAvailableCategoriesStrategy() =>
      new Game(new AllAvailableCategoriesStrategy());

    [Fact]
    public void ShouldReturnNumberOfThrowsLeft()
    {

      var sut = new Game(new AllAvailableCategoriesStrategy());
      var expected = 3;
      var actual = sut.GetNumberOfThrowsLeft();
      Assert.Equal(expected, actual);
    }
  }
}