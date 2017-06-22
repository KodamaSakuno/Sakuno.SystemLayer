using System;

namespace Sakuno.SystemLayer.Dialogs
{
    public class TaskDialogTickEventArgs : EventArgs
    {
        public int Ticks { get; internal set; }

        public bool Reset { get; set; }

        internal TaskDialogTickEventArgs() { }
    }
}
