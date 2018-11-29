using System;
using System.Linq;

namespace YahtzeeApp.model.category
{
  public class Sixes : Category
  {
    private int _value;

    public Sixes(Dice dice)
    {
      if (dice == null) throw new ArgumentNullException();
      _value = dice.GetValues().Where(x => x == 6).ToList().Count > 0
        ? 24
        : 0;
    }

    public int GetValue() => _value;
  }
}