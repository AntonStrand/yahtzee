using System;
using System.Collections.Generic;
using Xunit;
using YahtzeeApp.model.category;

namespace YahtzeeTests
{
  public class FirstSectionTest
  {
    [Fact]
    public void ShouldNotAcceptNullValues() =>
      Assert.Throws<ArgumentNullException>(() => new FirstSection(1, null));
  }
}
