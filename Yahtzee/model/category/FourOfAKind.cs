using System;

namespace Yahtzee.model.category
{
  public class FourOfAKind : Category
  {
    private int _value;

    public FourOfAKind(int v1, int v2, int v3, int v4)
    {
    }

    public int GetValue() => _value;
  }
}