using System;
using System.Collections.Generic;
using Yahtzee.model.category;

namespace Yahtzee.model
{
  public class AllAvailableCategoriesStrategy
  {
    public void GetCategories(Dice dice, ScoreBoard scoreBoard)
    {
      if (dice == null) throw new ArgumentNullException();
    }
  }
}