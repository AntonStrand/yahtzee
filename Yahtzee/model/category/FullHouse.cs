using System;

namespace Yahtzee.model.category
{
  public class FullHouse : Category
  {
    public FullHouse(Pair pair, ThreeOfAKind threeOfAKind)
    {
      throw new ArgumentNullException();
    }

    public int GetValue() => 0;
  }
}