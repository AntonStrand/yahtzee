using System;

namespace YahtzeeApp.model.category
{
  public class Fives : Category
  {
    public Fives(Dice dice) { if (dice == null) throw new ArgumentNullException(); }

    public int GetValue() => 15;
  }
}