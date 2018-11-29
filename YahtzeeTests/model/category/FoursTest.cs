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
      var fakeDice = new Mock<Dice>();
      fakeDice.Setup(d => d.GetValues()).Returns(new List<int> { 3, 4, 3, 2, 5 });

      var sut = new Fours(fakeDice.Object);
      Assert.Equal(4, sut.GetValue());
    }

    [Fact]
    public void ShouldImplementCategoryInterface()
    {
      var fakeDice = new Mock<Dice>();
      fakeDice.Setup(d => d.GetValues()).Returns(new List<int> { 3, 4, 3, 2, 5 });

      var sut = new Fours(fakeDice.Object);
      Assert.True(sut is Category);
    }

    [Fact]
    public void ShouldNotAcceptNullValues() =>
      Assert.Throws<ArgumentNullException>(() => new Fours(null));
  }
}
