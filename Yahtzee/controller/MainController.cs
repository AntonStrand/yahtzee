
using Yahtzee.view;
using Yahtzee.model;

namespace Yahtzee.controller
{
  public class MainController
  {
    private MainView mainView;
    private Player player;
    public MainController(MainView v, Player p)
    {
      this.mainView = v;
    }

    public void Play()
    {
      this.mainView.DisplayWelcomeMessage();
    }
  }
}

