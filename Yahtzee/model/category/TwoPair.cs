using System;

namespace Yahtzee.model.category
{
  public class TwoPair : Category
  {
    public TwoPair(Pair pair1, Pair pair2)
    {
      if (pair1 == null) throw new ArgumentNullException();
      if (pair2 == null) throw new ArgumentNullException();
    }
    public int GetValue() => 0;
  }
}