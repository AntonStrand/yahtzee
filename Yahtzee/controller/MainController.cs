
using Yahtzee.view;

namespace Yahtzee.controller
{
  public class MainController
  {
    private MainView mainView;
    public MainController(MainView v)
    {
      this.mainView = v;
    }

    public void Play()
    {
      this.mainView.DisplayWelcomeMessage();
    }
  }
}

