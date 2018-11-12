using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;
using Yahtzee.model;

namespace YahtzeeTests
{
  public class DieStub : Die
  {
    private bool _hasBeenThrown;
    private int _value = 0;

    public bool HasBeenThrown { get => _hasBeenThrown; }
    public void Throw()
    {
      _hasBeenThrown = true;
      _value = 1;
    }

    public int GetValue() => _value;
  }

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

      Dice sut = new Dice(die1.Object, die2.Object, die3.Object, die4.Object, die5.Object);
      sut.Throw();
      die1.Verify(die => die.Throw(), Times.Exactly(1));
      die2.Verify(die => die.Throw(), Times.Exactly(1));
      die3.Verify(die => die.Throw(), Times.Exactly(1));
      die4.Verify(die => die.Throw(), Times.Exactly(1));
      die5.Verify(die => die.Throw(), Times.Exactly(1));
    }

    [Fact]
    public void ShouldKeepFirstDie()
    {
      DieStub die1 = new DieStub();
      DieStub die2 = new DieStub();
      DieStub die3 = new DieStub();
      DieStub die4 = new DieStub();
      DieStub die5 = new DieStub();

      Dice sut = new Dice(die1, die2, die3, die4, die5);
      sut.KeepDie(Dice.DiceList.Die1);
      int expected = die1.GetValue();
      sut.Throw();
      Assert.Equal(expected, die1.GetValue());
      Assert.NotEqual(expected, die2.GetValue());
    }

    [Fact]
    public void ShouldKeepMultipleDice()
    {
      DieStub die1 = new DieStub();
      DieStub die2 = new DieStub();
      DieStub die3 = new DieStub();
      DieStub die4 = new DieStub();
      DieStub die5 = new DieStub();

      Dice sut = new Dice(die1, die2, die3, die4, die5);
      sut.KeepDie(Dice.DiceList.Die1);
      sut.KeepDie(Dice.DiceList.Die3);
      int expected = die1.GetValue();
      sut.Throw();
      Assert.Equal(expected, die1.GetValue());
      Assert.Equal(expected, die3.GetValue());
      Assert.NotEqual(expected, die2.GetValue());
    }

    [Fact]
    public void ShouldNotBeEffectedOfKeepingDieMultipleTimes()
    {
      DieStub die1 = new DieStub();
      DieStub die2 = new DieStub();
      DieStub die3 = new DieStub();
      DieStub die4 = new DieStub();
      DieStub die5 = new DieStub();

      Dice sut = new Dice(die1, die2, die3, die4, die5);
      sut.KeepDie(Dice.DiceList.Die3);
      sut.KeepDie(Dice.DiceList.Die3);
      sut.KeepDie(Dice.DiceList.Die3);
      sut.KeepDie(Dice.DiceList.Die3);
      sut.Throw();
      var actual = sut.GetValues().Sum();
      var expected = 4;
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ShouldReturn5Values()
    {
      DieStub die1 = new DieStub();
      DieStub die2 = new DieStub();
      DieStub die3 = new DieStub();
      DieStub die4 = new DieStub();
      DieStub die5 = new DieStub();

      Dice sut = new Dice(die1, die2, die3, die4, die5);
      var actual = sut.GetValues().Count;
      var expected = 5;
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ShouldGetValuesFromDice()
    {
      DieStub die1 = new DieStub();
      DieStub die2 = new DieStub();
      DieStub die3 = new DieStub();
      DieStub die4 = new DieStub();
      DieStub die5 = new DieStub();

      Dice sut = new Dice(die1, die2, die3, die4, die5);

      var actual = sut.GetValues().Sum();
      var expected = 0;
      Assert.Equal(expected, actual);

      sut.Throw();
      actual = sut.GetValues().Sum();
      expected = 5;
      Assert.Equal(expected, actual);
    }
  }
}
