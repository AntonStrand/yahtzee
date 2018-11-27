using System;
using System.Collections.Generic;

namespace YahtzeeApp.model.category
{
  public class FirstSection : Category
  {
    public FirstSection(int valueType, Dice dice)
    {
      if (dice == null) throw new ArgumentNullException();
    }

    public int GetValue() => 3;
  }
}