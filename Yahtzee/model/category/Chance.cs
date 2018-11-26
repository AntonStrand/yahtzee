using System;

namespace Yahtzee.model.category
{
  public class Chance : Category
  {
    private int _value;
    public Chance(int v1, int v2, int v3, int v4, int v5) =>
      _value = v1 + v2 + v3 + v4 + v5;

    public int GetValue() => _value;
  }
}