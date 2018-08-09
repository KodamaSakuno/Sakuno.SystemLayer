using System;
using System.Runtime.InteropServices;

namespace Sakuno.SystemLayer.Dialogs
{
    public sealed class CommonSaveFileDialog : CommonFileDialog
    {
        NativeInterfaces.IFileSaveDialog _dialog;

        bool _allowReadOnlyItem;
        public bool AllowReadOnlyItem
        {
            get => _allowReadOnlyItem;
            set
            {
                if (_allowReadOnlyItem != value)
                {
                    ThrowIfDialogShowing();
                    _allowReadOnlyItem = value;
                }
            }
        }

        bool _createPrompt;
        public bool CreatePrompt
        {
            get => _createPrompt;
            set
            {
                if (_createPrompt != value)
                {
                    ThrowIfDialogShowing();
                    _createPrompt = value;
                }
            }
        }

        bool _overwritePrompt = true;
        public bool OverwritePrompt
        {
            get => _overwritePrompt;
            set
            {
                if (_overwritePrompt != value)
                {
                    ThrowIfDialogShowing();
                    _overwritePrompt = value;
                }
            }
        }

        internal override NativeInterfaces.IFileDialog CreateDialog()
        {
            _dialog = (NativeInterfaces.IFileSaveDialog)new NativeInterfaces.FileSaveDialogRCW();

            return (NativeInterfaces.IFileDialog)_dialog;
        }

        protected override void DisposeNativeResources() => Marshal.ReleaseComObject(_dialog);

        internal override NativeEnums.FILEOPENDIALOGOPTIONS GetOptionsFromDeviredClass(NativeEnums.FILEOPENDIALOGOPTIONS options)
        {
            if (!_allowReadOnlyItem)
                options |= NativeEnums.FILEOPENDIALOGOPTIONS.FOS_NOREADONLYRETURN;

            if (_createPrompt)
                options |= NativeEnums.FILEOPENDIALOGOPTIONS.FOS_CREATEPROMPT;

            if (_overwritePrompt)
                options |= NativeEnums.FILEOPENDIALOGOPTIONS.FOS_OVERWRITEPROMPT;

            return options;
        }

        protected override void ProcessResult()
        {
            var item = _dialog.GetResult() ?? throw new InvalidOperationException("Saving with null item.");

            _filenames.Add(GetFilenameFromShellItem(item));
        }
    }
}
