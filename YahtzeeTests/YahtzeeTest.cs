using System;
using Xunit;
using category = Yahtzee.model.category;

namespace YahtzeeTests
{
  public class YahtzeeTest
  {
    [Theory]
    [InlineData(1, 2, 3, 4, 6)]
    public void ShouldNotAcceptInvalidInput(int v1, int v2, int v3, int v4, int v5)
    {
      Assert.Throws<ArgumentException>(() => new category.Yahtzee(v1, v2, v3, v4, v5));
    }

    [Fact]
    public void ShouldSetValueIfInputIsCorrect()
    {
      var sut = new category.Yahtzee(1, 1, 1, 1, 1);
      Assert.Equal(50, sut.GetValue());
    }
  }
}
