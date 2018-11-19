using Xunit;
using Yahtzee.model;

namespace YahtzeeTests
{
  public class PlayerTest
  {
    [Fact]
    public void NewPlayer()
    {
      var player = new Player();
    }
  }
}