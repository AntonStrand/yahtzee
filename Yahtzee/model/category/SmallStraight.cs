using System;
using System.Collections.Generic;
using System.Linq;

namespace Yahtzee.model.category
{
  public class SmallStraight : Category
  {
    public SmallStraight(int v1, int v2, int v3, int v4, int v5)
    {
      if (v1 != 1 || v2 != 2 || v3 != 3 || v4 != 4 || v5 != 5) throw new ArgumentException();
    }

    public int GetValue() => 15;
  }
}