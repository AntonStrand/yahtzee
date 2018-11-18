using System;
using System.Collections.Generic;
using System.Linq;

namespace Yahtzee.model.category
{
  public class SmallStraight : Category
  {
    public SmallStraight(List<int> values)
    {
      if (values == null) throw new ArgumentNullException();
      if (IsOutOfRange(values)) throw new ArgumentOutOfRangeException();
      if (values.Distinct().ToList().Count != 5) throw new ArgumentException();
    }

    public int GetValue() => 0;

    private bool IsOutOfRange(List<int> list) => list.Count != 5;
  }
}