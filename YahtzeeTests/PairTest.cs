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
    public void ShouldSetInput4ToValue8()
    {
      int input = 4;
      int expected = 8;
      Pair sut = new Pair(input, input);
      Assert.Equal(expected, sut.GetValue());
    }

    [Fact]
    public void ShouldSetInput5ToValue10()
    {
      int input = 5;
      int expected = 10;
      Pair sut = new Pair(input, input);
      Assert.Equal(expected, sut.GetValue());
    }
  }
}
