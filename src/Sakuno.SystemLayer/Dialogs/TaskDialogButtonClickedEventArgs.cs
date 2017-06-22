using System.ComponentModel;

namespace Sakuno.SystemLayer.Dialogs
{
    public class TaskDialogButtonClickedEventArgs : CancelEventArgs
    {
        public TaskDialogButton Button { get; }

        internal TaskDialogButtonClickedEventArgs(TaskDialogButton button)
        {
            Button = button;
        }
    }
}
