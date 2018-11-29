using System;

namespace YahtzeeApp.model
{
  public class Player
  {
    internal string name;
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