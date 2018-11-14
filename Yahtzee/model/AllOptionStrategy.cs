using System;
using System.Collections.Generic;

namespace Yahtzee.model
{
  public class AllOptionStrategy
  {
    // Move to a separate file as refactor
    class Pair : Category
    {
      public int GetValue() => 0;
    }
    public List<Category> GetOptions(Dice dice)
    {
      if (dice == null) throw new ArgumentNullException();
      return new List<Category>() { new Pair() };
    }
  }
}