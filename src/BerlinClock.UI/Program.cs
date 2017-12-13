using System;
using System.Globalization;
using BerlinClock.Domain;

namespace BerlinClock.UI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var dateTime = DateTime.ParseExact(args[0], "HH:mm:ss", CultureInfo.InvariantCulture);

            var clock = ClockResolver.Resolve();

            IClockDisplay<string> clockDisplay = new ClockDisplay(clock);

            Console.Write(clockDisplay.Display(dateTime));

            Console.ReadKey();
        }
    }
}