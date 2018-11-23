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
      var pairs = GetPairs(dice);
      return GetTwoPair(pairs).Concat(pairs).ToList();
    }

    private bool IsEitherNull(Dice dice, ScoreBoard scoreBoard) => dice == null || scoreBoard == null;

    private List<Category> GetTwoPair(List<Pair> pairs)
    {
      return (pairs.Count == 2)
       ? new List<Category>() { new TwoPair(pairs[0], pairs[1]) }
       : new List<Category>();
    }

    private List<Pair> GetPairs(Dice dice) =>
      GetFrequencyTable(dice)
        .Where(x => x.Value == 2 || x.Value == 4)
        .Select(x => new Pair(x.Key, x.Key))
        .ToList();

    private Dictionary<int, int> GetFrequencyTable(Dice dice) =>
      dice
        .GetValues()
        .GroupBy(x => x)
        .ToDictionary(x => x.Key, x => x.Count());
  }
}