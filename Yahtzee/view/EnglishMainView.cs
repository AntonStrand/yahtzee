using System;

namespace Yahtzee.view
{
  public class EnglishMainView : MainView
  {
    public string welcomeMsg = "Welcome to Yahtzee";
    public void DisplayWelcomeMessage()
    {
      Console.WriteLine(welcomeMsg);
    }
  }
}