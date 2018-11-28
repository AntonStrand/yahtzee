
using YahtzeeApp.view;
using YahtzeeApp.model;

namespace YahtzeeApp.controller
{
  public class MainController
  {
    private MainView mainView;
    private Player player;
    public MainController(MainView v, Player p)
    {
      this.mainView = v;
      this.player = p;
    }

    public void Play()
    {
      this.mainView.DisplayWelcomeMessage();
      player.SetName(mainView.GetUsername());
    }
  }
}

