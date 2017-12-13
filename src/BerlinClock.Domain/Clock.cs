using System;

namespace BerlinClock.Domain
{
    public sealed class Clock
    {
        private readonly int _hoursFirstRowInterval;
        private readonly int _minutesFirstRowInterval;

        private readonly HoursFirstRow _hoursFirstRow;
        private readonly HoursSecondRow _hoursSecondRow;

        private readonly MinutesFirstRow _minutesFirstRow;
        private readonly MinutesSecondRow _minutesSecondRow;

        private readonly SecondsRow _secondsRow;

        private Clock(int hoursFirstRowInterval, int minutesFirstRowInterval)
        {
            _hoursFirstRowInterval = hoursFirstRowInterval;
            _minutesFirstRowInterval = minutesFirstRowInterval;

            _hoursFirstRow = Domain.HoursFirstRow.Create();
            _hoursSecondRow = Domain.HoursSecondRow.Create(hoursFirstRowInterval);

            _minutesFirstRow = Domain.MinutesFirstRow.Create();
            _minutesSecondRow = Domain.MinutesSecondRow.Create(minutesFirstRowInterval);

            _secondsRow = Domain.SecondsRow.Create();
        }

        public IClockRow HoursFirstRow => _hoursFirstRow;

        public IClockRow HoursSecondRow => _hoursSecondRow;

        public IClockRow MinutesFirstRow => _minutesFirstRow;

        public IClockRow MinutesSecondRow => _minutesSecondRow;

        public IClockRow SecondsRow => _secondsRow;

        public static Clock Create(int hoursFirstRowInterval, int minutesFirstRowInterval)
        {
            return new Clock(hoursFirstRowInterval, minutesFirstRowInterval);
        }

        public void GenerateClockState(DateTime dateTime)
        {
            var hour = dateTime.Hour;
            var minute = dateTime.Minute;
            var second = dateTime.Second;

            var lampsForHoursFirstRow = hour - (hour % _hoursFirstRowInterval);
            var lampsForHoursSecondRow = hour - lampsForHoursFirstRow;

            var lampsForMinutesFirstRow = minute - (minute % _minutesFirstRowInterval);
            var lampsForMinutesSecondRow = minute - lampsForMinutesFirstRow;

            _hoursFirstRow.SetPartOfTime(lampsForHoursFirstRow);
            _hoursSecondRow.SetPartOfTime(lampsForHoursSecondRow);

            _minutesFirstRow.SetPartOfTime(lampsForMinutesFirstRow);
            _minutesSecondRow.SetPartOfTime(lampsForMinutesSecondRow);

            _secondsRow.SetPartOfTime(second);
        }

        public void Clear()
        {
            _hoursFirstRow.Clear();
            _hoursSecondRow.Clear();

            _minutesFirstRow.Clear();
            _minutesSecondRow.Clear();

            _secondsRow.Clear();
        }
    }
}