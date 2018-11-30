using System;
using YahtzeeApp.controller;
using YahtzeeApp.view;
using YahtzeeApp.model;
using YahtzeeApp.model.rules;
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("YahtzeeTests")]

namespace YahtzeeApp
{
  class Program
  {
    static void Main(string[] args)
    {
      var player = new Player();

      var game = new Game(new AllAvailableCategoriesStrategy());
      var diceView = new DiceView(game.GetDice());
      var view = new EnglishMainView(diceView);
      var controller = new MainController(view, player, game);

      controller.Start();
    }
  }
}
