using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Sakuno.SystemLayer.Dialogs
{
    public sealed class CommonOpenFileDialog : CommonFileDialog
    {
        NativeInterfaces.IFileOpenDialog _dialog;

        bool _ensureFileExists = true;
        public bool EnsureFileExists
        {
            get => _ensureFileExists;
            set
            {
                if (_ensureFileExists != value)
                {
                    ThrowIfDialogShowing();
                    _ensureFileExists = value;
                }
            }
        }

        bool _isFolderPicker;
        public bool IsFolderPicker
        {
            get => _isFolderPicker;
            set
            {
                if (_isFolderPicker != value)
                {
                    ThrowIfDialogShowing();
                    _isFolderPicker = value;
                }
            }
        }

        bool _allowMultiSelection;
        public bool AllowMultiSelection
        {
            get => _allowMultiSelection;
            set
            {
                if (_allowMultiSelection != value)
                {
                    ThrowIfDialogShowing();
                    _allowMultiSelection = value;
                }
            }
        }

        public IEnumerable<string> Filenames
        {
            get
            {
                foreach (var filename in _filenames)
                    yield return filename;
            }
        }

        internal override NativeInterfaces.IFileDialog CreateDialog()
        {
            _dialog = (NativeInterfaces.IFileOpenDialog)new NativeInterfaces.FileOpenDialogRCW();

            return (NativeInterfaces.IFileDialog)_dialog;
        }

        protected override void DisposeNativeResources() => Marshal.ReleaseComObject(_dialog);

        internal override NativeEnums.FILEOPENDIALOGOPTIONS GetOptionsFromDeviredClass(NativeEnums.FILEOPENDIALOGOPTIONS options)
        {
            if (_ensureFileExists)
                options |= NativeEnums.FILEOPENDIALOGOPTIONS.FOS_FILEMUSTEXIST;

            if (_isFolderPicker)
                options |= NativeEnums.FILEOPENDIALOGOPTIONS.FOS_PICKFOLDERS;

            if (_allowMultiSelection)
                options |= NativeEnums.FILEOPENDIALOGOPTIONS.FOS_ALLOWMULTISELECT;

            return options;
        }

        protected override void ProcessResult()
        {
            var results = _dialog.GetResults();
            var count = results.GetCount();

            for (var i = 0; i < count; i++)
            {
                var item = results.GetItemAt(i);

                _filenames.Add(GetFilenameFromShellItem(item));
            }
        }
    }
}
