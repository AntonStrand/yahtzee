using System;
using Xunit;
using category = Yahtzee.model.category;

namespace YahtzeeTests
{
  public class YahtzeeTest
  {
    [Theory]
    [InlineData(1, 2, 3, 4, 6)]
    [InlineData(1, 1, 3, 5, 5)]
    [InlineData(1, 1, 1, 5, 5)]
    [InlineData(1, 1, 1, 1, 5)]
    public void ShouldNotAcceptInvalidInput(int v1, int v2, int v3, int v4, int v5) =>
      Assert.Throws<ArgumentException>(() => new category.Yahtzee(v1, v2, v3, v4, v5));

    [Theory]
    [InlineData(1, 1, 1, 1, 1)]
    [InlineData(6, 6, 6, 6, 6)]
    public void ShouldSetValueIfInputIsCorrect(int v1, int v2, int v3, int v4, int v5)
    {
      var sut = new category.Yahtzee(v1, v2, v3, v4, v5);
      Assert.Equal(50, sut.GetValue());
    }
  }
}
