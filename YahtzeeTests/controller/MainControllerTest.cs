using System;
using Xunit;
using Yahtzee.controller;
using Yahtzee.view;

namespace YahtzeeTests
{
  public class MainControllerTest
  {
    [Fact]
    public void NewMainControllerWithView()
    {
      var v = new MainView();
      var c = new MainController(v);
      Assert.IsType<Yahtzee.controller.MainController>(c);
    }

    [Fact]
    public void CallFunctionStart()
    {
      var v = new MainView();
      var c = new MainController(v);
      Assert.Equal(c.GetType().GetMethod("Play").ToString(), "Void Play()");
    }

  }
}