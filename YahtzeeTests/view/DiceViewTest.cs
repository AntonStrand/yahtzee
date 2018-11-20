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
      }
    }
  }
}