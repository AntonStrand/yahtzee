using System;

namespace Yahtzee.model.category
{
  public class Pair : Category
  {
    private int _value;
    public Pair(int fst, int snd)
    {
      if (!IsMatch(fst, snd)) throw new ArgumentException();
      _value = fst + snd;
    }

    public int GetValue() => _value;

    private bool IsMatch(int fst, int snd) => fst == snd;
  }
}