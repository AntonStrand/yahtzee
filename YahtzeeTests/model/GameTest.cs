using System;
using Xunit;
using YahtzeeApp.model;

namespace YahtzeeTests
{
  public class GameTest
  {
    [Fact]
    public void ShouldNotAcceptNullStrategy() => Assert.Throws<ArgumentNullException>(() => new Game(null));
  }
}