using System;
using System.Runtime.CompilerServices;

namespace Yahtzee.model
{
  public class Die
  {
    private Random _random;
    private int _value;

    public Die()
    {
      _random = new Random();
      Throw();
    }

    public int GetValue() => _value;

    public void Throw() => _value = _random.Next(1, 7);
  }
}