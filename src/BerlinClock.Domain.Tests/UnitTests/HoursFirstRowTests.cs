using System;
using System.Linq;
using NUnit.Framework;

namespace BerlinClock.Domain.Tests.UnitTests
{
    [TestFixture]
    public sealed class HoursFirstRowTests
    {
        private const int TIME_UNIT_INTERVAL = 5;

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(10)]
        [TestCase(15)]
        [TestCase(17)]
        [TestCase(20)]
        public void Given_Hour_When_SwitchingHourLampsState_Then_TurnsAppropriateLampsOn(int hour)
        {
            var hoursFirstRow = HoursFirstRow.Create();

            hoursFirstRow.SetPartOfTime(hour);

            var expectedNumberOfTurnedOnLamps = (hour - (hour % TIME_UNIT_INTERVAL)) / TIME_UNIT_INTERVAL;

            var lampsArray = hoursFirstRow.Lamps.ToArray();

            for (var i = 0; i < lampsArray.Length; i++)
            {
                if (i + 1 <= expectedNumberOfTurnedOnLamps)
                {
                    Assert.IsTrue(lampsArray[i]);
                }
                else
                {
                    Assert.IsFalse(lampsArray[i]);
                }
            }
        }

        [TestCase(-1)]
        [TestCase(24)]
        public void Given_InvalidHour_When_SwitchingHourLampsState_Then_ThrowsArgumentOutOfRangeException(int hour)
        {
            var hoursFirstRow = HoursFirstRow.Create();

            Assert.Throws<ArgumentOutOfRangeException>(() => hoursFirstRow.SetPartOfTime(hour));
        }
    }
}