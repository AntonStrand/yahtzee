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

    public int GetResult() => _occupied.Count == 0 ? 0
                            : _occupied.Count == 3 ? 45
                            : _occupied.Count == 4 ? 39
                            : 10;

    public void AddCategory(Category category)
    {
      if (IsTaken(category)) throw new ArgumentException();
      _occupied.Add(category);
    }

    private bool IsTaken(Category category) => _occupied.Any(taken => taken.GetType() == category.GetType());
  }
}