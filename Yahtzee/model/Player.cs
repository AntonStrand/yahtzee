using System;
using System.Collections.Generic;
using System.Linq;
using YahtzeeApp.model.category;

namespace YahtzeeApp.model
{
  public class Player : ScoreBoard
  {
    internal string name;

    private List<Category> _occupied;

    public Player() => _occupied = new List<Category>();

    public void SetName(string name)
    {
      if (name.Length == 0)
      {
        throw new ArgumentException();
      }
      this.name = name;
    }

    public List<Category> GetOccupiedCategories() => _occupied;

    public void AddCategory(Category category)
    {
      if (_occupied.Any(taken => taken.GetType() == category.GetType())) throw new ArgumentException();
      _occupied.Add(category);
    }
  }
}