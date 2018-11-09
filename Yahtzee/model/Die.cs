using System.Runtime.CompilerServices;

[assembly: InternalsVisibleToAttribute("FirstTest.cs")]
namespace Yahtzee.model
{
  public class Die
  {
    public int GetValue() => 1;

    public void Throw() { }
  }
}