using System;

namespace BerlinClock.UI
{
    public interface IClockDisplay<out TOutputFormat>
        where TOutputFormat : class
    {
        TOutputFormat Display(DateTime dateTime);
    }
}