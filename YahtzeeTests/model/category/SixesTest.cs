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
    public void ShouldImplementCategoryInterface()
    {
      var fakeDice = new Mock<Dice>();
      fakeDice.Setup(d => d.GetValues()).Returns(new List<int> { 6, 6, 6, 6, 1 });

      var sut = new Sixes(fakeDice.Object);
      Assert.True(sut is Category);
    }


    [Fact]
    public void ShouldNotAcceptNullValues() =>
      Assert.Throws<ArgumentNullException>(() => new Sixes(null));
  }
}
