using System;
using Xunit;
using Yahtzee.model.category;

namespace YahtzeeTests
{
  public class ChanceTest
  {
    [Theory]
    [InlineData(1, 1, 2, 2, 2, 8)]
    [InlineData(1, 6, 6, 3, 4, 20)]
    [InlineData(3, 6, 1, 3, 5, 18)]
    public void ShouldCalculateValueBasedOnInput(int v1, int v2, int v3, int v4, int v5, int expected)
    {
      var sut = new Chance(v1, v2, v3, v4, v5);
      var actual = sut.GetValue();
      Assert.Equal(expected, actual);
    }
  }
}
