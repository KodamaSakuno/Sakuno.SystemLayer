namespace Sakuno.SystemLayer.Dialogs
{
    public class TaskDialogRadioButton : TaskDialogButtonBase
    {
        public TaskDialogRadioButton(string text) : base(text) { }
        public TaskDialogRadioButton(int id, string text) : base(id, text) { }
        public TaskDialogRadioButton(TaskDialogCommonButton id, string text) : base(id, text) { }
    }
}
