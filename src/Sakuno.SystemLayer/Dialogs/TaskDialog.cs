using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Sakuno.SystemLayer.Dialogs
{
    public class TaskDialog : DisposableObject
    {
        NativeEnums.TASKDIALOG_FLAGS _options;

        IntPtr _handle;

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

        string _caption;
        public string Caption
        {
            get => _caption;
            set
            {
                if (_caption != value)
                {
                    ThrowIfDialogShowing();
                    _caption = value;
                }
            }
        }

        TaskDialogIcon _icon;
        public TaskDialogIcon Icon
        {
            get => _icon;
            set
            {
                if (_icon != value)
                {
                    _icon = value;

                    if (_isShowing)
                        UpdateIcon(value);
                }
            }
        }

        string _instruction;
        public string Instruction
        {
            get => _instruction;
            set
            {
                if (_instruction != value)
                {
                    _instruction = value;

                    if (_isShowing)
                        UpdateInstruction(value);
                }
            }
        }
        string _content;
        public string Content
        {
            get => _content;
            set
            {
                if (_content != value)
                {
                    _content = value;

                    if (_isShowing)
                        UpdateContent(value);
                }
            }
        }

        TaskDialogCommonButtons _commonButtons;
        public TaskDialogCommonButtons CommonButtons
        {
            get => _commonButtons;
            set
            {
                if (_commonButtons != value)
                {
                    ThrowIfDialogShowing();
                    _commonButtons = value;
                }
            }
        }

        TaskDialogCommonButton _defaultCommonButton;
        public TaskDialogCommonButton DefaultCommonButton
        {
            get => _defaultCommonButton;
            set
            {
                if (_defaultCommonButton != value)
                {
                    ThrowIfDialogShowing();
                    _defaultCommonButton = value;
                }
            }
        }

        string _detail;
        public string Detail
        {
            get => _detail;
            set
            {
                if (_detail != value)
                {
                    _detail = value;

                    if (_isShowing)
                        UpdateDetail(value);
                }
            }
        }

        string _detailExpanderText;
        public string DetailExpanderText
        {
            get => _detailExpanderText;
            set
            {
                if (_detailExpanderText != value)
                {
                    ThrowIfDialogShowing();
                    _detailExpanderText = value;
                }
            }
        }
        string _detailCollapserText;
        public string DetailCollapserText
        {
            get => _detailCollapserText;
            set
            {
                if (_detailCollapserText != value)
                {
                    ThrowIfDialogShowing();
                    _detailCollapserText = value;
                }
            }
        }

        string _footerCheckboxText;
        public string FooterCheckboxText
        {
            get => _footerCheckboxText;
            set
            {
                if (_footerCheckboxText != value)
                {
                    ThrowIfDialogShowing();
                    _footerCheckboxText = value;
                }
            }
        }
        bool _isFooterCheckboxChecked;
        public bool IsFooterCheckboxChecked
        {
            get => _isFooterCheckboxChecked;
            set
            {
                if (_isFooterCheckboxChecked != value)
                {
                    _isFooterCheckboxChecked = value;

                    if (_isShowing)
                        UpdateFooterCheckbox(_isFooterCheckboxChecked);
                }
            }
        }

        TaskDialogIcon _footerIcon;
        public TaskDialogIcon FooterIcon
        {
            get => _footerIcon;
            set
            {
                if (_footerIcon != value)
                {
                    _footerIcon = value;

                    if (_isShowing)
                        UpdateFooterIcon(value);
                }
            }
        }

        string _footer;
        public string Footer
        {
            get => _footer;
            set
            {
                if (_footer != value)
                {
                    _footer = value;

                    if (_isShowing)
                        UpdateFooter(value);
                }
            }
        }

        internal TaskDialogButtonCollection<TaskDialogButton> _buttons;
        public ICollection<TaskDialogButton> Buttons =>
            _buttons ?? (_buttons = new TaskDialogButtonCollection<TaskDialogButton>(this));

        TaskDialogButtonStyle _buttonStyle;
        public TaskDialogButtonStyle ButtonStyle
        {
            get => _buttonStyle;
            set
            {
                if (_buttonStyle != value)
                {
                    ThrowIfDialogShowing();
                    _buttonStyle = value;
                }
            }
        }

        internal TaskDialogButtonCollection<TaskDialogRadioButton> _radioButtons;
        public ICollection<TaskDialogRadioButton> RadioButtons =>
            _radioButtons ?? (_radioButtons = new TaskDialogButtonCollection<TaskDialogRadioButton>(this));

        TaskDialogProgressBar _progressBar;
        public TaskDialogProgressBar ProgressBar
        {
            get => _progressBar;
            set
            {
                if (_progressBar != value)
                {
                    ThrowIfDialogShowing();
                    _progressBar = value;
                }
            }
        }

        TaskDialogLocation _location;
        public TaskDialogLocation Location
        {
            get => _location;
            set
            {
                if (_location != value)
                {
                    ThrowIfDialogShowing();
                    _location = value;
                }
            }
        }

        bool _allowCancellation;
        public bool AllowCancellation
        {
            get => _allowCancellation;
            set
            {
                if (_allowCancellation != value)
                {
                    ThrowIfDialogShowing();
                    _allowCancellation = value;
                }
            }
        }

        bool _enableHyperlinks;
        public bool EnableHyperlinks
        {
            get => _enableHyperlinks;
            set
            {
                if (_enableHyperlinks != value)
                {
                    ThrowIfDialogShowing();
                    _enableHyperlinks = value;
                }
            }
        }

        bool _isDetailExpandedByDefault;
        public bool IsDetailExpandedByDefault
        {
            get => _isDetailExpandedByDefault;
            set
            {
                if (_isDetailExpandedByDefault = value)
                {
                    ThrowIfDialogShowing();
                    _isDetailExpandedByDefault = value;
                }
            }
        }

        TaskDialogDetailLoation _detailLocation;
        public TaskDialogDetailLoation DetailLocation
        {
            get => _detailLocation;
            set
            {
                if (_detailLocation != value)
                {
                    ThrowIfDialogShowing();
                    _detailLocation = value;
                }
            }
        }

        int _width;
        public int Width
        {
            get => _width;
            set
            {
                if (_width != value)
                {
                    ThrowIfDialogShowing();
                    _width = value;
                }
            }
        }

        TaskDialogTickEventArgs _tickEventArgs;

        public event EventHandler Opened;
        public event EventHandler<TaskDialogButtonClickedEventArgs> ButtonClicked;
        public event EventHandler<string> HyperlinkClicked;
        public event EventHandler<TaskDialogRadioButton> RadioButtonClicked;
        public event EventHandler<TaskDialogTickEventArgs> Tick;
        public event EventHandler Closed;

        public TaskDialogResult Show()
        {
            _isShowing = true;

            try
            {
                var config = new NativeStructs.TASKDIALOGCONFIG()
                {
                    cbSize = Marshal.SizeOf<NativeStructs.TASKDIALOGCONFIG>(),

                    hwndParent = _ownerWindowHandle,

                    hMainIcon = _icon,
                    hFooterIcon = _footerIcon,

                    pszWindowTitle = _caption,
                    pszMainInstruction = _instruction,
                    pszContent = _content,
                    pszExpandedInformation = _detail,
                    pszCollapsedControlText = _detailExpanderText,
                    pszExpandedControlText = _detailCollapserText,
                    pszVerificationText = _footerCheckboxText,
                    pszFooter = _footer,

                    dwCommonButtons = _commonButtons,

                    cxWidth = _width,

                    dwFlags = _options = GetOptions(),

                    pfCallback = TaskDialogProc,
                };

                if (_buttons != null && _buttons.Count > 0)
                {
                    config.cButtons = _buttons.Count;
                    config.pButtons = _buttons.GetNativeData();
                    config.nDefaultButton = _buttons.GetDefaultButton().Id;
                }

                if (config.nDefaultButton == 0)
                    config.nDefaultButton = (int)_defaultCommonButton;

                if (_radioButtons != null && _radioButtons.Count > 0)
                {
                    config.cRadioButtons = _radioButtons.Count;
                    config.pRadioButtons = _radioButtons.GetNativeData();
                    config.nDefaultRadioButton = _radioButtons.GetDefaultButton().Id;

                    if (config.nDefaultRadioButton == 0)
                        config.dwFlags |= NativeEnums.TASKDIALOG_FLAGS.TDF_NO_DEFAULT_RADIO_BUTTON;
                }

                if (_progressBar != null)
                    _progressBar.Owner = this;

                if (Tick != null && _tickEventArgs == null)
                    _tickEventArgs = new TaskDialogTickEventArgs();

                var result = NativeMethods.ComCtl32.TaskDialogIndirect(ref config, out var selectedButtonId, out var selectedRadioButtonId, out var isFooterCheckBoxChecked);

                if (NativeUtils.Failed(result))
                    throw new Win32Exception(result);

                return new TaskDialogResult(this, selectedButtonId, selectedRadioButtonId, isFooterCheckBoxChecked);
            }
            finally
            {
                _isShowing = false;
            }
        }
        NativeEnums.TASKDIALOG_FLAGS GetOptions()
        {
            var result = NativeEnums.TASKDIALOG_FLAGS.TDF_NONE;

            if (_buttonStyle == TaskDialogButtonStyle.CommandLink)
                result |= NativeEnums.TASKDIALOG_FLAGS.TDF_USE_COMMAND_LINKS;
            else if (_buttonStyle == TaskDialogButtonStyle.CommandLinkWithoutIcon)
                result |= NativeEnums.TASKDIALOG_FLAGS.TDF_USE_COMMAND_LINKS_NO_ICON;

            if (_location == TaskDialogLocation.CenterOfOwner)
                result |= NativeEnums.TASKDIALOG_FLAGS.TDF_POSITION_RELATIVE_TO_WINDOW;

            if (_allowCancellation)
                result |= NativeEnums.TASKDIALOG_FLAGS.TDF_ALLOW_DIALOG_CANCELLATION;

            if (_enableHyperlinks)
                result |= NativeEnums.TASKDIALOG_FLAGS.TDF_ENABLE_HYPERLINKS;

            if (_isDetailExpandedByDefault)
                result |= NativeEnums.TASKDIALOG_FLAGS.TDF_EXPANDED_BY_DEFAULT;

            if (_detailLocation == TaskDialogDetailLoation.BelowFooter)
                result |= NativeEnums.TASKDIALOG_FLAGS.TDF_EXPAND_FOOTER_AREA;

            if (_isFooterCheckboxChecked)
                result |= NativeEnums.TASKDIALOG_FLAGS.TDF_VERIFICATION_FLAG_CHECKED;

            if (_progressBar != null)
                if (_progressBar.State == TaskDialogProgressBarState.Marquee)
                    result |= NativeEnums.TASKDIALOG_FLAGS.TDF_SHOW_MARQUEE_PROGRESS_BAR;
                else
                    result |= NativeEnums.TASKDIALOG_FLAGS.TDF_SHOW_PROGRESS_BAR;

            return result;
        }


        int TaskDialogProc(IntPtr hwnd, NativeConstants.TASKDIALOG_NOTIFICATIONS uNotification, IntPtr wParam, IntPtr lParam, IntPtr dwRefData)
        {
            _handle = hwnd;

            switch (uNotification)
            {
                case NativeConstants.TASKDIALOG_NOTIFICATIONS.CREATED:
                    OnDialogInitialization();
                    Opened?.Invoke(this, EventArgs.Empty);
                    break;

                case NativeConstants.TASKDIALOG_NOTIFICATIONS.BUTTONCLICKED:
                    var currentButtonId = (int)wParam;
                    var currentButton = _buttons?.GetButtonById(currentButtonId);

                    if (currentButton != null)
                    {
                        var args = new TaskDialogButtonClickedEventArgs(currentButton);

                        ButtonClicked?.Invoke(this, args);

                        return args.Cancel ? 1 : 0;
                    }

                    break;

                case NativeConstants.TASKDIALOG_NOTIFICATIONS.HYPERLINKCLICKED:
                    var href = Marshal.PtrToStringUni(lParam);

                    HyperlinkClicked?.Invoke(this, href);
                    break;

                case NativeConstants.TASKDIALOG_NOTIFICATIONS.TIMER:
                    _tickEventArgs.Ticks = (int)wParam;
                    _tickEventArgs.Reset = false;

                    Tick?.Invoke(this, _tickEventArgs);

                    return _tickEventArgs.Reset ? 1 : 0;

                case NativeConstants.TASKDIALOG_NOTIFICATIONS.DESTROYED:
                    Closed?.Invoke(this, EventArgs.Empty);
                    break;

                case NativeConstants.TASKDIALOG_NOTIFICATIONS.RADIOBUTTONCLICKED:
                    var currentRadioButtonId = (int)wParam;
                    var currentRadioButton = _radioButtons?.GetButtonById(currentRadioButtonId);

                    if (currentRadioButton != null)
                        RadioButtonClicked?.Invoke(this, currentRadioButton);
                    break;

                default: return 0;
            }

            return 0;
        }
        void OnDialogInitialization()
        {
            if (_options.Has(NativeEnums.TASKDIALOG_FLAGS.TDF_SHOW_MARQUEE_PROGRESS_BAR))
                SendMessage(NativeConstants.WindowMessage.TDM_SET_PROGRESS_BAR_MARQUEE, 1, 0);
            else if (_options.Has(NativeEnums.TASKDIALOG_FLAGS.TDF_SHOW_PROGRESS_BAR))
            {
                SendMessage(NativeConstants.WindowMessage.TDM_SET_PROGRESS_BAR_RANGE, 0, _progressBar.Maximum << 16 | _progressBar.Minimum);
                SendMessage(NativeConstants.WindowMessage.TDM_SET_PROGRESS_BAR_STATE, (int)_progressBar.State, 0);
                SendMessage(NativeConstants.WindowMessage.TDM_SET_PROGRESS_BAR_POS, _progressBar.Value, 0);
            }

            if (_buttons != null && _buttons.Count > 0)
                foreach (var button in _buttons)
                    if (button.UseElevationIcon)
                        UpdateElevationIcon(button.Id, true);
        }

        internal void ThrowIfDialogShowing()
        {
            if (_isShowing)
                throw new InvalidOperationException("This property cannot be modified when the dialog is showing.");
        }

        void UpdateIcon(TaskDialogIcon icon) =>
            SendMessage(NativeConstants.WindowMessage.TDM_UPDATE_ICON, 0, (long)icon);
        void UpdateFooterIcon(TaskDialogIcon icon) =>
            SendMessage(NativeConstants.WindowMessage.TDM_UPDATE_ICON, 0, (long)icon);

        void UpdateInstruction(string instruction) =>
            UpdateText(NativeConstants.TASKDIALOG_ELEMENTS.TDE_MAIN_INSTRUCTION, instruction);
        void UpdateContent(string instruction) =>
            UpdateText(NativeConstants.TASKDIALOG_ELEMENTS.TDE_CONTENT, instruction);
        void UpdateDetail(string instruction) =>
            UpdateText(NativeConstants.TASKDIALOG_ELEMENTS.TDE_EXPANDED_INFORMATION, instruction);
        void UpdateFooter(string instruction) =>
            UpdateText(NativeConstants.TASKDIALOG_ELEMENTS.TDE_FOOTER, instruction);
        void UpdateText(NativeConstants.TASKDIALOG_ELEMENTS element, string text)
        {
            var ptr = Marshal.StringToHGlobalUni(text);

            SendMessage(NativeConstants.WindowMessage.TDM_SET_ELEMENT_TEXT, (int)element, ptr);
            Marshal.FreeHGlobal(ptr);
        }

        void UpdateFooterCheckbox(bool instruction) =>
            SendMessage(NativeConstants.WindowMessage.TDM_CLICK_VERIFICATION, instruction ? 1 : 0, 1);

        internal void UpdateProgressBarState(TaskDialogProgressBarState state)
        {
            //if (state == TaskDialogProgressBarState.Marquee)
            //    SendMessage(NativeConstants.WindowMessage.TDM_SET_PROGRESS_BAR_MARQUEE, 1, 0);
            //else
            //{
            //    SendMessage(NativeConstants.WindowMessage.TDM_SET_PROGRESS_BAR_MARQUEE, 0, 0);
            //}
            SendMessage(NativeConstants.WindowMessage.TDM_SET_PROGRESS_BAR_STATE, (int)state, 0);
        }
        internal void UpdateProgressBarValue(int value) =>
            SendMessage(NativeConstants.WindowMessage.TDM_SET_PROGRESS_BAR_POS, value, 0);

        internal void UpdateElevationIcon(int id, bool enabled) =>
            SendMessage(NativeConstants.WindowMessage.TDM_SET_BUTTON_ELEVATION_REQUIRED_STATE, id, enabled ? 1 : 0);

        void SendMessage(NativeConstants.WindowMessage message, int wParam, IntPtr lParam) =>
            NativeMethods.User32.SendMessageW(_handle, message, (IntPtr)wParam, lParam);
        void SendMessage(NativeConstants.WindowMessage message, int wParam, long lParam) =>
            NativeMethods.User32.SendMessageW(_handle, message, (IntPtr)wParam, (IntPtr)lParam);

        protected override void DisposeNativeResources()
        {
            _buttons?.Cleanup();
            _radioButtons?.Cleanup();
        }
    }
}
