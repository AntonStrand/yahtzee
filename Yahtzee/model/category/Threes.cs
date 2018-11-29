using System;

namespace YahtzeeApp.model.category
{
  public class Threes : Category
  {
    public Threes(Dice dice) { if (dice == null) throw new ArgumentNullException(); }

    public int GetValue() => 3;
  }
}