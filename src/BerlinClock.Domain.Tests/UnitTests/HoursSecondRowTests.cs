using System;
using System.Linq;
using NUnit.Framework;

namespace BerlinClock.Domain.Tests.UnitTests
{
    [TestFixture]
    public sealed class HoursSecondRowTests
    {
        private const int FIRST_ROW_TIME_UNIT_INTERVAL = 5;

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Given_Hour_When_SwitchingHourLampsState_Then_TurnsAppropriateLampsOn(int hour)
        {
            var hoursSecondRow = HoursSecondRow.Create(FIRST_ROW_TIME_UNIT_INTERVAL);

            hoursSecondRow.SetPartOfTime(hour);

            var expectedNumberOfTurnedOnLamps = hour % FIRST_ROW_TIME_UNIT_INTERVAL;

            var lampsArray = hoursSecondRow.Lamps.ToArray();

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
        [TestCase(5)]
        public void Given_InvalidHour_When_SwitchingHourLampsState_Then_ThrowsArgumentOutOfRangeException(int hour)
        {
            var hoursSecondRow = HoursSecondRow.Create(FIRST_ROW_TIME_UNIT_INTERVAL);

            Assert.Throws<ArgumentOutOfRangeException>(() => hoursSecondRow.SetPartOfTime(hour));
        }
    }
}