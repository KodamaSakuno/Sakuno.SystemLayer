using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Sakuno.SystemLayer
{
    public sealed unsafe class Shortcut : DisposableObject
    {
        const int BufferSize = 256;

        readonly NativeInterfaces.IShellLinkW _shellLink;
        readonly IPersistFile _persistFile;
        readonly NativeInterfaces.IPropertyStore _propertyStore;

        public string Path
        {
            get
            {
                ThrowIfDisposed();

                var buffer = stackalloc char[BufferSize];
                _shellLink.GetPath(buffer, BufferSize, IntPtr.Zero, 0);

                return Marshal.PtrToStringUni((IntPtr)buffer);
            }
            set
            {
                ThrowIfDisposed();

                _shellLink.SetPath(value);
            }
        }

        public string Arguments
        {
            get
            {
                ThrowIfDisposed();

                var buffer = stackalloc char[BufferSize];
                _shellLink.GetArguments(buffer, BufferSize);

                return Marshal.PtrToStringUni((IntPtr)buffer);
            }
            set
            {
                ThrowIfDisposed();

                _shellLink.SetArguments(value);
            }
        }

        public string WorkingDirectory
        {
            get
            {
                ThrowIfDisposed();

                var buffer = stackalloc char[BufferSize];
                _shellLink.GetWorkingDirectory(buffer, BufferSize);

                return Marshal.PtrToStringUni((IntPtr)buffer);
            }
            set
            {
                ThrowIfDisposed();

                _shellLink.SetWorkingDirectory(value);
            }
        }

        public ShortcutShowCommand ShowCommand
        {
            get
            {
                ThrowIfDisposed();

                var showCommand = _shellLink.GetShowCmd();

                return showCommand switch
                {
                    NativeConstants.ShowCommand.SW_SHOWNORMAL => ShortcutShowCommand.Normal,
                    NativeConstants.ShowCommand.SW_SHOWMINNOACTIVE => ShortcutShowCommand.Minimized,
                    NativeConstants.ShowCommand.SW_SHOWMAXIMIZED => ShortcutShowCommand.Maximized,

                    _ => throw new ArgumentOutOfRangeException(nameof(showCommand)),
                };
            }
            set
            {
                ThrowIfDisposed();

                var showCommand = value switch
                {
                    ShortcutShowCommand.Normal => NativeConstants.ShowCommand.SW_SHOWNORMAL,
                    ShortcutShowCommand.Minimized => NativeConstants.ShowCommand.SW_SHOWMINNOACTIVE,
                    ShortcutShowCommand.Maximized => NativeConstants.ShowCommand.SW_SHOWMAXIMIZED,

                    _ => throw new ArgumentOutOfRangeException(nameof(value)),
                };
                _shellLink.SetShowCmd(showCommand);
            }
        }

        public string Description
        {
            get
            {
                ThrowIfDisposed();

                var buffer = stackalloc char[BufferSize];
                _shellLink.GetDescription(buffer, BufferSize);

                return Marshal.PtrToStringUni((IntPtr)buffer);
            }
            set
            {
                ThrowIfDisposed();

                _shellLink.SetDescription(value);
            }
        }

        public string AppUserModelId
        {
            get
            {
                ThrowIfDisposed();

                using var propertyVariant = new NativeStructs.PROPVARIANT();

                var propertyKey = new NativeStructs.PROPERTYKEY(NativeGuids.PKEY_AppUserModel_ID, 5);
                _propertyStore.GetValue(propertyKey, propertyVariant);

                return propertyVariant.StringValue;
            }
            set
            {
                ThrowIfDisposed();

                using var propertyVariant = new NativeStructs.PROPVARIANT(value);

                var propertyKey = new NativeStructs.PROPERTYKEY(NativeGuids.PKEY_AppUserModel_ID, 5);
                _propertyStore.SetValue(propertyKey, propertyVariant);
                _propertyStore.Commit();
            }
        }

        public Shortcut(string filename)
        {
            if (filename.IsNullOrWhiteSpace())
                throw new ArgumentException(nameof(filename));

            _shellLink = (NativeInterfaces.IShellLinkW)new NativeInterfaces.CShellLink();
            _persistFile = (IPersistFile)_shellLink;
            _propertyStore = (NativeInterfaces.IPropertyStore)_shellLink;

            _persistFile.Load(filename, File.Exists(filename) ? 0 : (int)NativeEnums.STGM.STGM_CREATE);
        }

        public void Save()
        {
            ThrowIfDisposed();

            _persistFile.Save(null, false);
        }

        protected override void DisposeNativeResources() => Marshal.FinalReleaseComObject(_shellLink);
    }
}
