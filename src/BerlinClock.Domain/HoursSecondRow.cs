using System;

namespace BerlinClock.Domain
{
    internal sealed class HoursSecondRow
        : ClockRow
    {
        private readonly int _rowOneInterval;

        private HoursSecondRow(int rowOneInterval)
            : base(4, 1)
        {
            _rowOneInterval = rowOneInterval;
        }

        public static HoursSecondRow Create(int rowOneInterval)
        {
            return new HoursSecondRow(rowOneInterval);
        }

        public override void SetPartOfTime(int hour)
        {
            if (hour < 0 || hour > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(hour));
            }

            var hoursToSet = hour % _rowOneInterval;

            base.SetPartOfTime(hoursToSet);
        }
    }
}