using System;
using System.Collections.Generic;
using Yahtzee.model;

namespace Yahtzee.view
{
  public class DiceView
  {
    private Dice dice;
    private List<string> renderQueue;

    public DiceView(Dice dice)
    {
      if (dice == null)
      {
        throw new ArgumentNullException();
      }
      this.dice = dice;
      this.renderQueue = new List<string>(4);

      for (int i = 0; i < 4; i++)
      {
        this.renderQueue.Add("");
      }
    }

    public void Print()
    {
      var dice = this.dice.GetValues();
      dice.ForEach(die => DrawDie(die));

      this.renderQueue.ForEach(queue => Console.WriteLine(queue));
    }

    private void DrawDie(int die)
    {
      this.renderQueue[0] += "_____  ";
      this.renderQueue[1] += "|     |  ";
      this.renderQueue[2] += "|  o  |  ";
      this.renderQueue[3] += "|_____|  ";
    }
  }
}