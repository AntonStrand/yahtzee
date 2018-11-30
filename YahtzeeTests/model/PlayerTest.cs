using System;
using Xunit;
using YahtzeeApp.model;
using YahtzeeApp.model.category;

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

    [Fact]
    public void ShouldReturnEmptyCategoryListIfNoCategoryIsOccupied()
    {
      var sut = new Player();
      Assert.Empty(sut.GetOccupiedCategories());
    }

    [Fact]
    public void ShouldStoreGivenCategory()
    {
      var sut = new Player();
      sut.AddCategory(new Pair(1, 1));
      Assert.IsType<Pair>(sut.GetOccupiedCategories()[0]);
    }

    [Theory]
    [InlineData(5, 10)]
    [InlineData(2, 4)]
    public void ShouldStoreCorrectValueOfCategory(int value, int expected)
    {
      var sut = new Player();
      sut.AddCategory(new Pair(value, value));
      Assert.Equal(expected, actual: sut.GetOccupiedCategories()[0].GetValue());
    }
  }
}