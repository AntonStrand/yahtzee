using System;
using System.IO;
using Xunit;
using Yahtzee.view;

namespace YahtzeeTests
{
  public class EnglishMainViewTest
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
      Assert.Equal("Void DisplayInstructions()", v.GetType().GetMethod("DisplayInstructions").ToString());
    }

    [Fact]
    public void DisplayInstructionsPrints()
    {
      using (StringWriter sw = new StringWriter())
      {
        Console.SetOut(sw);

        var v = new EnglishMainView();
        v.DisplayInstructions();

        string expected = string.Format("Welcome to Yahtzee\n");
        Assert.Equal(expected, sw.ToString());
      }
    }
  }
}