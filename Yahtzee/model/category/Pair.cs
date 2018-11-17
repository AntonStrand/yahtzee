using System;

namespace Yahtzee.model.category
{
  public class Pair : Category
  {
    public Pair(int fst, int snd)
    {
      if (!IsMatch(fst, snd)) throw new ArgumentException();
    }

    public int GetValue() => 0;

    private bool IsMatch(int fst, int snd) => fst == snd;
  }
}