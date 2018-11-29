using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using YahtzeeApp.model;
using YahtzeeApp.model.category;

namespace YahtzeeTests
{
  public class FivesTest
  {
    [Theory]
    [InlineData(5, 5, 5, 2, 3, 15)]
    [InlineData(5, 5, 5, 5, 5, 25)]
    [InlineData(1, 2, 3, 4, 6, 0)]
    [InlineData(1, 2, 5, 5, 6, 10)]
    public void ShouldReturnSumOfAllFives(int v1, int v2, int v3, int v4, int v5, int expected) =>
      Assert.Equal(expected, actual: SetupSUT(v1, v2, v3, v4, v5).GetValue());

    [Fact]
    public void ShouldImplementCategoryInterface()
    {
      var sut = SetupSUT(5, 5, 5, 2, 3);
      Assert.True(sut is Category);
    }

    [Fact]
    public void ShouldNotAcceptNullValues() =>
      Assert.Throws<ArgumentNullException>(() => new Fives(null));

    private Fives SetupSUT(int v1, int v2, int v3, int v4, int v5)
    {
      var fakeDice = new Mock<Dice>();
      fakeDice.Setup(d => d.GetValues()).Returns(new List<int> { v1, v2, v3, v4, v5 });
      return new Fives(fakeDice.Object);
    }
  }
}
