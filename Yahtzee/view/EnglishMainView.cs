using System;

namespace Yahtzee.view
{
  public class EnglishMainView : MainView
  {
    internal string welcomeMsg = "Welcome to Yahtzee";
    internal string enterUsername = "Enter username: ";
    public void DisplayWelcomeMessage()
    {
      Console.WriteLine(welcomeMsg);
    }

    public string GetUsername()
    {
      Console.WriteLine(enterUsername);
      return Console.ReadLine();
    }
  }
}