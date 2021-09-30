﻿using System;

namespace Application.Common.Interfaces
{
    public interface IDateTime
    {
        DateTime Now { get; }
        DateTime OffsetFromUnixTimeSeconds(long seconds);
    }
}
