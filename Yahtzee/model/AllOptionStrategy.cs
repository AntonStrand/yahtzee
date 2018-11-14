using System;

namespace Yahtzee.model
{
  public class AllOptionStrategy
  {
    public void GetOptions(Dice dice)
    {
      if (dice == null) throw new ArgumentNullException();
    }
  }
}