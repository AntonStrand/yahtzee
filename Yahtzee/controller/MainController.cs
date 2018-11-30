
using YahtzeeApp.view;
using YahtzeeApp.model;

namespace YahtzeeApp.controller
{
  public class MainController
  {
    private MainView mainView;
    private Player player;
    public MainController(MainView v, Player p, Game g)
    {
      this.mainView = v;
      this.player = p;
    }

    public void Play()
    {
      mainView.DisplayWelcomeMessage();
      string name = mainView.GetUsername();
      player.SetName(name);
    }
  }
}

