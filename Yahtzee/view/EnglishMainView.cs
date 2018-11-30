using System;
using System.Linq;

namespace YahtzeeApp.view
{
  public class EnglishMainView : MainView
  {
    internal string welcomeMsg = "Welcome to Yahtzee";
    internal string enterUsername = "Enter username: ";
    private DiceView diceView;

    public EnglishMainView(DiceView diceView)
    {
      this.diceView = diceView;
    }
    public void DisplayWelcomeMessage()
    {
      Console.WriteLine(welcomeMsg);
    }

    public string GetUsername()
    {
      Console.WriteLine(enterUsername);
      return Console.ReadLine();
    }

    public int SelectDice()
    {
      int number;
      do
      {
        Console.WriteLine("Select Dice");
        Console.Write("= ");
      } while (!int.TryParse(Console.ReadLine(), out number) || (number < 1 || number > 5));
      return number;
    }

    public void PrintDice()
    {
      diceView.Print();
    }
  }
}