using System;
using System.Collections.Generic;
using System.Linq;

namespace YahtzeeApp.model.category
{
  public class Yahtzee : Category
  {
    public Yahtzee(int v1, int v2, int v3, int v4, int v5)
    {
      if (IsAnyDifferent(v1, v2, v3, v4, v5)) throw new ArgumentException();
    }

    public int GetValue() => 50;

    private bool IsAnyDifferent(int v1, int v2, int v3, int v4, int v5) =>
      new List<int> { v1, v2, v3, v4, v5 }.Any(v => v != v1);
  }
}