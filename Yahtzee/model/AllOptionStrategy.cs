using System;
using System.Collections.Generic;

namespace Yahtzee.model
{
  public class AllOptionStrategy
  {
    public List<int> GetOptions(Dice dice)
    {
      if (dice == null) throw new ArgumentNullException();
      return new List<int>();
    }
  }
}