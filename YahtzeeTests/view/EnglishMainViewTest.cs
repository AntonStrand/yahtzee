using System;
using System.Collections.Generic;
using System.IO;
using Moq;
using Xunit;
using YahtzeeApp.model;
using YahtzeeApp.view;

namespace YahtzeeTests
{
  public class EnglishMainViewTest
  {
    [Fact]
    public void NewMainView()
    {
      var view = getEnglishMainMenu();
      Assert.IsType<EnglishMainView>(view);
    }

    [Fact]
    public void DisplayInstructionsPrintToConsole()
    {
      using (StringWriter sw = new StringWriter())
      {
        Console.SetOut(sw);

        var v = getEnglishMainMenu();
        v.DisplayWelcomeMessage();

        string expected = v.welcomeMsg + "\n";
        Assert.Equal(expected, sw.ToString());
        sw.Close();
      }
    }

    [Fact]
    public void GetUserNameExist()
    {
      var v = getEnglishMainMenu();
      Assert.Equal("System.String GetUsername()", v.GetType().GetMethod("GetUsername").ToString());
    }

    [Fact]
    public void GetUserNamePrintText()
    {
      using (StringWriter sw = new StringWriter())
      {
        Console.SetOut(sw);
        var input = new StringReader("Test");
        Console.SetIn(input);

        var v = getEnglishMainMenu();
        v.GetUsername();

        string expected = v.enterUsername + "\n";
        Assert.Equal(expected, sw.ToString());
        sw.Close();
        input.Close();
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
      }
    }

    [Fact]
    public void GetUserNameReturnsText()
    {
      string expected = "test";
      var input = new StringReader(expected);
      Console.SetIn(input);

      var v = getEnglishMainMenu();
      string result = v.GetUsername();

      Assert.Equal(expected, result);
      input.Close();
    }

    [Fact]
    public void SelectDiceWithInputThreeReturnsThree()
    {
      Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
      int expected = 3;
      var input = new StringReader(expected.ToString());
      Console.SetIn(input);

      var v = getEnglishMainMenu();
      int result = v.SelectDice();

      Assert.Equal(expected, result);
      input.Close();
    }

    [Fact]
    public void SelectDiceWithInputFirstInvalidThenCorrectData()
    {
      Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
      int expected = 3;
      var input = new StringReader("x\n6\n0\n" + expected.ToString());
      Console.SetIn(input);

      var v = getEnglishMainMenu();
      int result = v.SelectDice();

      Assert.Equal(expected, result);
      input.Close();
    }

    [Fact]
    public void MainViewCanPrintDice()
    {
      var mockDie = new Mock<DieImplemented>();
      var mockDice = new Mock<DiceImplemented>(mockDie.Object, mockDie.Object, mockDie.Object, mockDie.Object, mockDie.Object);
      var mockDiceView = new Mock<DiceView>(mockDice.Object);
      var englishView = new EnglishMainView(mockDiceView.Object);

      englishView.PrintDice();

      mockDiceView.Verify(d => d.Print(), Times.AtLeastOnce());
    }

    private EnglishMainView getEnglishMainMenu()
    {
      var mockDie = new Mock<DieImplemented>();
      var mockDice = new Mock<DiceImplemented>(mockDie.Object, mockDie.Object, mockDie.Object, mockDie.Object, mockDie.Object);
      var mockDiceView = new Mock<DiceView>(mockDice.Object);
      var englishView = new EnglishMainView(mockDiceView.Object);
      return englishView;
    }
  }
}