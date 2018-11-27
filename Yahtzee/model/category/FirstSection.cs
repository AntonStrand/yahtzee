using System;
using System.Collections.Generic;

namespace YahtzeeApp.model.category
{
  public class FirstSection : Category
  {
    public FirstSection(int valueType, List<int> values)
    {
      throw new ArgumentNullException();
    }

    public int GetValue() => 0;
  }
}