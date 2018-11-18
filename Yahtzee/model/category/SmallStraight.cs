using System;
using System.Collections.Generic;

namespace Yahtzee.model.category
{
  public class SmallStraight : Category
  {
    public SmallStraight(List<int> values)
    {
      if (values == null) throw new ArgumentNullException();
      if (IsOutOfRange(values)) throw new ArgumentOutOfRangeException();
    }

    public int GetValue() => 0;

    private bool IsOutOfRange(List<int> list) => list.Count != 5;
  }
}