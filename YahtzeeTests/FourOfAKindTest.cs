using System;
using Xunit;
using Yahtzee.model.category;

namespace YahtzeeTests
{
  public class FourOfAKindTest
  {
    [Fact]
    public void ShouldAcceptIfAllMatch()
    {
      var input = 1;
      new FourOfAKind(input, input, input, input);
    }

    [Fact]
    public void ShouldNotAcceptTheFirstTwoArgumentsBeingDifferent() => AssertArgumentException(1, 3, 3, 3);

    [Fact]
    public void ShouldNotAcceptTheSecondTwoArgumentsBeingDifferent() => AssertArgumentException(3, 3, 3, 1);

    [Fact]
    public void ShouldNotAcceptTwoMiddleArgumentsBeingDifferent() => AssertArgumentException(3, 3, 1, 1);

    [Fact]
    public void ShouldSumAllInputsAndSetValueTo20()
    {
      var expected = 20;
      var input = expected / 4;
      var sut = new FourOfAKind(input, input, input, input);
      Assert.Equal(expected, sut.GetValue());
    }

    private void AssertArgumentException(int v1, int v2, int v3, int v4) =>
      Assert.Throws<ArgumentException>(() => new FourOfAKind(v1, v2, v3, v4));
  }
}
