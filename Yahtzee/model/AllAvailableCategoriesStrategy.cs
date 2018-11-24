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
      return GetTwoPair(pairs).Concat(pairs).Concat(GetThreeOfAKind(dice)).ToList();
    }

    private bool IsEitherNull(Dice dice, ScoreBoard scoreBoard) => dice == null || scoreBoard == null;

    private List<Pair> GetPairs(Dice dice) =>
      GetFrequencyTable(dice)
        .Where(x => x.Value % 2 == 0)
        .Select(x => new Pair(x.Key, x.Key))
        .ToList();

    private List<Category> GetTwoPair(List<Pair> pairs) =>
      (pairs.Count == 2)
        ? new List<Category>() { new TwoPair(pairs[0], pairs[1]) }
        : new List<Category>();

    private IEnumerable<Category> GetThreeOfAKind(Dice dice) =>
      GetFrequencyTable(dice)
        .Where(ValueIs(3))
        .Select(_ => new ThreeOfAKind(5, 5, 5));

    private Dictionary<int, int> GetFrequencyTable(Dice dice) =>
      dice
        .GetValues()
        .GroupBy(x => x)
        .ToDictionary(x => x.Key, x => x.Count());

    private Func<int, Func<KeyValuePair<int, int>, bool>> ValueIs = comparedTo => x => x.Value == comparedTo;
  }
}