using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Yahtzee.model;

namespace YahtzeeTests
{
  public class DieTest
  {

    [Fact]
    public void GetValueShouldReturnIntBetween1to6()
    {
      Die sut = new DieImplemented();
      Assert.InRange(sut.GetValue(), 1, 6);
    }

    [Fact]
    public void GetSameValueTwiceIfNotThrown()
    {
      Die sut = new DieImplemented();
      var expected = sut.GetValue();
      var actual = sut.GetValue();
      Assert.Equal(actual, expected);
    }

    [Fact]
    public void ThrowShouldGetNewValue()
    {
      DieImplemented sut = new DieImplemented();
      int startValue = sut.GetValue();
      List<int> values = getListWithDiceValues(1000);

      var actual = values.Count();
      var unchanged = values.Where(val => val == startValue).Count();
      Assert.NotEqual(actual, unchanged);
    }

    [Fact]
    public void CheckSoRandomWork()
    {
      int count = 100000;
      var dice = getListWithDiceValues(count);

      var actual = (float)dice.Where(val => val == 6).Count() / count;

      Assert.InRange(actual, 0.12, 0.25);
    }

    [Fact]
    public void CountNumberOfDieImplementedSides()
    {
      int count = 1000;
      var dice = getListWithDiceValues(count);

      var actual = dice.Distinct().ToList().Count();
      Assert.Equal(6, actual);
    }

    private List<int> getListWithDiceValues(int count)
    {
      var sut = new DieImplemented();
      var values = new List<int>();

      for (int i = 0; i < count; i++)
      {
        sut.Throw();
        values.Add(sut.GetValue());
      }

      return values;
    }
  }
}
