using System;
using System.Collections.Generic;
using System.Linq;

namespace YahtzeeApp.model.category
{
  public class Chance : Category
  {
    private int _value;

    public Chance(List<int> values) => _value = values.Sum();

    public int GetValue() => _value;
  }
}