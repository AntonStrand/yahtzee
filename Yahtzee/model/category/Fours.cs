using System;
using System.Linq;

namespace YahtzeeApp.model.category
{
  public class Fours : Category
  {
    private int _value;

    public Fours(Dice dice)
    {
      if (dice == null) throw new ArgumentNullException();
      _value = dice.GetValues().Where(x => x == 4).ToList().Count == 5
        ? 20
        : dice.GetValues().Where(x => x == 4).ToList().Count == 0
          ? 0
          : 4;
    }

    public int GetValue() => _value;
  }
}