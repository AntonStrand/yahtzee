using System;
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

    [Fact]
    public void SetEmptyNameShouldThrowException()
    {
      Assert.Throws<ArgumentException>(() =>
      {
        var player = new Player();
        player.SetName("");
      });
    }

    [Fact]
    public void ShouldGetUsername()
    {
      string name = "test";
      var player = new Player();
      player.SetName(name);
      Assert.Equal(name, player.name);
    }
  }
}