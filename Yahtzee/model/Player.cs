using System;

namespace Yahtzee.model
{
  public class Player
  {
    private string name;
    public void SetName(string name)
    {
      if (name.Length == 0)
      {
        throw new ArgumentException();
      }
      this.name = name;
    }
  }
}