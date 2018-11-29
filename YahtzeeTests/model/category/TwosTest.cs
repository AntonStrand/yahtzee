using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using YahtzeeApp.model;
using YahtzeeApp.model.category;

namespace YahtzeeTests
{
  public class TwosTest
  {
    [Theory]
    [InlineData(2, 2, 2, 2, 2, 10)]
    [InlineData(3, 4, 1, 1, 2, 2)]
    [InlineData(3, 4, 1, 1, 6, 0)]
    public void ShouldSumValuesOfAllTwos(int v1, int v2, int v3, int v4, int v5, int expected) =>
      Assert.Equal(expected, SetupSUT(v1, v2, v3, v4, v5).GetValue());

    [Fact]
    public void ShouldImplementCategoryInterface()
    {
      var sut = SetupSUT(2, 2, 2, 2, 2);
      Assert.True(sut is Category);
    }

    [Fact]
    public void ShouldNotAcceptNullValues() =>
      Assert.Throws<ArgumentNullException>(() => new Twos(null));

    private Twos SetupSUT(int v1, int v2, int v3, int v4, int v5)
    {
      var fakeDice = new Mock<Dice>();
      fakeDice.Setup(d => d.GetValues()).Returns(new List<int> { v1, v2, v3, v4, v5 });
      return new Twos(fakeDice.Object);
    }
  }
}
