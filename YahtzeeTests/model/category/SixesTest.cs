using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using YahtzeeApp.model;
using YahtzeeApp.model.category;

namespace YahtzeeTests
{
  public class SixesTest
  {
    [Theory]
    [InlineData(6, 6, 6, 6, 4, 24)]
    [InlineData(1, 1, 2, 1, 1, 0)]
    [InlineData(6, 6, 6, 6, 6, 30)]
    public void ShouldReturnSumOfAllSixes(int v1, int v2, int v3, int v4, int v5, int expected) =>
      Assert.Equal(expected, actual: SetupSUT(v1, v2, v3, v4, v5).GetValue());

    [Fact]
    public void ShouldImplementCategoryInterface()
    {
      var sut = SetupSUT(6, 6, 6, 6, 4);
      Assert.True(sut is Category);
    }

    [Fact]
    public void ShouldNotAcceptNullValues() =>
      Assert.Throws<ArgumentNullException>(() => new Sixes(null));

    private Sixes SetupSUT(int v1, int v2, int v3, int v4, int v5)
    {
      var fakeDice = new Mock<Dice>();
      fakeDice.Setup(d => d.GetValues()).Returns(new List<int> { v1, v2, v3, v4, v5 });

      return new Sixes(fakeDice.Object);
    }
  }
}
