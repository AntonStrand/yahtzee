using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Yahtzee;
using Yahtzee.model;

namespace MyFirstUnitTests
{
    public class DieTest
    {

        [Fact]
        public void GetValueShouldReturnIntBetween1to6()
        {
            Die sut = new Die();
            Assert.InRange(sut.GetValue(), 1, 6);
        }

        [Fact]
        public void GetSameValueTwiceIfNotThrown()
        {
            Die sut = new Die();
            var expected = sut.GetValue();
            var actual = sut.GetValue();
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void ThrowShouldGetNewValue()
        {
            Die sut = new Die();
            int startValue = sut.GetValue();
            List<int> actuals = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                sut.Throw();
                actuals.Add(sut.GetValue());
            }
            var actual = actuals.Count();
            var unchanged = actuals.Where(val => val == startValue).Count();
            Assert.NotEqual(actual, unchanged);
        }

        [Fact]
        public void CheckSoRandomWork()
        {
            float count = 100000;
            var sut = new Die();
            var dice = new List<int>();

            for (int i = 0; i < count; i++)
            {
                sut.Throw();
                dice.Add(sut.GetValue());
            }

            var actual = dice.Where(val => val == 6).Count() / count;

            Assert.InRange(actual, 0.12, 0.25);
        }
    }
}
