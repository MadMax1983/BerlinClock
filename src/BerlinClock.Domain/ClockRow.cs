using System.Collections.Generic;

namespace BerlinClock.Domain
{
    public abstract class ClockRow
        : IClockRow
    {
        protected ClockRow(int noOfLamps, int timeUnitInterval)
        {
            LampsInternal = new bool[noOfLamps];

            TimeUnitInterval = timeUnitInterval;
        }

        public IReadOnlyCollection<bool> Lamps => LampsInternal;

        protected bool[] LampsInternal { get; }

        protected int TimeUnitInterval { get; }

        public virtual void SetPartOfTime(int partOfTime)
        {
            for (var i = LampsInternal.Length - 1; i >= 0; i--)
            {
                LampsInternal[i] = SetLampState(partOfTime, (i + 1) * TimeUnitInterval);
            }
        }

        internal void Clear()
        {
            for (var i = 0; i < LampsInternal.Length; i++)
            {
                LampsInternal[i] = false;
            }
        }

        private static bool SetLampState(int timeUnit, int unitToCompare)
        {
            return timeUnit >= unitToCompare;
        }
    }
}