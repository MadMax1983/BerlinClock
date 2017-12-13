using System;
using System.Globalization;
using System.Linq;
using NUnit.Framework;

namespace BerlinClock.Domain.Tests.IntegrationTests
{
    [TestFixture]
    public sealed class ClockTests
    {
        private const int HOUR_FIRST_ROW_INTERVAL = 5;
        private const int MINUTES_FIRST_ROW_INTERVAL = 5;

        [TestCase("13:41:52")]
        [TestCase("14:40:52")]
        [TestCase("17:15:37")]
        [TestCase("00:00:00")]
        [TestCase("00:01:00")]
        [TestCase("23:59:59")]
        [TestCase("23:59:58")]
        public void Given_DateTime_When_GeneratingClockState_Then_GeneratesAppropriateBerlinClockState(string dateTimeString)
        {
            var dateTime = DateTime.ParseExact(dateTimeString, "HH:mm:ss", CultureInfo.InvariantCulture);

            var clock = Clock.Create(HOUR_FIRST_ROW_INTERVAL, MINUTES_FIRST_ROW_INTERVAL);

            Assert.DoesNotThrow(() => clock.GenerateClockState(dateTime));

            var hourRowOne = dateTime.Hour - (dateTime.Hour % HOUR_FIRST_ROW_INTERVAL);
            var hourRowTwo = dateTime.Hour - hourRowOne;

            AssertHoursFirstRow(clock, hourRowOne);
            AssertHoursSecondRow(clock, hourRowTwo);

            var minutesRowOne = dateTime.Minute - (dateTime.Minute % MINUTES_FIRST_ROW_INTERVAL);
            var minutesRowTwo = dateTime.Minute - minutesRowOne;

            AssertMinutesFirstRow(clock, minutesRowOne);
            AssertMinutesSecondRow(clock, minutesRowTwo);

            AssertSeconds(clock, dateTime.Second);
        }

        private static void AssertHoursFirstRow(Clock clock, int hourRowOne)
        {
            var hoursFirtRowArray = clock.HoursFirstRow.Lamps.ToArray();

            for (var i = 0; i < hoursFirtRowArray.Length; i++)
            {
                if (i + 1 <= hourRowOne / HOUR_FIRST_ROW_INTERVAL)
                {
                    Assert.IsTrue(hoursFirtRowArray[i]);
                }
                else
                {
                    Assert.IsFalse(hoursFirtRowArray[i]);
                }
            }
        }

        private static void AssertHoursSecondRow(Clock clock, int hourRowTwo)
        {
            var hoursFirtRowArray = clock.HoursSecondRow.Lamps.ToArray();

            for (var i = 0; i < hoursFirtRowArray.Length; i++)
            {
                if (i + 1 <= hourRowTwo % HOUR_FIRST_ROW_INTERVAL)
                {
                    Assert.IsTrue(hoursFirtRowArray[i]);
                }
                else
                {
                    Assert.IsFalse(hoursFirtRowArray[i]);
                }
            }
        }

        private static void AssertMinutesFirstRow(Clock clock, int minuteRowOne)
        {
            var lampsArray = clock.MinutesFirstRow.Lamps.ToArray();

            for (var i = 0; i < lampsArray.Length; i++)
            {
                if (i + 1 <= (minuteRowOne - (minuteRowOne % MINUTES_FIRST_ROW_INTERVAL)) / MINUTES_FIRST_ROW_INTERVAL)
                {
                    Assert.IsTrue(lampsArray[i]);
                }
                else
                {
                    Assert.IsFalse(lampsArray[i]);
                }
            }
        }

        private static void AssertMinutesSecondRow(Clock clock, int minuteRowTwo)
        {
            var expectedNumberOfTurnedOnLamps = minuteRowTwo % MINUTES_FIRST_ROW_INTERVAL;

            var lampsArray = clock.MinutesSecondRow.Lamps.ToArray();

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

        private static void AssertSeconds(Clock clock, int second)
        {
            var secondsLamp = clock.SecondsRow.Lamps.ToArray()[0];

            var isEven = second % 2 == 0;
            if (isEven)
            {
                Assert.IsTrue(secondsLamp);
            }
            else
            {
                Assert.IsFalse(secondsLamp);
            }
        }
    }
}