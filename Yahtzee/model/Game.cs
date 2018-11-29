using System;
using YahtzeeApp.model.rules;

namespace YahtzeeApp.model
{
  public class Game
  {
    private Dice _dice;

    public Game(AvailableCategoriesStrategy categoryRule) => Init(categoryRule, null);

    public Game(AvailableCategoriesStrategy categoryRule, Dice dice) => Init(categoryRule, dice);

    public Dice GetDice() => _dice;

    public int GetNumberOfThrowsLeft() => 3;

    public void Throw() => _dice.Throw();

    private void Init(AvailableCategoriesStrategy categoryRule, Dice dice)
    {
      if (IsNull(categoryRule)) throw new ArgumentNullException();
      _dice = IsNull(dice) ? InitDice() : dice;
    }

    private Dice InitDice() => new DiceImplemented(new DieImplemented(), new DieImplemented(), new DieImplemented(), new DieImplemented(), new DieImplemented());

    private bool IsNull(object o) => o == null;
  }
}