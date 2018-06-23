using System;

namespace LuckySpin.Enums
{
    [Flags]
    public enum CustomerStatus
    {
        Unknown = 0,
        Activated = 1,
        Suspended = 2
    }
}