using System;
using System.Runtime.CompilerServices;

namespace Yahtzee.model
{
  public class DieImplemented : Die
  {
    private Random _random;
    private int _value;

    public DieImplemented()
    {
      _random = new Random();
      Throw();
    }

    public int GetValue() => _value;

    public void Throw() => _value = _random.Next(1, 7);
  }
}