namespace BerlinClock.Domain
{
    internal sealed class MinutesFirstRow
        : ClockRow
    {
        private MinutesFirstRow()
            : base(11, 5)
        {
        }

        // TODO: Gen number of lamps to turn on.
        public override void SetPartOfTime(int minutes)
        {
            var noOfLampsToTurnOn = (minutes - (minutes % TimeUnitInterval)) / TimeUnitInterval;

            SwitchLampsState(noOfLampsToTurnOn);
        }

        public static MinutesFirstRow Create()
        {
            return new MinutesFirstRow();
        }
    }
}