using System;
using System.Collections.Generic;
using System.Linq;

namespace YahtzeeApp.model.category
{
  public class SmallStraight : Category
  {
    public SmallStraight(int v1, int v2, int v3, int v4, int v5)
    {
      List<int> values = new List<int> { v1, v2, v3, v4, v5 };
      if (IsInvalidInput(values)) throw new ArgumentException();
    }

    public int GetValue() => 15;

    private bool IsInvalidInput(List<int> list) =>
      list.OrderBy(v => v).Where((value, i) => value != (i + 1)).ToList().Count != 0;
  }
}