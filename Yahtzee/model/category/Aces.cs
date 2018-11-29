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
      _value = dice.GetValues().Where(x => x == 1).ToList().Count == 5
        ? 5
        : dice.GetValues().Where(x => x == 1).ToList().Count == 2
          ? 2
          : 0;
    }

    public int GetValue() => _value;
  }
}