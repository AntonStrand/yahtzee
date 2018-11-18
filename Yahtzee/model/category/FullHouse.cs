using System;

namespace Yahtzee.model.category
{
  public class FullHouse : Category
  {
    public FullHouse(Pair pair, ThreeOfAKind threeOfAKind) { }

    public int GetValue() => 0;
  }
}