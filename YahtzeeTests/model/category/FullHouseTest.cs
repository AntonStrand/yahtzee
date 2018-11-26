using System;
using Xunit;
using Moq;
using YahtzeeApp.model.category;

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
    public void ShouldSumInputsAndReturn16() => AssertSum(16, 10, 6);

    [Fact]
    public void ShouldSumInputsAndReturn21() => AssertSum(21, 12, 9);

    private void AssertSum(int expected, int pairValue, int threeOfAKindValue)
    {
      var pair = new Mock<Pair>(1, 1);
      var threeOfAKind = new Mock<ThreeOfAKind>(1, 1, 1);

      pair.Setup(p => p.GetValue()).Returns(pairValue);
      threeOfAKind.Setup(t => t.GetValue()).Returns(threeOfAKindValue);

      var sut = new FullHouse(pair.Object, threeOfAKind.Object);
      Assert.Equal(expected, sut.GetValue());
    }

    private void AssertArgumentNullException(Pair pair, ThreeOfAKind threeOfAKind) =>
      Assert.Throws<ArgumentNullException>(() => new FullHouse(pair, threeOfAKind));
  }
}
