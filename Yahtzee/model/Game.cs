using System;
using YahtzeeApp.model.rules;

namespace YahtzeeApp.model
{
  public class Game
  {
    public Game(AvailableCategoriesStrategy categoryRule, Dice dice)
    {
      if (categoryRule == null) throw new ArgumentNullException();
    }

    public int GetNumberOfThrowsLeft() => 3;
  }
}