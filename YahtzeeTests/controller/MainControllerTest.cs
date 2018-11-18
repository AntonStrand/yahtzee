using System;
using Xunit;
using Yahtzee.controller;

namespace YahtzeeTests
{
  public class MainControllerTest
  {
    [Fact]
    public void NewMainController()
    {
      var controller = new MainController();
      Assert.IsType(typeof(Yahtzee.controller.MainController), controller);
    }
  }
}