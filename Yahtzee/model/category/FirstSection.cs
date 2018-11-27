using System;
using System.Collections.Generic;
using System.Linq;

namespace YahtzeeApp.model.category
{
  public class FirstSection : Category
  {
    private int _value;

    public FirstSection(int valueType, Dice dice)
    {
      if (dice == null) throw new ArgumentNullException();
      if (valueType == 1) _value = dice.GetValues().Where(x => x == 1).Sum();
      if (valueType == 2) _value = dice.GetValues().Where(x => x == 2).Sum();
    }

    public int GetValue() => _value;
  }
}