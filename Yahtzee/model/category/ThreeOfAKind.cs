using System;

namespace Yahtzee.model.category
{
  public class ThreeOfAKind : Category
  {
    public ThreeOfAKind(int v1, int v2, int v3)
    {
      if (v1 != v2) throw new ArgumentException();
    }

    public int GetValue() => 0;
  }
}