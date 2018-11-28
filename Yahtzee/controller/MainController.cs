
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
    }

    public void Play()
    {
      this.mainView.DisplayWelcomeMessage();
      string username = this.mainView.GetUsername();
    }
  }
}

