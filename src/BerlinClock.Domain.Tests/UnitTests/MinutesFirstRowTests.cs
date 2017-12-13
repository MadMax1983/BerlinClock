using System;
using System.Linq;
using NUnit.Framework;

namespace BerlinClock.Domain.Tests.UnitTests
{
    [TestFixture]
    public sealed class MinutesFirstRowTests
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
        [TestCase(55)]
        public void Given_Hour_When_SwitchingHourLampsState_Then_TurnsAppropriateLampsOn(int minute)
        {
            var minutesFirstRow = MinutesFirstRow.Create();

            minutesFirstRow.SetPartOfTime(minute);

            var expectedNumberOfTurnedOnLamps = (minute - (minute % TIME_UNIT_INTERVAL)) / TIME_UNIT_INTERVAL;

            var lampsArray = minutesFirstRow.Lamps.ToArray();

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
        [TestCase(56)]
        public void Given_InvalidHour_When_SwitchingHourLampsState_Then_ThrowsArgumentOutOfRangeException(int minute)
        {
            var minutesFirstRow = MinutesFirstRow.Create();

            Assert.Throws<ArgumentOutOfRangeException>(() => minutesFirstRow.SetPartOfTime(minute));
        }
    }
}