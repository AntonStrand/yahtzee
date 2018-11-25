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
    public void DisplayWelcomeMessageTest()
    {
      var v = new EnglishMainView();
      Assert.Equal("Void DisplayWelcomeMessage()", v.GetType().GetMethod("DisplayWelcomeMessage").ToString());
    }

    [Fact]
    public void DisplayInstructionsPrintToConsole()
    {
      using (StringWriter sw = new StringWriter())
      {
        Console.SetOut(sw);

        var v = new EnglishMainView();
        v.DisplayWelcomeMessage();

        string expected = v.welcomeMsg + "\n";
        Assert.Equal(expected, sw.ToString());
        sw.Close();
      }
    }

    [Fact]
    public void GetUserNameExist()
    {
      var v = new EnglishMainView();
      Assert.Equal("System.String GetUsername()", v.GetType().GetMethod("GetUsername").ToString());
    }

    // [Fact]
    // public void GetUserNamePrintText()
    // {
    //   using (StringWriter sw = new StringWriter())
    //   {
    //     Console.SetOut(sw);

    //     var v = new EnglishMainView();
    //     v.GetUsername();

    //     string expected = v.enterUsername + "\n";
    //     Assert.Equal(expected, sw.ToString());
    //     sw.Close();
    //   }
    //}
  }
}