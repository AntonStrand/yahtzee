using System;
using System.Collections.Generic;
using System.Linq;
using YahtzeeApp.model;

namespace YahtzeeApp.view
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
      _renderQueue = new List<string>(5);

      for (int i = 0; i < 5; i++)
      {
        _renderQueue.Add("");
      }
    }

    public virtual void Print()
    {
      ClearQueue();
      var dice = _dice.GetValues();

      int i = 0;
      dice.ForEach(die => DrawDie(die, ++i));

      this._renderQueue.ForEach(queue => Console.WriteLine(queue));
    }

    private void DrawDie(int die, int index)
    {
      RenderQueueFirstRow();
      RenderQueueSecondRow(die);
      RenderQueueThirdRow(die);
      RenderQueueFourthRow(die);
      RenderQueueFifthRow(index);
    }

    private void ClearQueue() =>
      _renderQueue = _renderQueue
        .Select(q => "")
        .ToList();

    private void RenderQueueFirstRow() =>
      _renderQueue[0] += " _____   ";

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

    private void RenderQueueFifthRow(int index) =>
      _renderQueue[4] += $"  ({index})    ";
  }
}