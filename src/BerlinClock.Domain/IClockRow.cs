using System.Collections.Generic;

namespace BerlinClock.Domain
{
    public interface IClockRow
    {
        IReadOnlyCollection<bool> Lamps { get; }
    }
}