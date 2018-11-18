using System;

namespace Yahtzee.model.category
{
  public class ThreeOfAKind : Category
  {
    private int _value;

    public ThreeOfAKind(int v1, int v2, int v3)
    {
      if (IsDifferent(v1, v2, v3)) throw new ArgumentException();
      _value = v1 * 3;
    }

    public int GetValue() => _value;

    private bool IsDifferent(int v1, int v2, int v3) => (v1 != v2 || v2 != v3);
  }
}