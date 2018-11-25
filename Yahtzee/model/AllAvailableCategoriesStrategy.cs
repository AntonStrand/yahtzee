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
      return GetLargeStraight(dice)
          .Concat(GetSmallStraight(dice))
          .Concat(GetFourOfAKind(dice))
          .Concat(GetThreeOfAKind(dice))
          .Concat(GetTwoPair(dice))
          .Concat(GetPairs(dice))
          .ToList();
    }

    private bool IsEitherNull(Dice dice, ScoreBoard scoreBoard) => dice == null || scoreBoard == null;

    private List<Pair> GetPairs(Dice dice) =>
      GetFrequencyTable(dice)
        .Where(x => x.Value % 2 == 0)
        .Select(x => new Pair(x.Key, x.Key))
        .ToList();

    private List<Category> GetTwoPair(Dice dice)
    {
      var twoDifferentPair = GetPairs(dice);
      if (twoDifferentPair.Count == 2) return new List<Category>() { new TwoPair(twoDifferentPair[0], twoDifferentPair[1]) };

      var twoSamePair = GetFrequencyTable(dice).Where(ValueIs(4)).Select(x => new Pair(x.Key, x.Key)).ToList();
      if (twoSamePair.Count == 1) return new List<Category>() { new TwoPair(twoSamePair[0], twoSamePair[0]) };

      return new List<Category>();
    }

    private IEnumerable<Category> GetThreeOfAKind(Dice dice) =>
      GetFrequencyTable(dice)
        .Where(ValueIs(3))
        .Select(x => new ThreeOfAKind(x.Key, x.Key, x.Key));

    private IEnumerable<Category> GetFourOfAKind(Dice dice) =>
      GetFrequencyTable(dice)
        .Where(ValueIs(4))
        .Select(x => x.Key)
        .Select(v => new FourOfAKind(v, v, v, v));

    private List<Category> GetSmallStraight(Dice dice) =>
      IsASmallStraight(dice)
        ? new List<Category>() { new SmallStraight(1, 2, 3, 4, 5) }
        : new List<Category>();

    private List<Category> GetLargeStraight(Dice dice) =>
      IsALargeStraight(dice)
        ? new List<Category> { new LargeStraight(2, 3, 4, 5, 6) }
        : new List<Category>();


    private Dictionary<int, int> GetFrequencyTable(Dice dice) =>
      dice
        .GetValues()
        .GroupBy(x => x)
        .ToDictionary(x => x.Key, x => x.Count());

    private Func<int, Func<KeyValuePair<int, int>, bool>> ValueIs = comparedTo => x => x.Value == comparedTo;

    private bool IsASmallStraight(Dice dice) => IsAStraight(1, dice);
    private bool IsALargeStraight(Dice dice) => IsAStraight(2, dice);

    private bool IsAStraight(int offset, Dice dice) =>
        dice.GetValues().OrderBy(v => v).Where((value, i) => value == (i + offset)).ToList().Count == 5;
  }
}