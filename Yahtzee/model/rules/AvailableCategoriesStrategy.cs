using System.Collections.Generic;
using YahtzeeApp.model.category;

namespace YahtzeeApp.model.rules
{
  public interface AvailableCategoriesStrategy
  {
    List<Category> GetCategories(Dice dice, ScoreBoard scoreBoard);
  }
}