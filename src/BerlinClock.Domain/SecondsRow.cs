using System;

namespace BerlinClock.Domain
{
    internal sealed class SecondsRow
        : ClockRow
    {
        private SecondsRow()
            : base(1, 2)
        {
        }

        public static SecondsRow Create()
        {
            return new SecondsRow();
        }

        public override void SetPartOfTime(int minute)
        {
            if (minute < 0 || minute > 59)
            {
                throw new ArgumentOutOfRangeException();
            }

            LampsInternal[0] = minute % TimeUnitInterval == 0;
        }
    }
}