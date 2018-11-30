using System;
using Xunit;
using YahtzeeApp.controller;
using YahtzeeApp.view;
using YahtzeeApp.model;
using Moq;
using System.IO;

namespace YahtzeeTests
{
  public class MainControllerTest
  {
    [Fact]
    public void NewMainController()
    {
      var v = new EnglishMainView();
      var p = new Player();
      var c = new MainController(v, p);

      Assert.IsType<MainController>(c);
    }

    [Fact]
    public void MethodPlayExist()
    {
      var v = new EnglishMainView();
      var p = new Player();
      var c = new MainController(v, p);

      Assert.Equal("Void Play()", c.GetType().GetMethod("Play").ToString());
    }

    [Fact]
    public void WhenRunningPlayViewInstructionsIsCalled()
    {
      var mockView = new Mock<MainView>();
      var p = new Player();
      var c = new MainController(mockView.Object, p);
      mockView.Setup(view => view.GetUsername()).Returns("test");

      c.Play();
      mockView.Verify(view => view.DisplayWelcomeMessage(), Times.Once());
    }

    [Fact]
    public void WhenRunningPlayViewGetUsernameIsCalled()
    {
      var mockView = new Mock<MainView>();
      var mockPlayer = new Mock<Player>();
      mockView.Setup(view => view.GetUsername()).Returns("test");
      var c = new MainController(mockView.Object, mockPlayer.Object);

      c.Play();
      mockView.Verify(view => view.GetUsername(), Times.Once());
    }

    [Fact]
    public void WhenRunningPlayViewUserNameIsSetInPlayer()
    {
      Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
      var view = new EnglishMainView();
      var player = new Player();
      var c = new MainController(view, player);

      string expected = "Test";
      var input = new StringReader(expected);
      Console.SetIn(input);

      c.Play();

      Assert.Equal(expected, player.GetName());
      input.Close();
    }
  }
}