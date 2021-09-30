using Application.Common.Interfaces;
using System;

namespace Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
        public DateTime OffsetFromUnixTimeSeconds(long seconds) => DateTimeOffset.FromUnixTimeSeconds(seconds).ToLocalTime().DateTime;
    }
}
