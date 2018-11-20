using System;
using System.Collections.Generic;
using Yahtzee.model;

namespace Yahtzee.view
{
  public class DiceView
  {
    private Dice _dice;
    private List<string> _renderQueue;

    public DiceView(Dice dice)
    {
      if (dice == null)
      {
        throw new ArgumentNullException();
      }

      _dice = dice;
      _renderQueue = new List<string>(4);

      for (int i = 0; i < 4; i++)
      {
        _renderQueue.Add("");
      }
    }

    public void Print()
    {
      var dice = _dice.GetValues();
      // dice.ForEach(DrawDie);
      for (int i = 0; i < 5; i++)
      {
        DrawDie(dice[0]);
      }
      this._renderQueue.ForEach(queue => Console.WriteLine(queue));
    }

    private void DrawDie(int die)
    {
      RenderQueueFirstRow();
      RenderQueueSecondRow(die);
      RenderQueueThirdRow(die);
      RenderQueueFourthRow(die);
    }

    private void RenderQueueFirstRow()
    {
      _renderQueue[0] += " _____   ";
    }

    private void RenderQueueSecondRow(int die)
    {
      if (die == 2 || die == 3)
      {
        _renderQueue[1] += "|o    |  ";
      }
      else if (die == 4 || die == 5 || die == 6)
      {
        _renderQueue[1] += "|o   o|  ";
      }
      else
      {
        _renderQueue[1] += "|     |  ";
      }
    }

    private void RenderQueueThirdRow(int die)
    {
      if (die == 1 || die == 3 || die == 5)
      {
        _renderQueue[2] += "|  o  |  ";
      }
      else if (die == 6)
      {
        _renderQueue[2] += "|o   o|  ";
      }
      else
      {
        _renderQueue[2] += "|     |  ";
      }
    }

    private void RenderQueueFourthRow(int die)
    {
      if (die == 2 || die == 3)
      {
        _renderQueue[3] += "|____o|  ";
      }
      else if (die == 4 || die == 5 || die == 6)
      {
        _renderQueue[3] += "|o___o|  ";
      }
      else
      {
        _renderQueue[3] += "|_____|  ";
      }
    }
  }
}