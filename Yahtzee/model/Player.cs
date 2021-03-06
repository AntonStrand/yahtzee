using System;
using System.Collections.Generic;
using System.Linq;
using YahtzeeApp.model.category;

namespace YahtzeeApp.model
{
  public class Player : ScoreBoard
  {
    private string _name;

    private List<Category> _occupied;

    public Player() => _occupied = new List<Category>();

    public void AddCategory(Category category)
    {
      if (IsTaken(category)) throw new ArgumentException();
      _occupied.Add(category);
    }

    public List<Category> GetOccupiedCategories() => _occupied;

    public int GetResult() => _occupied.Select(GetValue).Sum();

    public string GetName() => _name;

    public void SetName(string name) =>
      _name = IsValidName(name) ? name : throw new ArgumentException();

    private bool IsValidName(string name) => (name != null && name.Length > 0);

    private bool IsTaken(Category category) =>
      _occupied.Any(taken => taken.GetType() == category.GetType());

    private int GetValue(Category category) => category.GetValue();
  }
}