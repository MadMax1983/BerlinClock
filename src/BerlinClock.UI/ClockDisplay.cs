using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BerlinClock.Domain;

namespace BerlinClock.UI
{
    internal sealed class ClockDisplay
        : IClockDisplay<string>
    {
        private readonly StringBuilder _stringBuilder = new StringBuilder();

        private readonly Clock _clock;

        public ClockDisplay(Clock clock)
        {
            _clock = clock;
        }

        public string Display(DateTime dateTime)
        {
            _stringBuilder.Clear();

            _clock.GenerateClockState(dateTime);

            DisplayRow(_clock.SecondsRow.Lamps);

            _stringBuilder.AppendLine();

            DisplayRow(_clock.HoursFirstRow.Lamps);
            DisplayRow(_clock.HoursSecondRow.Lamps);

            _stringBuilder.AppendLine();

            DisplayRow(_clock.MinutesFirstRow.Lamps, true);
            DisplayRow(_clock.MinutesSecondRow.Lamps);

            return _stringBuilder.ToString();
        }

        private void DisplayRow(IEnumerable<bool> rowLamps, bool showReds = false)
        {
            var lampsArray = rowLamps.ToArray();

            for (var i = 0; i < lampsArray.Length; i++)
            {
                var onColor = showReds && i > 0 && (i + 1) % 3 == 0
                    ? DisplayColors.R
                    : DisplayColors.Y;

                _stringBuilder.Append(lampsArray[i] ? onColor : DisplayColors.O);
            }

            _stringBuilder.AppendLine();
        }
    }
}