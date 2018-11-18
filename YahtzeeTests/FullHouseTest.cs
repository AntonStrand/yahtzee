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

    [Fact]
    public void ShouldSumInputsAndReturn16() => AssertSum(16, 5, 2);

    [Fact]
    public void ShouldSumInputsAndReturn21() => AssertSum(21, 6, 3);

    private void AssertSum(int expected, int pairInput, int threeOfAKindInput) {
      var pair = new Pair(pairInput, pairInput);
      var threeOfAKind = new ThreeOfAKind(threeOfAKindInput, threeOfAKindInput, threeOfAKindInput);
      var sut = new FullHouse(pair, threeOfAKind);
      Assert.Equal(expected, sut.GetValue());
    }

    private void AssertArgumentNullException(Pair pair, ThreeOfAKind threeOfAKind) =>
      Assert.Throws<ArgumentNullException>(() => new FullHouse(pair, threeOfAKind));
  }
}
