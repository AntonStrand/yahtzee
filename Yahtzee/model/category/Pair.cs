using System;

namespace Yahtzee.model.category
{
  public class Pair : Category
  {
    public Pair(int fst, int snd)
    {
      if (fst != snd)
      {
        throw new ArgumentException();
      }
    }

    public int GetValue() => 0;
  }
}