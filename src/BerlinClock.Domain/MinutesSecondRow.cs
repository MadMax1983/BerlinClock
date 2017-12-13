namespace BerlinClock.Domain
{
    internal sealed class MinutesSecondRow
        : ClockRow
    {
        private MinutesSecondRow()
            : base(4, 1)
        {
        }

        public override void SetPartOfTime(int minutes)
        {
            var noOfLampsToTurnOn = minutes % TimeUnitInterval;

            SwitchLampsState(noOfLampsToTurnOn);
        }

        public static MinutesSecondRow Create()
        {
            return new MinutesSecondRow();
        }
    }
}