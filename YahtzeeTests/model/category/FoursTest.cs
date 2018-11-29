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
      var sut = SetupSUT();
      Assert.Equal(4, sut.GetValue());
    }

    [Fact]
    public void ShouldImplementCategoryInterface()
    {
      var sut = SetupSUT();
      Assert.True(sut is Category);
    }

    [Fact]
    public void ShouldNotAcceptNullValues() =>
      Assert.Throws<ArgumentNullException>(() => new Fours(null));

    private Fours SetupSUT()
    {
      var fakeDice = new Mock<Dice>();
      fakeDice.Setup(d => d.GetValues()).Returns(new List<int> { 3, 4, 3, 2, 5 });

      return new Fours(fakeDice.Object);
    }
  }
}
