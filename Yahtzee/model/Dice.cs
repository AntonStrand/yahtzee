using System;
using System.Collections.Generic;
using System.Linq;

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
    private List<Die> _dice;
    private List<Die> _keep;

    public Dice(Die d1, Die d2, Die d3, Die d4, Die d5)
    {
      _keep = new List<Die>();
      _dice = new List<Die>();
      _dice.Add(d1);
      _dice.Add(d2);
      _dice.Add(d3);
      _dice.Add(d4);
      _dice.Add(d5);
    }

    public void Throw() => GetAvailableDice().ForEach(ThrowDie);

    public void KeepDie(DiceList index) => _keep.Add(_dice[(int)index]);

    public List<int> GetValues() => _dice.Select(die => die.GetValue()).ToList();

    private List<Die> GetAvailableDice() => _dice.Except(_keep).ToList();

    private void ThrowDie(Die die) => die.Throw();
  }
}