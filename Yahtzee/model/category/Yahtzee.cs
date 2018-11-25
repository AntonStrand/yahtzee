using System;
using System.Collections.Generic;
using System.Linq;

namespace Yahtzee.model.category
{
  public class Yahtzee : Category
  {
    public Yahtzee(int v1, int v2, int v3, int v4, int v5)
    {
      if (v2 != v3) throw new ArgumentException();
    }

    public int GetValue() => 50;
  }
}