using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using YahtzeeApp.model;
using YahtzeeApp.model.category;

namespace YahtzeeTests
{
  public class AcesTest
  {
    [Fact]
    public void ShouldSumAllAces()
    {
      var fakeDice = new Mock<Dice>();
      fakeDice.Setup(d => d.GetValues()).Returns(new List<int> { 1, 1, 1, 1, 1 });

      var sut = new Aces(fakeDice.Object);
      var actual = sut.GetValue();

      Assert.Equal(5, actual);
    }

    [Fact]
    public void ShouldNotAcceptNullValues() =>
      Assert.Throws<ArgumentNullException>(() => new Aces(null));
  }
}
