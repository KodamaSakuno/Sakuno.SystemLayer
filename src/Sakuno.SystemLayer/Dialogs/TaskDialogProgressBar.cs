namespace Sakuno.SystemLayer.Dialogs
{
    public class TaskDialogProgressBar
    {
        internal TaskDialog Owner { get; set; }

        TaskDialogProgressBarState _state;
        public TaskDialogProgressBarState State
        {
            get => _state;
            set
            {
                if (_state != value)
                {
                    if (_state == TaskDialogProgressBarState.Marquee)
                        Owner?.UpdateMarqueeProgressBarDisplay(false);

                    _state = value;

                    if (value != TaskDialogProgressBarState.Marquee)
                        Owner?.UpdateProgressBarState(value);
                    else
                        Owner?.UpdateMarqueeProgressBarDisplay(true);
                }
            }
        }

        public int Minimum { get; set; }
        public int Maximum { get; set; } = 100;

        int _value;
        public int Value
        {
            get => _value;
            set
            {
                if (_value != value)
                {
                    _value = value;
                    Owner?.UpdateProgressBarValue(value);
                }
            }
        }
    }
}
