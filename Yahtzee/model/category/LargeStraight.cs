using System;
using System.Collections.Generic;
using System.Linq;

namespace Yahtzee.model.category
{
  public class LargeStraight : Category
  {
    public LargeStraight(int v1, int v2, int v3, int v4, int v5)
    {
      if (v1 != 2 || v2 != 3 || v3 != 4 || v4 != 5 || v5 != 6) throw new ArgumentException();
    }

    public int GetValue() => 20;
  }
}