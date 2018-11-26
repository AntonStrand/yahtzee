using System.Collections.Generic;
using YahtzeeApp.model.category;

namespace YahtzeeApp.model
{
  public interface ScoreBoard
  {
    List<Category> GetOccupiedCategories();
  }
}