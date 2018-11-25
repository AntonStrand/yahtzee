using System;
using System.IO;
using Xunit;
using Moq;
using Yahtzee.view;
using Yahtzee.model;
using System.Collections.Generic;

namespace YahtzeeTests
{
  public class DiceViewTest
  {
    [Fact]
    public void ShouldNotAcceptNull() =>
      Assert.Throws<ArgumentNullException>(() => new DiceView(null));

    [Fact]
    public void ShouldPrintFiveOnes()
    {
      string expected =
          " _____    _____    _____    _____    _____   \n"
       + "|     |  |     |  |     |  |     |  |     |  \n"
       + "|  o  |  |  o  |  |  o  |  |  o  |  |  o  |  \n"
       + "|_____|  |_____|  |_____|  |_____|  |_____|  \n"
       + "  (1)      (2)      (3)      (4)      (5)    \n";
      AssertView(expected, 1, 1, 1, 1, 1);
    }

    [Fact]
    public void ShouldPrintAllDicesOneToFive()
    {
      string expected =
          " _____    _____    _____    _____    _____   \n"
       + "|     |  |o    |  |o    |  |o   o|  |o   o|  \n"
       + "|  o  |  |     |  |  o  |  |     |  |  o  |  \n"
       + "|_____|  |____o|  |____o|  |o___o|  |o___o|  \n"
       + "  (1)      (2)      (3)      (4)      (5)    \n";
      AssertView(expected, 1, 2, 3, 4, 5);
    }

    [Fact]
    public void ShouldPrintAllDicesTwoToSix()
    {
      string expected =
          " _____    _____    _____    _____    _____   \n"
       + "|o    |  |o    |  |o   o|  |o   o|  |o   o|  \n"
       + "|     |  |  o  |  |     |  |  o  |  |o   o|  \n"
       + "|____o|  |____o|  |o___o|  |o___o|  |o___o|  \n"
       + "  (1)      (2)      (3)      (4)      (5)    \n";

      AssertView(expected, 2, 3, 4, 5, 6);
    }

    [Fact]
    public void ShouldPrintAllDicesAfterPrintingTwice()
    {
      string expected =
          " _____    _____    _____    _____    _____   \n"
       + "|o    |  |o    |  |o   o|  |o   o|  |o   o|  \n"
       + "|     |  |  o  |  |     |  |  o  |  |o   o|  \n"
       + "|____o|  |____o|  |o___o|  |o___o|  |o___o|  \n"
       + "  (1)      (2)      (3)      (4)      (5)    \n"
       + " _____    _____    _____    _____    _____   \n"
       + "|o    |  |o    |  |o   o|  |o   o|  |o   o|  \n"
       + "|     |  |  o  |  |     |  |  o  |  |o   o|  \n"
       + "|____o|  |____o|  |o___o|  |o___o|  |o___o|  \n"
       + "  (1)      (2)      (3)      (4)      (5)    \n";
      var fakeDice = new Mock<Dice>();
      fakeDice.Setup(d => d.GetValues()).Returns(new List<int>() { 2, 3, 4, 5, 6 });

      var diceView = new DiceView(fakeDice.Object);

      using (StringWriter sw = new StringWriter())
      {
        Console.SetOut(sw);

        diceView.Print();
        diceView.Print();

        Assert.Equal(expected, sw.ToString());
        sw.Close();
      }
    }
    private void AssertView(string expected, int v1, int v2, int v3, int v4, int v5)
    {
      var fakeDice = new Mock<Dice>();
      fakeDice.Setup(d => d.GetValues()).Returns(new List<int>() { v1, v2, v3, v4, v5 });

      var diceView = new DiceView(fakeDice.Object);

      using (StringWriter sw = new StringWriter())
      {
        Console.SetOut(sw);

        diceView.Print();

        Assert.Equal(expected, sw.ToString());
        sw.Close();
      }
    }
  }
}