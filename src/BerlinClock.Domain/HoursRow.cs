namespace BerlinClock.Domain
{
    public abstract class HoursRow
        : ClockRow
    {
        protected HoursRow()
            : base(4, 5)
        {
        }
    }
}