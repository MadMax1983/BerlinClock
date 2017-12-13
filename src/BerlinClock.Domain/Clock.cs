using System;

namespace BerlinClock.Domain
{
    public sealed class Clock
    {
        private readonly HoursFirstRow _hoursFirstRow = Domain.HoursFirstRow.Create();
        private readonly HoursSecondRow _hoursSecondRow = Domain.HoursSecondRow.Create();

        private readonly MinutesFirstRow _minutesFirstRow = Domain.MinutesFirstRow.Create();
        private readonly MinutesSecondRow _minutesSecondRow = Domain.MinutesSecondRow.Create();

        private readonly SecondsRow _secondsRow = Domain.SecondsRow.Create();

        private Clock()
        {
        }

        public IClockRow HoursFirstRow => _hoursFirstRow;

        public IClockRow HoursSecondRow => _hoursSecondRow;

        public IClockRow MinutesFirstRow => _minutesFirstRow;

        public IClockRow MinutesSecondRow => _minutesSecondRow;

        public IClockRow SecondsRow => _secondsRow;

        public void GenerateClockState(DateTime dateTime)
        {
            _hoursFirstRow.SetPartOfTime(dateTime.Hour);
            _hoursSecondRow.SetPartOfTime(dateTime.Hour);

            _minutesFirstRow.SetPartOfTime(dateTime.Minute);
            _minutesSecondRow.SetPartOfTime(dateTime.Minute);

            _secondsRow.SetPartOfTime(dateTime.Second);
        }

        public void Clear()
        {
            _hoursFirstRow.Clear();
            _hoursSecondRow.Clear();

            _minutesFirstRow.Clear();
            _minutesSecondRow.Clear();

            _secondsRow.Clear();
        }

        public static Clock Create()
        {
            return new Clock();
        }
    }
}