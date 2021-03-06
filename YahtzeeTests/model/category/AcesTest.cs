using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using YahtzeeApp.model;
using YahtzeeApp.model.category;

namespace YahtzeeTests
{
  public class AcesTest
  {
    [Theory]
    [InlineData(1, 1, 1, 1, 1, 5)]
    [InlineData(1, 3, 3, 1, 3, 2)]
    [InlineData(4, 3, 3, 6, 3, 0)]
    public void ShouldSumAllAces(int v1, int v2, int v3, int v4, int v5, int expected)
    {
      var sut = SetupSUT(v1, v2, v3, v4, v5);
      Assert.Equal(expected, sut.GetValue());
    }

    [Fact]
    public void ShouldImplementCategoryInterface() =>
      Assert.True(SetupSUT(1, 2, 2, 3, 1) is Category);

    [Fact]
    public void ShouldNotAcceptNullValues() =>
      Assert.Throws<ArgumentNullException>(() => new Aces(null));

    private Aces SetupSUT(int v1, int v2, int v3, int v4, int v5)
    {
      var fakeDice = new Mock<Dice>();
      fakeDice.Setup(d => d.GetValues()).Returns(new List<int> { v1, v2, v3, v4, v5 });

      return new Aces(fakeDice.Object);
    }
  }
}
