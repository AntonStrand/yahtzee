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
      var player = new Player();

      var category = new AllAvailableCategoriesStrategy();

      var die1 = new DieImplemented();
      var die2 = new DieImplemented();
      var die3 = new DieImplemented();
      var die4 = new DieImplemented();
      var die5 = new DieImplemented();
      var dice = new DiceImplemented(die1, die2, die3, die4, die5);

      var diceView = new DiceView(dice);
      var view = new EnglishMainView(diceView);
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
      var mockView = new Mock<MainView>();
      var player = new Player();
      var mockCategory = new Mock<AvailableCategoriesStrategy>();
      var mockGame = new Mock<Game>(mockCategory.Object);
      var c = new MainController(mockView.Object, player, mockGame.Object);

      string expected = "Test";
      mockView.Setup(v => v.GetUsername()).Returns(expected);
      c.Start();

      Assert.Equal(expected, player.GetName());
    }

    [Fact]
    public void WhenRunningThrowDieSelectDiceIsCalled()
    {
      var mockView = new Mock<MainView>();
      var player = new Player();
      var mockCategory = new Mock<AvailableCategoriesStrategy>();
      var mockGame = new Mock<Game>(mockCategory.Object);
      var c = new MainController(mockView.Object, player, mockGame.Object);

      mockView.Setup(v => v.SelectDice()).Returns(3);
      c.ThrowDie();
      mockView.Verify(v => v.SelectDice(), Times.AtLeastOnce());
    }

    [Fact]
    public void WhenRunningThrowDiePrintDiceIsCalled()
    {
      var mockView = new Mock<MainView>();
      var player = new Player();
      var mockCategory = new Mock<AvailableCategoriesStrategy>();
      var mockGame = new Mock<Game>(mockCategory.Object);
      var c = new MainController(mockView.Object, player, mockGame.Object);

      c.ThrowDie();
      mockView.Verify(v => v.PrintDice(), Times.AtLeastOnce());
    }
  }
}