using System;
using System.Linq;

namespace YahtzeeApp.model.category
{
  public class Twos : Category
  {
    private int _value;

    public Twos(Dice dice)
    {
      if (dice == null) throw new ArgumentNullException();
      _value = dice.GetValues().Where(x => x == 2).ToList().Count == 5
        ? 10
        : dice.GetValues().Where(x => x == 2).ToList().Count == 0
          ? 0
          : 2;
    }

    public int GetValue() => _value;
  }
}