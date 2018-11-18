using System;
using Xunit;
using Yahtzee.model.category;

namespace YahtzeeTests
{
  public class PairTest
  {
    [Fact]
    public void ShouldNotAcceptDifferentValues()
    {
      Assert.Throws<ArgumentException>(() => new Pair(1, 3));
    }

    [Fact]
    public void ShouldSetInput4ToValue8() => AssertValue(4, 8);

    [Fact]
    public void ShouldSetInput5ToValue10() => AssertValue(5, 10);

    private void AssertValue(int input, int expected)
    {
      Pair sut = new Pair(input, input);
      Assert.Equal(expected, sut.GetValue());
    }
  }
}
