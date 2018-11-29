using System;

namespace YahtzeeApp.model.category
{
  public class Twos : Category
  {
    public Twos(Dice dice) { if (dice == null) throw new ArgumentNullException(); }

    public int GetValue() => 10;
  }
}