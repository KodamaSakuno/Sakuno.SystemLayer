using System;

namespace Sakuno.SystemLayer.Dialogs
{
    public class TaskDialogCommandLink : TaskDialogButton
    {
        public TaskDialogCommandLink(string text) : base(text) { }
        public TaskDialogCommandLink(string text, string instruction) : base(text + Environment.NewLine + instruction) { }

        public TaskDialogCommandLink(int id, string text) : base(id, text) { }
        public TaskDialogCommandLink(int id, string text, string instruction) : base(id, text + Environment.NewLine + instruction) { }

        public TaskDialogCommandLink(TaskDialogCommonButton id, string text) : base(id, text) { }
        public TaskDialogCommandLink(TaskDialogCommonButton id, string text, string instruction) : this((int)id, text, instruction) { }
    }
}
