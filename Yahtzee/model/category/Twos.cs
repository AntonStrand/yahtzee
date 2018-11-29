using System;

namespace YahtzeeApp.model.category
{
  public class Twos
  {
    public Twos(Dice dice) { if (dice == null) throw new ArgumentNullException(); }

    public int GetValue() => 10;
  }
}