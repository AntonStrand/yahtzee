using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleToAttribute("FirstTest.cs")]
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

    public int GetValue() => _random.Next(1, 6);

    public void Throw() { }
  }
}