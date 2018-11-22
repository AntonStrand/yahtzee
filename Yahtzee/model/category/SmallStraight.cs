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
      if (HasDoublets(values)) throw new ArgumentException();
    }

    public int GetValue() => 0;

    private bool IsOutOfRange(List<int> list) => list.Count != 5;

    private bool HasDoublets(List<int> list) => list.Distinct().ToList().Count != list.Count;
  }
}