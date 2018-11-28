using System;

namespace YahtzeeApp.view
{
  public interface MainView
  {
    void DisplayWelcomeMessage();
    string GetUsername();
    int SelectDice();
  }
}