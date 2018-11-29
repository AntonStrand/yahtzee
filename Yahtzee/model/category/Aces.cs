using System;

namespace YahtzeeApp.model.category
{
  public class Aces
  {
    public Aces(Dice dice)
    {
      if (dice == null) throw new ArgumentNullException();
    }

    public int GetValue() => 5;
  }
}