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
      var fakeDice = new Mock<Dice>();
      fakeDice.Setup(d => d.GetValues()).Returns(new List<int> { 5, 5, 5, 2, 3 });
      var sut = new Fives(fakeDice.Object);
      Assert.Equal(expected: 15, actual: sut.GetValue());
    }

    [Fact]
    public void ShouldReturnSumOfAllFives1()
    {
      var fakeDice = new Mock<Dice>();
      fakeDice.Setup(d => d.GetValues()).Returns(new List<int> { 5, 5, 5, 5, 5 });
      var sut = new Fives(fakeDice.Object);
      Assert.Equal(expected: 25, actual: sut.GetValue());
    }

    [Fact]
    public void ShouldImplementCategoryInterface()
    {
      var fakeDice = new Mock<Dice>();
      fakeDice.Setup(d => d.GetValues()).Returns(new List<int> { 5, 5, 5, 2, 3 });
      var sut = new Fives(fakeDice.Object);
      Assert.True(sut is Category);
    }

    [Fact]
    public void ShouldNotAcceptNullValues() =>
      Assert.Throws<ArgumentNullException>(() => new Fives(null));
  }
}
