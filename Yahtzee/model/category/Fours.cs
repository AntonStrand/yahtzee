using System;

namespace YahtzeeApp.model.category
{
  public class Fours : Category
  {
    public Fours(Dice dice) { if (dice == null) throw new ArgumentNullException(); }

    public int GetValue() => 0;
  }
}