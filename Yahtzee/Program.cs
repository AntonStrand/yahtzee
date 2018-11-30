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
      var view = new EnglishMainView();
      var player = new Player();

      var category = new AllAvailableCategoriesStrategy();

      var die1 = new DieImplemented();
      var die2 = new DieImplemented();
      var die3 = new DieImplemented();
      var die4 = new DieImplemented();
      var die5 = new DieImplemented();

      var dice = new DiceImplemented(die1, die2, die3, die4, die5);
      var game = new Game(category, dice);
      var controller = new MainController(view, player, game);

      controller.Start();
    }
  }
}
