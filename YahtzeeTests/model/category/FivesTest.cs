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
    [Fact]
    public void ShouldReturnSumOfAllFives()
    {
      var sut = SetupSUT(5, 5, 5, 2, 3);
      Assert.Equal(expected: 15, actual: sut.GetValue());
    }

    [Fact]
    public void ShouldReturnSumOfAllFives1()
    {
      var sut = SetupSUT(5, 5, 5, 5, 5);
      Assert.Equal(expected: 25, actual: sut.GetValue());
    }

    [Fact]
    public void ShouldReturnSumOfAllFives2()
    {
      var sut = SetupSUT(1, 2, 3, 4, 6);
      Assert.Equal(expected: 0, actual: sut.GetValue());
    }

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
