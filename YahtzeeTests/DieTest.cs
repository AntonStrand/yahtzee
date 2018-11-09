using Xunit;
using Yahtzee;
using Yahtzee.model;

namespace MyFirstUnitTests
{
  public class DieTest
  {

    [Fact]
    public void GetValueShouldReturnIntBetween1to6()
    {
      Die sut = new Die();
      Assert.InRange(sut.GetValue(), 1, 6);
    }
  }
}
