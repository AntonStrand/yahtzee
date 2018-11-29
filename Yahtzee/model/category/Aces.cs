using System;

namespace YahtzeeApp.model.category
{
  public class Aces
  {
    public Aces(Dice dice) { throw new ArgumentNullException(); }

    public int GetValue() => 0;
  }
}