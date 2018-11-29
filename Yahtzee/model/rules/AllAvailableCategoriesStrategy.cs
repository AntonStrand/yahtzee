using System;
using System.Collections.Generic;
using System.Linq;
using YahtzeeApp.model.category;

namespace YahtzeeApp.model.rules
{
  public class AllAvailableCategoriesStrategy : AvailableCategoriesStrategy
  {
    public List<Category> GetCategories(Dice dice, ScoreBoard scoreBoard)
    {
      if (IsAnyNull(dice, scoreBoard)) throw new ArgumentNullException();
      return GetAvailableCategories(dice, scoreBoard);
    }

    private List<Category> GetAvailableCategories(Dice dice, ScoreBoard scoreBoard) =>
      RemoveOccupiedCategories(GetPossibleCategories(dice), scoreBoard.GetOccupiedCategories());

    private List<Category> GetPossibleCategories(Dice dice) =>
      GetAces(dice)
        .Concat(GetTwos(dice))
        .Concat(new List<Category> { new Threes(dice) })
        .Concat(GetPairs(dice))
        .Concat(GetTwoPair(dice))
        .Concat(GetThreeOfAKind(dice))
        .Concat(GetFourOfAKind(dice))
        .Concat(GetSmallStraight(dice))
        .Concat(GetLargeStraight(dice))
        .Concat(GetFullHouse(dice))
        .Concat(GetYahtzee(dice))
        .Concat(GetChance(dice))
        .ToList();

    private List<Category> RemoveOccupiedCategories(List<Category> allPossible, List<Category> allOccupied) =>
      allPossible
        .Where(possible => allOccupied.All(taken => taken.GetType() != possible.GetType()))
        .ToList();

    private List<Category> GetAces(Dice dice) => new List<Category> { new Aces(dice) };

    private List<Category> GetTwos(Dice dice) => new List<Category> { new Twos(dice) };

    private List<Pair> GetPairs(Dice dice) =>
      GetFrequencyTable(dice)
        .Where(x => x.Value >= 2)
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

    private IEnumerable<ThreeOfAKind> GetThreeOfAKind(Dice dice) =>
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

    private List<Category> GetFullHouse(Dice dice)
    {
      var pairs = GetFrequencyTable(dice).Where(ValueIs(2)).Select(x => new Pair(x.Key, x.Key));
      Pair pair = Head(pairs);
      ThreeOfAKind threeOfAKind = Head(GetThreeOfAKind(dice));

      return (IsAnyNull(pair, threeOfAKind))
        ? new List<Category>()
        : new List<Category> { new FullHouse(pair, threeOfAKind) };
    }

    private List<Category> GetYahtzee(Dice dice) =>
      dice.GetValues().All(v => v == dice.GetValues()[0])
        ? new List<Category> { new Yahtzee(6, 6, 6, 6, 6) }
        : new List<Category>();

    private List<Category> GetChance(Dice dice) => new List<Category> { new Chance(dice.GetValues()) };

    private Dictionary<int, int> GetFrequencyTable(Dice dice) =>
      dice
        .GetValues()
        .GroupBy(x => x)
        .ToDictionary(x => x.Key, x => x.Count());

    private T Head<T>(IEnumerable<T> enumerable) => enumerable.ToList().Count > 0 ? enumerable.ToList()[0] : default(T);

    private bool IsAnyNull(params Object[] objects) => objects.Any(o => o == null);

    private Func<int, Func<KeyValuePair<int, int>, bool>> ValueIs = comparedTo => x => x.Value == comparedTo;

    private bool IsASmallStraight(Dice dice) => IsAStraight(1, dice);

    private bool IsALargeStraight(Dice dice) => IsAStraight(2, dice);

    private bool IsAStraight(int offset, Dice dice) =>
        dice.GetValues().OrderBy(v => v).Where((value, i) => value == (i + offset)).ToList().Count == 5;
  }
}