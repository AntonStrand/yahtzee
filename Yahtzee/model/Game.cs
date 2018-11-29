using System;
using YahtzeeApp.model.rules;

namespace YahtzeeApp.model
{
  public class Game
  {
    private const int NUMBER_OF_THROWS = 3;
    private Dice _dice;
    private int _throwCount;

    public Game(AvailableCategoriesStrategy categoryRule) => Init(categoryRule, null);

    public Game(AvailableCategoriesStrategy categoryRule, Dice dice) => Init(categoryRule, dice);

    public bool IsRoundDone() => NUMBER_OF_THROWS == _throwCount;

    public Dice GetDice() => _dice;

    public int GetNumberOfThrowsLeft() => NUMBER_OF_THROWS - _throwCount;

    public void KeepDie(DiceList dieId) => _dice.KeepDie(dieId);

    public void Throw()
    {
      _throwCount++;
      _dice.Throw();
    }

    public void StartNextRound() => _throwCount = 0;

    private void Init(AvailableCategoriesStrategy categoryRule, Dice dice)
    {
      if (IsNull(categoryRule)) throw new ArgumentNullException();
      _dice = IsNull(dice) ? InitDice() : dice;
    }

    private Dice InitDice() => new DiceImplemented(new DieImplemented(), new DieImplemented(), new DieImplemented(), new DieImplemented(), new DieImplemented());

    private bool IsNull(object o) => o == null;
  }
}