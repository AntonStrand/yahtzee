using System;
using Xunit;
using YahtzeeApp.model.category;

namespace YahtzeeTests
{
  public class ThreeOfAKindTest
  {
    [Fact]
    public void ShouldNotAcceptTheFirstTwoArgumentsBeingDifferent()
    {
      Assert.Throws<ArgumentException>(() => new ThreeOfAKind(1, 3, 3));
    }

    [Fact]
    public void ShouldNotAcceptTheSecondTwoArgumentsBeingDifferent()
    {
      Assert.Throws<ArgumentException>(() => new ThreeOfAKind(3, 3, 1));
    }

    [Fact]
    public void ShouldAcceptAllValuesAreSame() => SetupSUT(3);

    [Fact]
    public void ShouldSumAllInputsAsValue9() => AssertSumMatch(3);

    [Fact]
    public void ShouldSumAllInputsAsValue6() => AssertSumMatch(2);

    private void AssertSumMatch(int input)
    {
      var sut = SetupSUT(input);
      var expected = input * 3;
      Assert.Equal(expected, sut.GetValue());
    }
    private ThreeOfAKind SetupSUT(int input) => new ThreeOfAKind(input, input, input);

  }
}
