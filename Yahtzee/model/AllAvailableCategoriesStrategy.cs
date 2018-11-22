using System;
using System.Collections.Generic;
using Yahtzee.model.category;

namespace Yahtzee.model
{
  public class AllAvailableCategoriesStrategy
  {
    public void GetCategories(Dice dice, ScoreBoard scoreBoard)
    {
      if (IsEitherNull(dice, scoreBoard)) throw new ArgumentNullException();
    }

    private bool IsEitherNull(Dice dice, ScoreBoard scoreBoard) => dice == null || scoreBoard == null;
  }
}