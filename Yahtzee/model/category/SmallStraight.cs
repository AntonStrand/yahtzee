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
      if (!IsCorrectInput(values)) throw new ArgumentException();
    }

    public int GetValue() => 15;

    private bool IsOutOfRange(List<int> list) => list.Count != 5;

    private bool HasDoublets(List<int> list) => list.Distinct().ToList().Count != list.Count;

    private bool IsCorrectInput(List<int> list) => list.OrderBy(v => v).Where((value, i) => value != (i + 1)).ToList().Count == 0;
  }
}