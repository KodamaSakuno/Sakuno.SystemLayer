using System;
using System.Threading;

namespace Sakuno.SystemLayer.Dialogs
{
    public abstract class TaskDialogButtonBase
    {
        static int _idForNextButton = 19;

        internal TaskDialog Owner { get; set; }

        public int Id { get; }
        public string Text { get; }

        bool _default;
        public bool Default
        {
            get => _default;
            set
            {
                if (_default != value)
                {
                    Owner?.ThrowIfDialogShowing();
                    _default = value;
                }
            }
        }

        protected TaskDialogButtonBase(string text)
        {
            Id = Interlocked.Increment(ref _idForNextButton) % 1024 + 19;
            Text = text;
        }
        protected TaskDialogButtonBase(int id, string text)
        {
            Id = id;
            Text = text;
        }
        protected TaskDialogButtonBase(TaskDialogCommonButton id, string text) : this((int)id, text) { }

        public override string ToString() => $"Id = {Id}, Text = {Text}";
    }
}
