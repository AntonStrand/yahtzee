using System.Collections.Generic;
using Yahtzee.model.category;

namespace Yahtzee.model
{
  public interface ScoreBoard
  {
    List<Category> GetOccupiedCategories();
  }
}