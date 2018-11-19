using System;
using Yahtzee.model;

namespace Yahtzee.view
{
  public class DiceView
  {
    private Dice dice;
    public DiceView(Dice dice)
    {
      if (dice == null)
      {
        throw new ArgumentNullException();
      }
      this.dice = dice;
    }

    public void Print()
    {
      Console.WriteLine("Not Implemented yet.");
    }
  }
}