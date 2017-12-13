using System;
using System.Linq;
using NUnit.Framework;

namespace BerlinClock.Domain.Tests.UnitTests
{
    [TestFixture]
    public sealed class SecondsRowTests
    {
        [TestCase(0)]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(10)]
        [TestCase(58)]
        public void Given_EvenSecond_When_SwitchingSecondsLampState_Then_TurnsLampOn(int second)
        {
            var secondsRow = SecondsRow.Create();

            secondsRow.SetPartOfTime(second);

            Assert.IsTrue(secondsRow.Lamps.First());
        }

        [TestCase(1)]
        [TestCase(3)]
        [TestCase(5)]
        [TestCase(11)]
        [TestCase(59)]
        public void Given_OddSecond_When_SwitchingSecondsLampState_Then_TurnsLampOn(int second)
        {
            var secondsRow = SecondsRow.Create();

            secondsRow.SetPartOfTime(second);

            Assert.IsFalse(secondsRow.Lamps.First());
        }

        [TestCase(-1)]
        [TestCase(60)]
        public void Given_InvalidHour_When_SwitchingHourLampsState_Then_ThrowsArgumentOutOfRangeException(int second)
        {
            var secondsRow = SecondsRow.Create();

            Assert.Throws<ArgumentOutOfRangeException>(() => secondsRow.SetPartOfTime(second));
        }
    }
}