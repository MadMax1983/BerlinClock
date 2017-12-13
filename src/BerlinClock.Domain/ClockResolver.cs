namespace BerlinClock.Domain
{
    public static class ClockResolver
    {
        private const int HOURS_FIRST_ROW_INTERVAL = 5;
        private const int MINUTES_FIRST_ROW_INTERVAL = 5;

        public static IClock Resolve()
        {
            return Clock.Create(HOURS_FIRST_ROW_INTERVAL, MINUTES_FIRST_ROW_INTERVAL);
        }
    }
}