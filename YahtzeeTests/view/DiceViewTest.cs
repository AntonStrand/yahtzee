using System;
using System.IO;
using Xunit;
using Yahtzee.view;

namespace YahtzeeTests
{
  public class DiceViewTest
  {
    [Fact]
    public void ShouldNotAcceptNull() =>
      Assert.Throws<ArgumentNullException>(() => new DiceView(null));
  }
}