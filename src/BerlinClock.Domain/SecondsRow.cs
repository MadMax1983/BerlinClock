namespace BerlinClock.Domain
{
    internal sealed class SecondsRow
        : ClockRow
    {
        private SecondsRow()
            : base(1, 2)
        {
        }

        public override void SetPartOfTime(int seconds)
        {
            var noOfLampsToTurnOn = seconds % TimeUnitInterval;

            SwitchLampsState(noOfLampsToTurnOn);
        }

        public static SecondsRow Create()
        {
            return new SecondsRow();
        }
    }
}