using System;

namespace YahtzeeApp.model.category
{
  public class Sixes : Category
  {
    public Sixes(Dice dice) { if (dice == null) throw new ArgumentNullException(); }

    public int GetValue() => 24;
  }
}