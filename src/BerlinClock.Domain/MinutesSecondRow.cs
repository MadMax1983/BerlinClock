using System;

namespace BerlinClock.Domain
{
    internal sealed class MinutesSecondRow
        : ClockRow
    {
        private readonly int _rowOneInterval;

        private MinutesSecondRow(int rowOneInterval)
            : base(4, 1)
        {
            _rowOneInterval = rowOneInterval;
        }

        public static MinutesSecondRow Create(int rowOneInterval)
        {
            return new MinutesSecondRow(rowOneInterval);
        }

        public override void SetPartOfTime(int minute)
        {
            if (minute < 0 || minute > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(minute));
            }

            var hoursToSet = minute % _rowOneInterval;

            base.SetPartOfTime(hoursToSet);
        }
    }
}