using System;

namespace Yahtzee.model.category
{
  public class FullHouse : Category
  {
    private int _value;

    public FullHouse(Pair pair, ThreeOfAKind threeOfAKind)
    {
      if (EitherIsNull(pair, threeOfAKind)) throw new ArgumentNullException();
      _value = pair.GetValue() + threeOfAKind.GetValue();
    }

    public int GetValue() => _value;

    private bool EitherIsNull(Category fst, Category snd) => fst == null || snd == null;
  }
}