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
      var view = new EnglishMainView();
      Assert.IsType<Yahtzee.view.EnglishMainView>(view);
    }

    [Fact]
    public void DisplayInstructionsExist()
    {
      var v = new EnglishMainView();
      Assert.Equal(v.GetType().GetMethod("DisplayInstructions").ToString(), "Void DisplayInstructions()");
    }
  }
}