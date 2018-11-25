using System;
using Xunit;
using category = Yahtzee.model.category;

namespace YahtzeeTests
{
  public class YahtzeeTest
  {
    [Fact]
    public void ShouldNotAcceptInvalidInput()
    {
      Assert.Throws<ArgumentException>(() => new category.Yahtzee(1, 2, 3, 4, 6));
    }

    [Fact]
    public void ShouldSetValueIfInputIsCorrect()
    {
      var sut = new category.Yahtzee(1, 1, 1, 1, 1);
      Assert.Equal(50, sut.GetValue());
    }
  }
}
