using System;
using YahtzeeApp.model.rules;

namespace YahtzeeApp.model
{
  public class Game
  {
    private Dice _dice;

    public Game(AvailableCategoriesStrategy categoryRule) => _dice = initDice();

    public Game(AvailableCategoriesStrategy categoryRule, Dice dice)
    {
      if (categoryRule == null) throw new ArgumentNullException();
      _dice = dice != null ? dice : initDice();
    }

    public Dice GetDice() => _dice;

    public int GetNumberOfThrowsLeft() => 3;

    private Dice initDice() => new DiceImplemented(new DieImplemented(), new DieImplemented(), new DieImplemented(), new DieImplemented(), new DieImplemented());
  }
}