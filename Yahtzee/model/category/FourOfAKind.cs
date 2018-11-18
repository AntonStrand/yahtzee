using System;

namespace Yahtzee.model.category
{
  public class FourOfAKind : Category
  {
    public FourOfAKind(int v1, int v2, int v3, int v4)
    {
      if (IsDifferent(v1, v2, v3, v4)) throw new ArgumentException();
    }

    public int GetValue() => 20;

    private bool IsDifferent(int v1, int v2, int v3, int v4) => (v1 != v2 || v2 != v3 || v3 != v4);
  }
}