using System;
using System.Collections.Generic;
using System.Linq;

namespace YahtzeeApp.model
{
  public class DiceImplemented : Dice
  {
    private List<Die> _dice;
    private List<Die> _keep;

    public DiceImplemented(Die d1, Die d2, Die d3, Die d4, Die d5)
    {
      _dice = new List<Die> { d1, d2, d3, d4, d5 };
      _keep = new List<Die>();
    }

    public void Throw() => GetAvailableDice().ForEach(ThrowDie);

    public void KeepDie(DiceList index) => _keep.Add(_dice[(int)index]);

    public List<int> GetValues() => _dice.Select(die => die.GetValue()).ToList();

    private List<Die> GetAvailableDice() => _dice.Except(_keep).ToList();

    private void ThrowDie(Die die) => die.Throw();
  }
}