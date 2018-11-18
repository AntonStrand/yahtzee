using System;
using System.Collections.Generic;

namespace Yahtzee.model.category
{
  public class SmallStraight : Category
  {
    public SmallStraight(List<int> values)
    {
      if (values == null) throw new ArgumentNullException();
      if (values.Count < 5) throw new ArgumentOutOfRangeException();
      if (values.Count > 5) throw new ArgumentOutOfRangeException();
    }

    public int GetValue() => 0;
  }
}