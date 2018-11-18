using System;
using Xunit;
using Yahtzee.model.category;

namespace YahtzeeTests
{
  public class FullHouseTest
  {
    [Fact]
    public void ShouldAcceptCorrectArguments() => new FullHouse(new Pair(1, 1), new ThreeOfAKind(2, 2, 2));

    [Fact]
    public void ShouldNotAcceptNull() => AssertArgumentNullException(null, null);

    [Fact]
    public void ShouldNotAcceptPairIsNull() => AssertArgumentNullException(null, new ThreeOfAKind(2, 2, 2));

    [Fact]
    public void ShouldNotAcceptThreeOfAKindIsNull() => AssertArgumentNullException(new Pair(1, 1), null);

    private void AssertArgumentNullException(Pair pair, ThreeOfAKind threeOfAKind) =>
      Assert.Throws<ArgumentNullException>(() => new FullHouse(pair, threeOfAKind));
  }
}
