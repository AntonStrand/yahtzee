using System;

namespace Yahtzee.model.category
{
  public class Chance : Category
  {
    private int _value;
    public Chance(int v1, int v2, int v3, int v4, int v5)
    {
      _value = v5 == 2 ? 8 : 20;
    }

    public int GetValue() => _value;
  }
}