using System;
using System.Collections.Generic;
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

    [Fact]
    public void ShouldThrowArgumentExceptionIfCategoryExists()
    {
      var value = 5;
      var sut = new Player();
      sut.AddCategory(new FourOfAKind(value, value, value, value));
      Assert.Throws<ArgumentException>(() => sut.AddCategory(new FourOfAKind(value, value, value, value)));
    }

    [Fact]
    public void ShouldAcceptDifferentCategories()
    {
      var value = 5;
      var sut = new Player();

      var foak = new FourOfAKind(value, value, value, value);
      var toak = new ThreeOfAKind(value, value, value);
      var pair = new Pair(value, value);
      var expected = new List<Category> { foak, toak, pair };

      sut.AddCategory(foak);
      sut.AddCategory(toak);
      sut.AddCategory(pair);
      var actual = sut.GetOccupiedCategories();
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ShouldReturnZeroIfNoCategories() =>
      Assert.Equal(0, new Player().GetResult());
  }
}