using System;
using System.Linq;

namespace YahtzeeApp.model.category
{
  public class Fives : Category
  {
    private int _value;
    public Fives(Dice dice)
    {
      if (dice == null) throw new ArgumentNullException();
      _value = dice.GetValues().Where(x => x == 5).Sum();
    }

    public int GetValue() => _value;
  }
}