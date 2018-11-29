using System;
using YahtzeeApp.model.rules;

namespace YahtzeeApp.model
{
  public class Game
  {
    private Dice _dice;

    public Game(AvailableCategoriesStrategy categoryRule)
    {
      _dice = new DiceImplemented(new DieImplemented(), new DieImplemented(), new DieImplemented(), new DieImplemented(), new DieImplemented());
    }

    public Game(AvailableCategoriesStrategy categoryRule, Dice dice)
    {
      if (categoryRule == null) throw new ArgumentNullException();
      _dice = dice != null
        ? dice
        : new DiceImplemented(new DieImplemented(), new DieImplemented(), new DieImplemented(), new DieImplemented(), new DieImplemented());
    }

    public Dice GetDice() => _dice;

    public int GetNumberOfThrowsLeft() => 3;
  }
}