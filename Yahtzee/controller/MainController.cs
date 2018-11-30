
using YahtzeeApp.view;
using YahtzeeApp.model;

namespace YahtzeeApp.controller
{
  public class MainController
  {
    private MainView mainView;
    private Player player;
    private Game game;
    public MainController(MainView v, Player p, Game g)
    {
      this.mainView = v;
      this.player = p;
      this.game = g;
    }

    public void Start()
    {
      mainView.DisplayWelcomeMessage();
      string name = mainView.GetUsername();
      player.SetName(name);
    }

    public void ThrowDie()
    {
    }
  }
}

