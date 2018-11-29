using System;
using System.Linq;

namespace YahtzeeApp.model.category
{
  public class Aces
  {

    private int _value;
    public Aces(Dice dice)
    {
      if (dice == null) throw new ArgumentNullException();
      _value = dice.GetValues().Where(x => x == 1).Sum();
    }

    public int GetValue() => _value;
  }
}