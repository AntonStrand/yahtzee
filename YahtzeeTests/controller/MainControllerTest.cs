using System;
using Xunit;
using YahtzeeApp.controller;
using YahtzeeApp.view;
using YahtzeeApp.model;
using Moq;

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

      c.Play();
      mockView.Verify(view => view.DisplayWelcomeMessage(), Times.Once());
    }
  }
}