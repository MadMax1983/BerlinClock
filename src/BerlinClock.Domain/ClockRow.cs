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

        internal void Clear()
        {
            for (var i = 0; i < LampsInternal.Length; i++)
            {
                LampsInternal[i] = false;
            }
        }

        public abstract void SetPartOfTime(int hours);

        protected virtual void SwitchLampsState(int noOfLightedOnLamps)
        {
            for (var i = 0; i < noOfLightedOnLamps; i++)
            {
                LampsInternal[i] = true;
            }
        }
    }
}