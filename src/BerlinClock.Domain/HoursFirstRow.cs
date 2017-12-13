namespace BerlinClock.Domain
{
    internal sealed class HoursFirstRow
        : HoursRow
    {
        private HoursFirstRow()
        {
        }

        public override void SetPartOfTime(int hours)
        {
            var noOfLampsToTurnOn = (hours - (hours % TimeUnitInterval)) / TimeUnitInterval;

            SwitchLampsState(noOfLampsToTurnOn);
        }

        public static HoursFirstRow Create()
        {
            return new HoursFirstRow();
        }
    }
}