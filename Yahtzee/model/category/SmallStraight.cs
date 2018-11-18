using System;
using System.Collections.Generic;

namespace Yahtzee.model.category
{
  public class SmallStraight : Category
  {
    public SmallStraight(List<int> values)
    {
      if (values == null) throw new ArgumentNullException();
    }

    public int GetValue() => 0;
  }
}