using Application.Common.Interfaces;
using System;

namespace Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.UtcNow.AddHours(-5);
        public DateTime OffsetFromUnixTimeSeconds(long seconds) => DateTimeOffset.FromUnixTimeSeconds(seconds).ToLocalTime().DateTime;
    }
}
