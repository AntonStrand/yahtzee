using System;
using System.Collections.Generic;

namespace Yahtzee.model
{
  public class Dice
  {
    public enum DiceList
    {
      Die1,
      Die2,
      Die3,
      Die4,
      Die5,
    }
    private List<Die> _allDice;
    private List<Die> _throwDice;

    public Dice(Die d1, Die d2, Die d3, Die d4, Die d5)
    {
      _allDice = new List<Die>();
      _allDice.Add(d1);
      _allDice.Add(d2);
      _allDice.Add(d3);
      _allDice.Add(d4);
      _allDice.Add(d5);
      _throwDice = new List<Die>(_allDice);
    }

    public void Throw() => _throwDice.ForEach(die => die.Throw());

    public void KeepDie(DiceList index) => _throwDice.RemoveAt(0);
  }
}