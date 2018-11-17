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
      Pair sut = new Pair(4, 4);
      Assert.Equal(8, sut.GetValue());
    }
  }
}
