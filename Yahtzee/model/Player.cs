using System;
using System.Collections.Generic;
using YahtzeeApp.model.category;

namespace YahtzeeApp.model
{
  public class Player : ScoreBoard
  {
    internal string name;
    public void SetName(string name)
    {
      if (name.Length == 0)
      {
        throw new ArgumentException();
      }
      this.name = name;
    }

    public List<Category> GetOccupiedCategories() => new List<Category>();
  }
}