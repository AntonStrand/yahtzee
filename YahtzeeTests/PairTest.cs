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
      Pair sut = new Pair(input, input);
      int expected = 8;
      int actual = sut.GetValue();
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ShouldSetInput5ToValue10()
    {
      int input = 5;
      Pair sut = new Pair(input, input);
      int expected = 10;
      int actual = sut.GetValue();
      Assert.Equal(expected, actual);
    }
  }
}
