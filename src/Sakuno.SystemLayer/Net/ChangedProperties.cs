using System;

namespace Sakuno.SystemLayer.Net
{
    [Flags]
    public enum ChangedProperties
    {
        Connection = 1,
        Description = 1 << 1,
        Name = 1 << 2,
        Icon = 1 << 3,
        Category = 1 << 4,
    }
}
