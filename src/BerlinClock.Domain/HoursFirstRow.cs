using System;

namespace BerlinClock.Domain
{
    internal sealed class HoursFirstRow
        : ClockRow
    {
        private HoursFirstRow()
            : base(4, 5)
        {
        }

        public static HoursFirstRow Create()
        {
            return new HoursFirstRow();
        }

        public override void SetPartOfTime(int hour)
        {
            if (hour < 0 || hour > 20)
            {
                throw new ArgumentOutOfRangeException(nameof(hour));
            }

            var hoursToSet = hour - (hour % TimeUnitInterval);

            base.SetPartOfTime(hoursToSet);
        }
    }
}