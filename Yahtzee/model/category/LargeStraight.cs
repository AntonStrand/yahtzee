using System;
using System.Collections.Generic;
using System.Linq;

namespace Yahtzee.model.category
{
  public class LargeStraight : Category
  {
    public LargeStraight(int v1, int v2, int v3, int v4, int v5)
    {
      if (new List<int> { v1, v2, v3, v4, v5 }.OrderBy(v => v).Where((value, i) => value != (i + 2)).ToList().Count != 0) throw new ArgumentException();
    }

    public int GetValue() => 20;
  }
}