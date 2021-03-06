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
      _value = dice.GetValues().Where(IsSame(valueType)).Sum();
    }

    public int GetValue() => _value;

    private Func<int, Func<int, bool>> IsSame = valueType => value => value == valueType;
  }
}