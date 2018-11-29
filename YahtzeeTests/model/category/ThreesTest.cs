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
    [Fact]
    public void ShouldReturnTheSumOfAllThrees()
    {
      var fakeDice = new Mock<Dice>();
      fakeDice.Setup(d => d.GetValues()).Returns(new List<int> { 1, 2, 3, 4, 5 });
      var sut = new Threes(fakeDice.Object);
      Assert.Equal(3, sut.GetValue());
    }

    [Fact]
    public void ShouldImplementCategoryInterface()
    {
      var fakeDice = new Mock<Dice>();
      var sut = new Threes(fakeDice.Object);
      Assert.True(sut is Category);
    }

    [Fact]
    public void ShouldNotAcceptNullValues() =>
      Assert.Throws<ArgumentNullException>(() => new Threes(null));
  }
}
