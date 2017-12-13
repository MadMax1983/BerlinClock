using System;

namespace BerlinClock.Domain
{
    public interface IClock
    {
        IClockRow HoursFirstRow { get; }

        IClockRow HoursSecondRow { get; }

        IClockRow MinutesFirstRow { get; }

        IClockRow MinutesSecondRow { get; }

        IClockRow SecondsRow { get; }

        void GenerateClockState(DateTime dateTime);
    }
}