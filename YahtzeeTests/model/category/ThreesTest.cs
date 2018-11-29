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
    public void ShouldImplementCategoryInterface()
    {
      var fakeDice = new Mock<Dice>();
      var sut = new Threes(fakeDice.Object);
      Assert.True(sut is Category);
    }
  }
}
