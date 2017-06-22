using System;
using System.Collections.Generic;
using System.IO;

namespace Sakuno.SystemLayer.Dialogs
{
    public abstract class CommonFileDialog : DisposableObject
    {
        NativeInterfaces.IFileDialog _dialog;

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

        string _title;
        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;

                    if (_isShowing)
                        _dialog.SetTitle(value);
                }
            }
        }

        string _okButtonText;
        public string OkButtonText
        {
            get => _okButtonText;
            set
            {
                if (_okButtonText != value)
                {
                    _okButtonText = value;

                    if (_isShowing)
                        _dialog.SetOkButtonLabel(value);
                }
            }
        }

        string _defaultFolder;
        public string DefaultFolder
        {
            get => _defaultFolder;
            set
            {
                if (_defaultFolder != value)
                {
                    ThrowIfDialogShowing();
                    _defaultFolder = value;
                }
            }
        }

        string _defaultFilename;
        public string DefaultFilename
        {
            get => _defaultFilename;
            set
            {
                if (_defaultFilename != value)
                {
                    ThrowIfDialogShowing();
                    _defaultFilename = value;
                }
            }
        }

        string _defaultExtension;
        public string DefaultExtension
        {
            get => _defaultExtension;
            set
            {
                if (_defaultExtension != value)
                {
                    ThrowIfDialogShowing();
                    _defaultExtension = value;
                }
            }
        }

        bool _isFileTypesSet;
        CommonFileDialogFileTypeCollection _fileTypes = new CommonFileDialogFileTypeCollection();
        public ICollection<CommonFileDialogFileType> FileTypes => _fileTypes;

        public int SelectedFileTypeIndex
        {
            get => _dialog?.GetFileTypeIndex() ?? 0;
            set
            {
                if (_dialog == null)
                    throw new InvalidOperationException();

                _dialog.SetFileTypeIndex(value);
            }
        }

        List<CommonFileDialogCustomPlace> _customPlaces;
        public ICollection<CommonFileDialogCustomPlace> CustomPlaces =>
            _customPlaces ?? (_customPlaces = new List<CommonFileDialogCustomPlace>());

        public string CurrentFolder
        {
            get
            {
                if (_dialog == null)
                    throw new InvalidOperationException();

                return GetFilenameFromShellItem(_dialog.GetFolder());
            }
            set
            {
                if (_dialog == null)
                    throw new InvalidOperationException();

                _dialog.SetFolder(GetShellItemFromFilename(value));
            }
        }

        protected List<string> _filenames = new List<string>();
        public string Filename
        {
            get
            {
                if (_filenames.Count == 0)
                    throw new InvalidOperationException();

                var rResult = _filenames[0];

                if (!DefaultExtension.IsNullOrEmpty())
                    rResult = Path.ChangeExtension(rResult, DefaultExtension);

                return rResult;
            }
        }

        bool _hideStandardLocationsInPlaceList;
        public bool HideStandardLocationsInPlaceList
        {
            get => _hideStandardLocationsInPlaceList;
            set
            {
                if (_hideStandardLocationsInPlaceList != value)
                {
                    ThrowIfDialogShowing();
                    _hideStandardLocationsInPlaceList = value;
                }
            }
        }
        bool _addToRecent = true;
        public bool AddToRecent
        {
            get => _addToRecent;
            set
            {
                if (_addToRecent != value)
                {
                    ThrowIfDialogShowing();
                    _addToRecent = value;
                }
            }
        }

        bool _ensurePathExists = true;
        public bool EnsurePathExists
        {
            get => _ensurePathExists;
            set
            {
                if (_ensurePathExists != value)
                {
                    ThrowIfDialogShowing();
                    _ensurePathExists = value;
                }
            }
        }

        bool _showHiddenItems;
        public bool ShowHiddenItems
        {
            get => _showHiddenItems;
            set
            {
                if (_showHiddenItems != value)
                {
                    ThrowIfDialogShowing();
                    _showHiddenItems = value;
                }
            }
        }

        bool _dereferenceLinks = true;
        public bool DereferenceLinks
        {
            get => _dereferenceLinks;
            set
            {
                if (_dereferenceLinks != value)
                {
                    ThrowIfDialogShowing();
                    _dereferenceLinks = value;
                }
            }
        }

        public CommonFileDialogResult Show()
        {
            EnsureDialog();

            var options = GetOptions();

            _dialog.SetOptions(options);

            if (!_title.IsNullOrEmpty())
                _dialog.SetTitle(Title);

            if (!_okButtonText.IsNullOrEmpty())
                _dialog.SetOkButtonLabel(_okButtonText);

            if (!_defaultFolder.IsNullOrEmpty())
            {
                var defaultFolder = GetShellItemFromFilename(_defaultFolder);

                if (defaultFolder != null)
                    _dialog.SetDefaultFolder(defaultFolder);
            }

            if (!_defaultExtension.IsNullOrEmpty())
                _dialog.SetDefaultExtension(_defaultExtension);

            if (!_defaultFilename.IsNullOrEmpty())
                _dialog.SetFileName(_defaultFilename);

            if ((options & NativeEnums.FILEOPENDIALOGOPTIONS.FOS_PICKFOLDERS) == 0 && !_isFileTypesSet && FileTypes.Count > 0)
            {
                _dialog.SetFileTypes(FileTypes.Count, _fileTypes.ToFilterSpec());
                _isFileTypesSet = true;
            }

            for (var i = 0; i < FileTypes.Count; i++)
            {
                var fileType = _fileTypes[i];

                if (fileType.Default)
                {
                    _dialog.SetFileTypeIndex(i + 1);
                    break;
                }
            }

            if (_customPlaces != null && _customPlaces.Count > 0)
                foreach (var customPlace in _customPlaces)
                    _dialog.AddPlace(GetShellItemFromFilename(customPlace.Path), customPlace.Location);

            return ShowCore();
        }
        CommonFileDialogResult ShowCore()
        {
            _isShowing = true;

            var result = _dialog.Show(_ownerWindowHandle);

            _isShowing = false;

            _filenames.Clear();

            if (result == 0)
            {
                ProcessResult();

                return CommonFileDialogResult.Ok;
            }

            return CommonFileDialogResult.Cancel;
        }

        internal void EnsureDialog()
        {
            if (_dialog == null)
                _dialog = CreateDialog();
        }
        internal abstract NativeInterfaces.IFileDialog CreateDialog();

        NativeEnums.FILEOPENDIALOGOPTIONS GetOptions()
        {
            var options = GetOptionsFromDeviredClass(NativeEnums.FILEOPENDIALOGOPTIONS.FOS_NOTESTFILECREATE);

            if (_hideStandardLocationsInPlaceList)
                options |= NativeEnums.FILEOPENDIALOGOPTIONS.FOS_HIDEPINNEDPLACES;

            if (!_addToRecent)
                options |= NativeEnums.FILEOPENDIALOGOPTIONS.FOS_DONTADDTORECENT;

            if (_ensurePathExists)
                options |= NativeEnums.FILEOPENDIALOGOPTIONS.FOS_PATHMUSTEXIST;

            if (_showHiddenItems)
                options |= NativeEnums.FILEOPENDIALOGOPTIONS.FOS_FORCESHOWHIDDEN;

            if (!_dereferenceLinks)
                options |= NativeEnums.FILEOPENDIALOGOPTIONS.FOS_NODEREFERENCELINKS;

            return options | NativeEnums.FILEOPENDIALOGOPTIONS.FOS_NOCHANGEDIR;
        }
        internal abstract NativeEnums.FILEOPENDIALOGOPTIONS GetOptionsFromDeviredClass(NativeEnums.FILEOPENDIALOGOPTIONS options);

        internal static string GetFilenameFromShellItem(NativeInterfaces.IShellItem item) =>
            item.GetDisplayName(NativeEnums.SIGDN.SIGDN_DESKTOPABSOLUTEPARSING);
        internal static NativeInterfaces.IShellItem GetShellItemFromFilename(string filename)
        {
            var guid = typeof(NativeInterfaces.IShellItem).GUID;

            NativeMethods.Shell32.SHCreateItemFromParsingName(filename, IntPtr.Zero, ref guid, out var result);

            return result;
        }

        protected abstract void ProcessResult();

        protected void ThrowIfDialogShowing()
        {
            if (_isShowing)
                throw new InvalidOperationException("This property cannot be modified when the dialog is showing.");
        }
    }
}
