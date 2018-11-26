using System;
using YahtzeeApp.controller;
using YahtzeeApp.view;
using YahtzeeApp.model;
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("YahtzeeTests")]

namespace YahtzeeApp
{
  class Program
  {
    static void Main(string[] args)
    {
      var v = new EnglishMainView();
      var p = new Player();
      var c = new MainController(v, p);
      c.Play();

      var die = new DieImplemented();
      die.Throw();
      var dice = new DiceImplemented(die, die, die, die, die);
      var diceView = new DiceView(dice);
      diceView.Print();
    }
  }
}
