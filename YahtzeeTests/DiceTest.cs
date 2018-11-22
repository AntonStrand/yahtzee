using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;
using Yahtzee.model;

namespace YahtzeeTests
{
  public class DiceTest
  {
    [Fact]
    public void ShouldThrowAllDice()
    {
      var die1 = new Mock<Die>();
      var die2 = new Mock<Die>();
      var die3 = new Mock<Die>();
      var die4 = new Mock<Die>();
      var die5 = new Mock<Die>();

      Dice sut = new DiceImplemented(die1.Object, die2.Object, die3.Object, die4.Object, die5.Object);
      sut.Throw();

      die1.Verify(die => die.Throw(), Times.Once());
      die2.Verify(die => die.Throw(), Times.Once());
      die3.Verify(die => die.Throw(), Times.Once());
      die4.Verify(die => die.Throw(), Times.Once());
      die5.Verify(die => die.Throw(), Times.Once());
    }

    [Fact]
    public void ShouldKeepFirstDie()
    {
      var die1 = new Mock<Die>();
      var die2 = new Mock<Die>();

      Dice sut = new DiceImplemented(die1.Object, die2.Object, die2.Object, die2.Object, die2.Object);
      sut.KeepDie(DiceList.Die1);
      sut.Throw();

      die1.Verify(die => die.Throw(), Times.Never());
      die2.Verify(die => die.Throw(), Times.AtLeastOnce());
    }

    [Fact]
    public void ShouldKeepMultipleDice()
    {
      var keep1 = new Mock<Die>();
      var keep2 = new Mock<Die>();
      var die = new Mock<Die>();

      Dice sut = new DiceImplemented(keep1.Object, die.Object, keep2.Object, die.Object, die.Object);
      sut.KeepDie(DiceList.Die1);
      sut.KeepDie(DiceList.Die3);
      sut.Throw();
      keep1.Verify(d => d.Throw(), Times.Never());
      keep2.Verify(d => d.Throw(), Times.Never());
      die.Verify(d => d.Throw(), Times.AtLeastOnce());
    }

    [Fact]
    public void ShouldNotBeEffectedOfKeepingDieMultipleTimes()
    {
      var die = new Mock<Die>();
      var keep = new Mock<Die>();

      Dice sut = new DiceImplemented(die.Object, die.Object, keep.Object, die.Object, die.Object);
      sut.KeepDie(DiceList.Die3);
      sut.KeepDie(DiceList.Die3);
      sut.KeepDie(DiceList.Die3);
      sut.KeepDie(DiceList.Die3);

      sut.Throw();
      keep.Verify(d => d.Throw(), Times.Never());
      die.Verify(d => d.Throw(), Times.Once());
    }

    [Fact]
    public void ShouldReturn5Values()
    {
      Dice sut = new DiceImplemented(new DieImplemented(), new DieImplemented(), new DieImplemented(), new DieImplemented(), new DieImplemented());
      var actual = sut.GetValues().Count;

      var expected = 5;
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ShouldGetValuesFromDice()
    {
      var die1 = new Mock<Die>();
      var die2 = new Mock<Die>();
      var die3 = new Mock<Die>();
      var die4 = new Mock<Die>();
      var die5 = new Mock<Die>();

      die1.Setup(die => die.GetValue()).Returns(5);
      die2.Setup(die => die.GetValue()).Returns(5);
      die3.Setup(die => die.GetValue()).Returns(5);
      die4.Setup(die => die.GetValue()).Returns(5);
      die5.Setup(die => die.GetValue()).Returns(5);

      Dice sut = new DiceImplemented(die1.Object, die2.Object, die3.Object, die4.Object, die5.Object);

      var actual = sut.GetValues().Sum();
      var expected = 25;
      Assert.Equal(expected, actual);
    }
  }
}
