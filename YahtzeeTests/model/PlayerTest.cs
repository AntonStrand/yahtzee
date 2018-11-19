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

    [Fact]
    public void MethodSetNameExist()
    {
      var player = new Player();

      Assert.Equal("Void SetName(System.String)", player.GetType().GetMethod("SetName").ToString());
    }
  }
}