using System;
using Xunit;
using YahtzeeApp.controller;
using YahtzeeApp.view;
using YahtzeeApp.model;
using YahtzeeApp.model.rules;
using Moq;
using System.IO;

namespace YahtzeeTests
{
  public class MainControllerTest
  {
    [Fact]
    public void NewMainController()
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

      Assert.IsType<MainController>(controller);
    }

    [Fact]
    public void WhenRunningStartViewInstructionsIsCalled()
    {
      var mockView = new Mock<MainView>();
      var mockPlayer = new Mock<Player>();
      var mockCategory = new Mock<AvailableCategoriesStrategy>();
      var mockGame = new Mock<Game>(mockCategory.Object);

      var c = new MainController(mockView.Object, mockPlayer.Object, mockGame.Object);
      mockView.Setup(view => view.GetUsername()).Returns("test");

      c.Start();
      mockView.Verify(view => view.DisplayWelcomeMessage(), Times.Once());
    }

    [Fact]
    public void WhenRunningStartViewGetUsernameIsCalled()
    {
      var mockView = new Mock<MainView>();
      var mockPlayer = new Mock<Player>();
      var mockCategory = new Mock<AvailableCategoriesStrategy>();
      var mockGame = new Mock<Game>(mockCategory.Object);

      mockView.Setup(view => view.GetUsername()).Returns("test");
      var c = new MainController(mockView.Object, mockPlayer.Object, mockGame.Object);

      c.Start();
      mockView.Verify(view => view.GetUsername(), Times.Once());
    }

    [Fact]
    public void WhenRunningStartViewUserNameIsSetInPlayer()
    {
      Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));

      var view = new EnglishMainView();
      var player = new Player();
      var mockCategory = new Mock<AvailableCategoriesStrategy>();
      var mockGame = new Mock<Game>(mockCategory.Object);
      var c = new MainController(view, player, mockGame.Object);

      string expected = "Test";
      var input = new StringReader(expected);
      Console.SetIn(input);

      c.Start();

      Assert.Equal(expected, player.name);
      input.Close();
    }

    [Fact]
    public void ThrowDieExist()
    {
      var view = new EnglishMainView();
      var player = new Player();
      var mockCategory = new Mock<AvailableCategoriesStrategy>();
      var mockGame = new Mock<Game>(mockCategory.Object);
      var c = new MainController(view, player, mockGame.Object);

      c.ThrowDie();
    }
  }
}