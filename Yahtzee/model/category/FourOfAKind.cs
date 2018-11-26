using System;

namespace YahtzeeApp.model.category
{
  public class FourOfAKind : Category
  {
    private int _value;

    public FourOfAKind(int v1, int v2, int v3, int v4)
    {
      if (IsDifferent(v1, v2, v3, v4)) throw new ArgumentException();
      _value = v1 * 4;
    }

    public int GetValue() => _value;

    private bool IsDifferent(int v1, int v2, int v3, int v4) => (v1 != v2 || v2 != v3 || v3 != v4);
  }
}