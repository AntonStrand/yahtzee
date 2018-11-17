using System;
using System.Collections.Generic;

namespace Yahtzee.model.category
{
  public class AllOptionStrategy
  {
    public List<Category> GetOptions(Dice dice)
    {
      if (dice == null) throw new ArgumentNullException();
      return new List<Category>() { new TwoPair(new Pair(1, 1), new Pair(1, 1)) };
    }
  }
}