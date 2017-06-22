namespace Sakuno.SystemLayer.Dialogs
{
    public class TaskDialogButton : TaskDialogButtonBase
    {
        bool _useElevationIcon;
        public bool UseElevationIcon
        {
            get => _useElevationIcon;
            set
            {
                if (_useElevationIcon != value)
                {
                    Owner?.UpdateElevationIcon(Id, value);
                    _useElevationIcon = value;
                }
            }
        }

        public TaskDialogButton(string text) : base(text) { }
        public TaskDialogButton(int id, string text) : base(id, text) { }
        public TaskDialogButton(TaskDialogCommonButton id, string text) : base(id, text) { }
    }
}
