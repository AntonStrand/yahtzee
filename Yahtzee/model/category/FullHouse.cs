using System;

namespace Yahtzee.model.category
{
  public class FullHouse : Category
  {
    public FullHouse(Pair pair, ThreeOfAKind threeOfAKind)
    {
      if (EitherIsNull(pair, threeOfAKind)) throw new ArgumentNullException();
    }

    public int GetValue() => 16;

    private bool EitherIsNull(Category fst, Category snd) => fst == null || snd == null;
  }
}