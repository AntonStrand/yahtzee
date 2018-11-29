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
    [Fact]
    public void ShouldSumValuesOfAllTwos()
    {
      var fakeDice = new Mock<Dice>();
      fakeDice.Setup(d => d.GetValues()).Returns(new List<int> { 2, 2, 2, 2, 2 });

      var sut = new Twos(fakeDice.Object);
      Assert.Equal(10, sut.GetValue());
    }

    [Fact]
    public void ShouldImplementCategoryInterface()
    {
      var fakeDice = new Mock<Dice>();
      fakeDice.Setup(d => d.GetValues()).Returns(new List<int> { 2, 2, 2, 2, 2 });

      var sut = new Twos(fakeDice.Object);
      Assert.True(sut is Category);
    }

    [Fact]
    public void ShouldNotAcceptNullValues() =>
      Assert.Throws<ArgumentNullException>(() => new Twos(null));
  }
}
