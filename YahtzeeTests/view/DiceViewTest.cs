using System;
using System.IO;
using Xunit;
using Moq;
using Yahtzee.view;
using Yahtzee.model;

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
       + "|_____|  |_____|  |_____|  |_____|  |_____|  \n";
      AssertView(expected, 1, 1, 1, 1, 1);
    }

    [Fact]
    public void ShouldPrintAllDicesOneToFive()
    {
      string expected =
          " _____    _____    _____    _____    _____   \n"
       + "|     |  |o    |  |o    |  |o   o|  |o   o|  \n"
       + "|  o  |  |     |  |  o  |  |     |  |  o  |  \n"
       + "|_____|  |____o|  |____o|  |o___o|  |o___o|  \n";
      AssertView(expected, 1, 2, 3, 4, 5);
    }

    [Fact]
    public void ShouldPrintAllDicesTwoToSix()
    {
      string expected =
          " _____    _____    _____    _____    _____   \n"
       + "|o    |  |o    |  |o   o|  |o   o|  |o   o|  \n"
       + "|     |  |  o  |  |     |  |  o  |  |o   o|  \n"
       + "|____o|  |____o|  |o___o|  |o___o|  |o___o|  \n";

      AssertView(expected, 2, 3, 4, 5, 6);
    }

    private void AssertView(string expected, int v1, int v2, int v3, int v4, int v5)
    {
      var die1 = new Mock<Die>();
      var die2 = new Mock<Die>();
      var die3 = new Mock<Die>();
      var die4 = new Mock<Die>();
      var die5 = new Mock<Die>();

      die1.Setup(d => d.GetValue()).Returns(v1);
      die2.Setup(d => d.GetValue()).Returns(v2);
      die3.Setup(d => d.GetValue()).Returns(v3);
      die4.Setup(d => d.GetValue()).Returns(v4);
      die5.Setup(d => d.GetValue()).Returns(v5);

      var dice = new Dice(die1.Object, die2.Object, die3.Object, die4.Object, die5.Object);

      var diceView = new DiceView(dice);

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