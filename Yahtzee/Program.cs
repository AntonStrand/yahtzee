using System;
using Yahtzee.controller;
using Yahtzee.view;
using Yahtzee.model;

namespace Yahtzee
{
  class Program
  {
    static void Main(string[] args)
    {
      var v = new EnglishMainView();
      var p = new Player();
      var c = new MainController(v, p);
      c.Play();
    }
  }
}
