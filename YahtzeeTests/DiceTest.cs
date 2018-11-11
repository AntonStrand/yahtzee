using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Yahtzee.model;

namespace YahtzeeTests
{
  public class DiceTest
  {
    public class DieStub : Die {
      private bool _hasBeenThrown;
      public bool HasBeenThrown {get => _hasBeenThrown;}
      public override void Throw() {
        _hasBeenThrown = true;
      }
    }

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
  }
}
