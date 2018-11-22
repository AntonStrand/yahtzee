using System;
using System.Collections.Generic;
using Yahtzee.model.category;

namespace Yahtzee.model
{
  public class AllAvailableCategoriesStrategy
  {
    public List<Category> GetCategories(Dice dice, ScoreBoard scoreBoard)
    {
      if (IsEitherNull(dice, scoreBoard)) throw new ArgumentNullException();
      return new List<Category>() { new Pair(6, 6) };
    }

    private bool IsEitherNull(Dice dice, ScoreBoard scoreBoard) => dice == null || scoreBoard == null;
  }
}