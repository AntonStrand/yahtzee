using System;

namespace Yahtzee.model.category
{
  public class FullHouse : Category
  {
    public FullHouse(Pair pair, ThreeOfAKind threeOfAKind)
    {
      if (pair == null) throw new ArgumentNullException();
      if (threeOfAKind == null) throw new ArgumentNullException();
    }

    public int GetValue() => 0;
  }
}