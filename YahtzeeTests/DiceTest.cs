using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
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
      DieStub die1 = new DieStub();
      DieStub die2 = new DieStub();
      DieStub die3 = new DieStub();
      DieStub die4 = new DieStub();
      DieStub die5 = new DieStub();

      Dice sut = new Dice(die1, die2, die3, die4, die5);
      sut.Throw();
      Assert.True(die1.HasBeenThrown);
      Assert.True(die2.HasBeenThrown);
      Assert.True(die3.HasBeenThrown);
      Assert.True(die4.HasBeenThrown);
      Assert.True(die5.HasBeenThrown);
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
    public void ShouldKeepMultipletDice()
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
  }
}
