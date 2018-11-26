using System;
using Xunit;
using YahtzeeApp.model.category;

namespace YahtzeeTests
{
  public class LargeStraightTest
  {
    [Fact]
    public void ShouldNotAcceptMoreThanOneOfEach() => Assert.Throws<ArgumentException>(() => new LargeStraight(1, 1, 1, 1, 1));

    [Theory]
    [InlineData(2, 3, 4, 5, 6)]
    [InlineData(4, 3, 2, 6, 5)]
    public void ShouldAcceptValidInput(int v1, int v2, int v3, int v4, int v5)
    {
      var sut = new LargeStraight(v1, v2, v3, v4, v5);
      var actual = sut.GetValue();
      Assert.Equal(20, actual);
    }
  }
}
