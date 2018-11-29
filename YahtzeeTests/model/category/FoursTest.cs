using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using YahtzeeApp.model;
using YahtzeeApp.model.category;

namespace YahtzeeTests
{
  public class FoursTest
  {
    [Fact]
    public void ShouldReturnSumOfAllFours()
    {
      var sut = SetupSUT(3, 4, 3, 2, 5);
      Assert.Equal(4, sut.GetValue());
    }

    [Fact]
    public void ShouldReturnSumOfAllFours1()
    {
      var sut = SetupSUT(4, 4, 4, 4, 4);
      Assert.Equal(20, sut.GetValue());
    }

    [Fact]
    public void ShouldImplementCategoryInterface()
    {
      var sut = SetupSUT(3, 4, 3, 2, 5);
      Assert.True(sut is Category);
    }

    [Fact]
    public void ShouldNotAcceptNullValues() =>
      Assert.Throws<ArgumentNullException>(() => new Fours(null));

    private Fours SetupSUT(int v1, int v2, int v3, int v4, int v5)
    {
      var fakeDice = new Mock<Dice>();
      fakeDice.Setup(d => d.GetValues()).Returns(new List<int> { v1, v2, v3, v4, v5 });

      return new Fours(fakeDice.Object);
    }
  }
}
