using System;
using Yahtzee.controller;
using Yahtzee.view;

namespace Yahtzee
{
  class Program
  {
    static void Main(string[] args)
    {
      var v = new MainView();
      var c = new MainController(v);
    }
  }
}
