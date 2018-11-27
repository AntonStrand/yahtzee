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
    [Theory]
    [InlineData(1, 2, 1, 2, 1, 3)]
    [InlineData(1, 1, 1, 2, 1, 4)]
    public void ShouldSumAllValuesOfSpecifiedType(int v1, int v2, int v3, int v4, int v5, int expected)
    {
      var fakeDice = new Mock<Dice>();
      fakeDice.Setup(d => d.GetValues()).Returns(new List<int> { v1, v2, v3, v4, v5 });

      var sut = new FirstSection(1, fakeDice.Object);
      var actual = sut.GetValue();

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ShouldNotAcceptNullValues() =>
      Assert.Throws<ArgumentNullException>(() => new FirstSection(1, null));
  }
}
