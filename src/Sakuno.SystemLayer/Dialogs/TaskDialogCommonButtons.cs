using System;

namespace Sakuno.SystemLayer.Dialogs
{
    [Flags]
    public enum TaskDialogCommonButtons
    {
        None,
        OK = 1,
        Yes = 1 << 1,
        No = 1 << 2,
        Cancel = 1 << 3,
        Retry = 1 << 4,
        Close = 1 << 5,
    }
}
