using System;

namespace BerlinClock.Domain
{
    internal sealed class MinutesFirstRow
        : ClockRow
    {
        private MinutesFirstRow()
            : base(11, 5)
        {
        }

        public static MinutesFirstRow Create()
        {
            return new MinutesFirstRow();
        }

        public override void SetPartOfTime(int minute)
        {
            if (minute < 0 || minute > 55)
            {
                throw new ArgumentOutOfRangeException(nameof(minute));
            }

            var minutesToSet = minute - (minute % TimeUnitInterval);

            base.SetPartOfTime(minutesToSet);
        }
    }
}