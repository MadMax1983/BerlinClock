namespace BerlinClock.Domain
{
    internal sealed class HoursSecondRow
        : HoursRow
    {
        private HoursSecondRow()
        {
        }

        public override void SetPartOfTime(int hours)
        {
            var noOfLampsToTurnOn = hours % TimeUnitInterval;

            SwitchLampsState(noOfLampsToTurnOn);
        }

        public static HoursSecondRow Create()
        {
            return new HoursSecondRow();
        }
    }
}