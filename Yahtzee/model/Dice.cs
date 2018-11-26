using System;
using System.Collections.Generic;
using System.Linq;

namespace YahtzeeApp.model
{
  public interface Dice
  {
    void Throw();

    void KeepDie(DiceList index);

    List<int> GetValues();
  }
}