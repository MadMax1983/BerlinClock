using System;
using System.Globalization;
using BerlinClock.Domain;

namespace BerlinClock.UI
{
    internal class Program
    {
        private const int HOURS_FIRST_ROW_INTERVAL = 5;
        private const int MINUTES_FIRST_ROW_INTERVAL = 5;

        private static void Main(string[] args)
        {
            var dateTime = DateTime.ParseExact("14:56:39", "HH:mm:ss", CultureInfo.InvariantCulture);

            var clock = Clock.Create(HOURS_FIRST_ROW_INTERVAL, MINUTES_FIRST_ROW_INTERVAL);

            IClockDisplay<string> clockDisplay = new ClockDisplay(clock);

            Console.Write(clockDisplay.Display(dateTime));

            Console.ReadKey();
        }
    }
}