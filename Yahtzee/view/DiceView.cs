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
      dice.ForEach(DrawDie);

      this.renderQueue.ForEach(queue => Console.WriteLine(queue));
    }

    private void DrawDie(int die)
    {
      this.renderQueue[0] += " _____   ";

      if (die == 2 || die == 3)
      {
        this.renderQueue[1] += "|o    |  ";
      }
      else if (die == 4 || die == 5 || die == 6)
      {
        this.renderQueue[1] += "|o   o|  ";
      }
      else
      {
        this.renderQueue[1] += "|     |  ";
      }

      if (die == 1 || die == 3 || die == 5)
      {
        this.renderQueue[2] += "|  o  |  ";
      }
      else if (die == 6)
      {
        this.renderQueue[2] += "|o   o|  ";
      }
      else
      {
        this.renderQueue[2] += "|     |  ";
      }

      if (die == 2 || die == 3)
      {
        this.renderQueue[3] += "|____o|  ";
      }
      else if (die == 4 || die == 5 || die == 6)
      {
        this.renderQueue[3] += "|o___o|  ";
      }
      else
      {
        this.renderQueue[3] += "|_____|  ";

      }
    }
  }
}