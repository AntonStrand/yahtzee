using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using YahtzeeApp.model;
using YahtzeeApp.model.category;

namespace YahtzeeTests
{
  public class ThreesTest
  {
    [Theory]
    [InlineData(1, 2, 3, 4, 5, 3)]
    [InlineData(3, 2, 3, 4, 5, 6)]
    [InlineData(1, 2, 2, 4, 5, 0)]
    public void ShouldReturnTheSumOfAllThrees(int v1, int v2, int v3, int v4, int v5, int expected) =>
      Assert.Equal(expected, actual: SetupSUT(v1, v2, v3, v4, v5).GetValue());

    [Fact]
    public void ShouldImplementCategoryInterface()
    {
      var sut = SetupSUT(3, 2, 3, 4, 5);
      Assert.True(sut is Category);
    }

    [Fact]
    public void ShouldNotAcceptNullValues() =>
      Assert.Throws<ArgumentNullException>(() => new Threes(null));

    private Threes SetupSUT(int v1, int v2, int v3, int v4, int v5)
    {
      var fakeDice = new Mock<Dice>();
      fakeDice.Setup(d => d.GetValues()).Returns(new List<int> { v1, v2, v3, v4, v5 });
      return new Threes(fakeDice.Object);
    }
  }
}
