using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using YahtzeeApp.model;
using YahtzeeApp.model.category;

namespace YahtzeeTests
{
  public class FirstSectionTest
  {
    [Fact]
    public void ShouldSumAllValuesOfSpecifiedType()
    {
      var fakeDice = new Mock<Dice>();
      fakeDice.Setup(d => d.GetValues()).Returns(new List<int> { 1, 2, 1, 1, 2 });

      var expected = 3;
      var sut = new FirstSection(1, fakeDice.Object);
      var actual = sut.GetValue();
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ShouldNotAcceptNullValues() =>
      Assert.Throws<ArgumentNullException>(() => new FirstSection(1, null));
  }
}
