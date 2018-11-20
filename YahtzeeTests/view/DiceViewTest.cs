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
      var die = new Mock<Die>();
      die.Setup(d => d.GetValue()).Returns(1);
      var dice = new Dice(die.Object, die.Object, die.Object, die.Object, die.Object);

      var diceView = new DiceView(dice);

      using (StringWriter sw = new StringWriter())
      {
        Console.SetOut(sw);

        diceView.Print();

        string expected =
            " _____    _____    _____    _____    _____   \n"
         + "|     |  |     |  |     |  |     |  |     |  \n"
         + "|  o  |  |  o  |  |  o  |  |  o  |  |  o  |  \n"
         + "|_____|  |_____|  |_____|  |_____|  |_____|  \n";

        Assert.Equal(expected, sw.ToString());
        sw.Close();
      }
    }

    [Fact]
    public void ShouldPrintFiveTwos()
    {
      var die = new Mock<Die>();
      die.Setup(d => d.GetValue()).Returns(2);
      var dice = new Dice(die.Object, die.Object, die.Object, die.Object, die.Object);

      var diceView = new DiceView(dice);

      using (StringWriter sw = new StringWriter())
      {
        Console.SetOut(sw);

        diceView.Print();

        string expected =
            " _____    _____    _____    _____    _____   \n"
         + "|o    |  |o    |  |o    |  |o    |  |o    |  \n"
         + "|     |  |     |  |     |  |     |  |     |  \n"
         + "|____o|  |____o|  |____o|  |____o|  |____o|  \n";

        Assert.Equal(expected, sw.ToString());
        sw.Close();
      }
    }

    [Fact]
    public void ShouldPrintFiveThrees()
    {
      var die = new Mock<Die>();
      die.Setup(d => d.GetValue()).Returns(3);
      var dice = new Dice(die.Object, die.Object, die.Object, die.Object, die.Object);

      var diceView = new DiceView(dice);

      using (StringWriter sw = new StringWriter())
      {
        Console.SetOut(sw);

        diceView.Print();

        string expected =
            " _____    _____    _____    _____    _____   \n"
         + "|o    |  |o    |  |o    |  |o    |  |o    |  \n"
         + "|  o  |  |  o  |  |  o  |  |  o  |  |  o  |  \n"
         + "|____o|  |____o|  |____o|  |____o|  |____o|  \n";

        Assert.Equal(expected, sw.ToString());
        sw.Close();
      }
    }

    [Fact]
    public void ShouldPrintFiveFours()
    {
      var die = new Mock<Die>();
      die.Setup(d => d.GetValue()).Returns(4);
      var dice = new Dice(die.Object, die.Object, die.Object, die.Object, die.Object);

      var diceView = new DiceView(dice);

      using (StringWriter sw = new StringWriter())
      {
        Console.SetOut(sw);

        diceView.Print();

        string expected =
            " _____    _____    _____    _____    _____   \n"
         + "|o   o|  |o   o|  |o   o|  |o   o|  |o   o|  \n"
         + "|     |  |     |  |     |  |     |  |     |  \n"
         + "|o___o|  |o___o|  |o___o|  |o___o|  |o___o|  \n";

        Assert.Equal(expected, sw.ToString());
        sw.Close();
      }
    }

    [Fact]
    public void ShouldPrintFiveFives()
    {
      var die = new Mock<Die>();
      die.Setup(d => d.GetValue()).Returns(5);
      var dice = new Dice(die.Object, die.Object, die.Object, die.Object, die.Object);

      var diceView = new DiceView(dice);

      using (StringWriter sw = new StringWriter())
      {
        Console.SetOut(sw);

        diceView.Print();

        string expected =
            " _____    _____    _____    _____    _____   \n"
         + "|o   o|  |o   o|  |o   o|  |o   o|  |o   o|  \n"
         + "|  o  |  |  o  |  |  o  |  |  o  |  |  o  |  \n"
         + "|o___o|  |o___o|  |o___o|  |o___o|  |o___o|  \n";

        Assert.Equal(expected, sw.ToString());
        sw.Close();
      }
    }

    [Fact]
    public void ShouldPrintFiveSixes()
    {
      var die = new Mock<Die>();
      die.Setup(d => d.GetValue()).Returns(6);
      var dice = new Dice(die.Object, die.Object, die.Object, die.Object, die.Object);

      var diceView = new DiceView(dice);

      using (StringWriter sw = new StringWriter())
      {
        Console.SetOut(sw);

        diceView.Print();

        string expected =
            " _____    _____    _____    _____    _____   \n"
         + "|o   o|  |o   o|  |o   o|  |o   o|  |o   o|  \n"
         + "|o   o|  |o   o|  |o   o|  |o   o|  |o   o|  \n"
         + "|o___o|  |o___o|  |o___o|  |o___o|  |o___o|  \n";

        Assert.Equal(expected, sw.ToString());
        sw.Close();
      }
    }

    [Fact]
    public void ShouldPrintAllDices()
    {
      var die1 = new Mock<Die>();
      var die2 = new Mock<Die>();
      var die3 = new Mock<Die>();
      var die4 = new Mock<Die>();
      var die5 = new Mock<Die>();

      die1.Setup(d => d.GetValue()).Returns(1);
      die2.Setup(d => d.GetValue()).Returns(2);
      die3.Setup(d => d.GetValue()).Returns(3);
      die4.Setup(d => d.GetValue()).Returns(4);
      die5.Setup(d => d.GetValue()).Returns(5);

      var dice = new Dice(die1.Object, die2.Object, die3.Object, die4.Object, die5.Object);

      var diceView = new DiceView(dice);

      using (StringWriter sw = new StringWriter())
      {
        Console.SetOut(sw);

        diceView.Print();

        string expected =
            " _____    _____    _____    _____    _____   \n"
         + "|     |  |o    |  |o    |  |o   o|  |o   o|  \n"
         + "|  o  |  |     |  |  o  |  |     |  |  o  |  \n"
         + "|_____|  |____o|  |____o|  |o___o|  |o___o|  \n";

        Assert.Equal(expected, sw.ToString());
        sw.Close();
      }
    }
  }
}