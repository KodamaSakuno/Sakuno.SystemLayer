using System;
using System.Runtime.InteropServices;

namespace Sakuno.SystemLayer.Dialogs
{
    public sealed class ProgressDialog : DisposableObject
    {
        NativeInterfaces.IProgressDialog _dialog = (NativeInterfaces.IProgressDialog)new NativeInterfaces.CProgressDialog();

        bool _isShowing;

        IntPtr _ownerWindowHandle;
        public IntPtr OwnerWindowHandle
        {
            get => _ownerWindowHandle;
            set
            {
                if (_ownerWindowHandle != value)
                {
                    ThrowIfDialogShowing();
                    _ownerWindowHandle = value;
                }
            }
        }

        bool _modalWindow;
        public bool ModalWindow
        {
            get => _modalWindow;
            set
            {
                if (_modalWindow != value)
                {
                    ThrowIfDialogShowing();
                    _modalWindow = value;
                }
            }
        }

        string _title;
        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    _dialog.SetTitle(value);
                }
            }
        }

        string _header;
        public string Header
        {
            get => _header;
            set
            {
                if (_header != value)
                {
                    _header = value;
                    _dialog.SetLine(1, value, CompactLongPath);
                }
            }
        }

        string _message;
        public string Message
        {
            get => _message;
            set
            {
                if (_message != value)
                {
                    _message = value;
                    _dialog.SetLine(2, value, CompactLongPath);
                }
            }
        }

        public bool CompactLongPath { get; set; }

        string _cancellingMessage;
        public string CancellingMessage
        {
            get => _cancellingMessage;
            set
            {
                if (_cancellingMessage != value)
                {
                    _cancellingMessage = value;
                    _dialog.SetCancelMsg(value);
                }
            }
        }

        long _total;
        public long Total
        {
            get => _total;
            set
            {
                if (_total != value)
                {
                    _total = value;
                    _dialog.SetProgress64(_progress, value);
                }
            }
        }

        long _progress;
        public long Progress
        {
            get => _progress;
            set
            {
                if (_progress != value)
                {
                    _progress = value;
                    _dialog.SetProgress64(value, _total);
                }
            }
        }

        bool _showRemainingTime;
        public bool ShowRemainingTime
        {
            get => _showRemainingTime;
            set
            {
                if (_showRemainingTime != value)
                {
                    ThrowIfDialogShowing();
                    _showRemainingTime = value;
                }
            }
        }

        bool _noMinimizeButton;
        public bool NoMinimizeButton
        {
            get => _noMinimizeButton;
            set
            {
                if (_noMinimizeButton != value)
                {
                    ThrowIfDialogShowing();
                    _noMinimizeButton = value;
                }
            }
        }

        bool _noProgressBar;
        public bool NoProgressBar
        {
            get => _noProgressBar;
            set
            {
                if (_noProgressBar != value)
                {
                    ThrowIfDialogShowing();
                    _noProgressBar = value;
                }
            }
        }

        bool _marqueeMode = true;
        public bool MarqueeMode
        {
            get => _marqueeMode;
            set
            {
                if (_marqueeMode != value)
                {
                    ThrowIfDialogShowing();
                    _marqueeMode = value;
                }
            }
        }

        bool _disableCancelButton;
        public bool DisableCancelButton
        {
            get => _disableCancelButton;
            set
            {
                if (_disableCancelButton != value)
                {
                    ThrowIfDialogShowing();
                    _disableCancelButton = value;
                }
            }
        }

        public bool HasCancelled => _dialog.HasUserCancelled();

        public void Show()
        {
            var options = NativeEnums.PROGDLG.PROGDLG_NORMAL;

            if (_modalWindow)
                options |= NativeEnums.PROGDLG.PROGDLG_MODAL;

            if (_showRemainingTime)
                options |= NativeEnums.PROGDLG.PROGDLG_AUTOTIME;

            if (_noMinimizeButton)
                options |= NativeEnums.PROGDLG.PROGDLG_NOMINIMIZE;

            if (_noProgressBar)
                options |= NativeEnums.PROGDLG.PROGDLG_NOPROGRESSBAR;

            if (_marqueeMode)
                options |= NativeEnums.PROGDLG.PROGDLG_MARQUEEPROGRESS;

            if (_disableCancelButton)
                options |= NativeEnums.PROGDLG.PROGDLG_NOCANCEL;

            _isShowing = true;

            _dialog.StartProgressDialog(_ownerWindowHandle, null, options);
        }

        public void SetTimer(ProgressDialogTimerAction action) => _dialog.Timer(action);

        public void Close()
        {
            _dialog.StopProgressDialog();

            _isShowing = false;
        }

        protected override void DisposeManagedResources() => Close();
        protected override void DisposeNativeResources() => Marshal.ReleaseComObject(_dialog);

        void ThrowIfDialogShowing()
        {
            if (_isShowing)
                throw new InvalidOperationException("This property cannot be modified when the dialog is showing.");
        }
    }
}
