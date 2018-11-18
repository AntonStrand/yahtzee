using System;
using Xunit;
using Yahtzee.model.category;

namespace YahtzeeTests
{
  public class FullHouseTest
  {
    [Fact]
    public void ShouldAcceptCorrectArguments() =>
      new FullHouse(new Pair(1, 1), new ThreeOfAKind(2, 2, 2));

    [Fact]
    public void ShouldNotAcceptNull() =>
      Assert.Throws<ArgumentNullException>(() => new FullHouse(null, null));

    [Fact]
    public void ShouldNotAcceptThreeOfAKindIsNull() =>
      Assert.Throws<ArgumentNullException>(() => new FullHouse(new Pair(1, 1), null));
  }
}
