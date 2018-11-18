using System;

namespace Yahtzee.model.category
{
  public class TwoPair : Category
  {
    private int _value;

    public TwoPair(Pair pair1, Pair pair2)
    {
      if (pair1 == null || pair2 == null) throw new ArgumentNullException();
      _value = pair1.GetValue() + pair2.GetValue();
    }

    public int GetValue() => _value;
  }
}