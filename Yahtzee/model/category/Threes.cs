using System;
using System.Linq;

namespace YahtzeeApp.model.category
{
  public class Threes : Category
  {
    private int _value;
    public Threes(Dice dice)
    {
      if (dice == null) throw new ArgumentNullException();
      _value = dice.GetValues().Where(x => x == 3).Sum();
    }

    public int GetValue() => _value;
  }
}