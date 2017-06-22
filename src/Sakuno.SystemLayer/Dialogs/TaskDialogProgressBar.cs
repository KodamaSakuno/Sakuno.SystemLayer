using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    _state = value;
                    Owner?.UpdateProgressBarState(value);
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
