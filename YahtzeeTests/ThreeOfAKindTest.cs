using System;
using Xunit;
using Yahtzee.model.category;

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
    public void ShouldAcceptAllValuesAreSame()
    {
      var input = 3;
      new ThreeOfAKind(input, input, input);
    }

    [Fact]
    public void ShouldSumAllInputsAsValue9()
    {
      var input = 3;
      var sut = new ThreeOfAKind(input, input, input);
      var expected = input + input + input;
      Assert.Equal(expected, sut.GetValue());
    }
  }
}
