using System;
using System.Collections.Generic;
using System.Linq;
using Yahtzee.model.category;

namespace Yahtzee.model
{
  public class AllAvailableCategoriesStrategy
  {
    public List<Category> GetCategories(Dice dice, ScoreBoard scoreBoard)
    {
      if (IsEitherNull(dice, scoreBoard)) throw new ArgumentNullException();
      var pairs = dice.GetValues().GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count()).Where(x => x.Value == 2).Select(x => x.Key).Select(v => new Pair(v, v)).ToList();
      return new List<Category>(pairs);
    }

    private bool IsEitherNull(Dice dice, ScoreBoard scoreBoard) => dice == null || scoreBoard == null;
  }
}