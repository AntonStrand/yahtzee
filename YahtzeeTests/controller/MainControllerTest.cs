using System;
using Xunit;
using Yahtzee.controller;
using Yahtzee.view;
using Moq;

namespace YahtzeeTests
{
  public class MainControllerTest
  {
    [Fact]
    public void NewMainController()
    {
      var v = new EnglishMainView();
      var c = new MainController(v);
      Assert.IsType<Yahtzee.controller.MainController>(c);
    }

    [Fact]
    public void MethodPlayExist()
    {
      var v = new EnglishMainView();
      var c = new MainController(v);
      Assert.Equal("Void Play()", c.GetType().GetMethod("Play").ToString());
    }

    [Fact]
    public void WhenCallingPlayViewInstructionsIsCalled()
    {
      var mockView = new Mock<MainView>();
      var c = new MainController(mockView.Object);
      c.Play();
      mockView.Verify(view => view.DisplayWelcomeMessage(), Times.Once());
    }
  }
}