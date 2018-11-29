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
    [Fact]
    public void ShouldReturnSumOfAllSixes()
    {
      var sut = SetupSUT();
      Assert.Equal(24, sut.GetValue());
    }

    [Fact]
    public void ShouldReturnSumOfAllSixes1()
    {
      var fakeDice = new Mock<Dice>();
      fakeDice.Setup(d => d.GetValues()).Returns(new List<int> { 1, 1, 2, 1, 1 });
      var sut = new Sixes(fakeDice.Object);
      Assert.Equal(0, sut.GetValue());
    }

    [Fact]
    public void ShouldImplementCategoryInterface()
    {
      var sut = SetupSUT();
      Assert.True(sut is Category);
    }

    [Fact]
    public void ShouldNotAcceptNullValues() =>
      Assert.Throws<ArgumentNullException>(() => new Sixes(null));

    private Sixes SetupSUT()
    {
      var fakeDice = new Mock<Dice>();
      fakeDice.Setup(d => d.GetValues()).Returns(new List<int> { 6, 6, 6, 6, 1 });

      return new Sixes(fakeDice.Object);
    }
  }
}
