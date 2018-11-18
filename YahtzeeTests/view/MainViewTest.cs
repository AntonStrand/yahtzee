using System;
using Xunit;
using Yahtzee.view;

namespace YahtzeeTests
{
  public class MainViewTest
  {
    [Fact]
    public void NewMainView()
    {
      var view = new MainView();
      Assert.IsType<Yahtzee.view.MainView>(view);
    }

    [Fact]
    public void DisplayInstructionsExist()
    {
      var v = new MainView();
      Assert.Equal(v.GetType().GetMethod("DisplayInstructions").ToString(), "Void DisplayInstructions()");
    }
  }
}