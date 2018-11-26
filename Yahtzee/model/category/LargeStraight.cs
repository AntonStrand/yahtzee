using System;
using System.Collections.Generic;
using System.Linq;

namespace YahtzeeApp.model.category
{
  public class LargeStraight : Category
  {
    public LargeStraight(int v1, int v2, int v3, int v4, int v5)
    {
      if (IsInvalidInput(v1, v2, v3, v4, v5)) throw new ArgumentException();
    }

    public int GetValue() => 20;

    private bool IsInvalidInput(int v1, int v2, int v3, int v4, int v5) =>
      new List<int> { v1, v2, v3, v4, v5 }.OrderBy(v => v).Where((value, i) => value != (i + 2)).ToList().Count != 0;
  }
}