using Sakuno.SystemLayer.Dialogs;
using System;
using System.Runtime.InteropServices;

namespace Sakuno.SystemLayer
{
    partial class NativeInterfaces
    {
        [ComImport]
        [Guid("42F85136-DB7E-439C-85F1-E4075D135FC8")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IFileDialog
        {
            [PreserveSig]
            int Show(IntPtr parent);
            void SetFileTypes(int cFileTypes, [MarshalAs(UnmanagedType.LPArray)] NativeStructs.COMDLG_FILTERSPEC[] rgFilterSpec);
            void SetFileTypeIndex(int iFileType);
            int GetFileTypeIndex();
            uint Advise(IFileDialogEvents pfde);
            void Unadvise(uint dwCookie);
            void SetOptions(NativeEnums.FILEOPENDIALOGOPTIONS fos);
            NativeEnums.FILEOPENDIALOGOPTIONS GetOptions();
            void SetDefaultFolder(IShellItem psi);
            void SetFolder(IShellItem psi);
            IShellItem GetFolder();
            IShellItem GetCurrentSelection();
            void SetFileName([MarshalAs(UnmanagedType.LPWStr)] string pszName);
            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetFileName();
            void SetTitle([MarshalAs(UnmanagedType.LPWStr)] string pszTitle);
            void SetOkButtonLabel([MarshalAs(UnmanagedType.LPWStr)] string pszText);
            void SetFileNameLabel([MarshalAs(UnmanagedType.LPWStr)] string pszLabel);
            IShellItem GetResult();
            void AddPlace(IShellItem psi, CommonFileDialogCustomPlaceLocation fdap);
            void SetDefaultExtension([MarshalAs(UnmanagedType.LPWStr)] string pszDefaultExtension);
            void Close(int hr);
            void SetClientGuid(in Guid guid);
            void ClearClientData();
            void SetFilter(IntPtr pFilter);
        }

        [ComImport]
        [Guid("D57C7288-D4AD-4768-BE02-9D969532D960")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IFileOpenDialog
        {
            [PreserveSig]
            int Show(IntPtr parent);
            void SetFileTypes(int cFileTypes, [MarshalAs(UnmanagedType.LPArray)] NativeStructs.COMDLG_FILTERSPEC[] rgFilterSpec);
            void SetFileTypeIndex(int iFileType);
            int GetFileTypeIndex();
            uint Advise(IFileDialogEvents pfde);
            void Unadvise(uint dwCookie);
            void SetOptions(NativeEnums.FILEOPENDIALOGOPTIONS fos);
            NativeEnums.FILEOPENDIALOGOPTIONS GetOptions();
            void SetDefaultFolder(IShellItem psi);
            void SetFolder(IShellItem psi);
            IShellItem GetFolder();
            IShellItem GetCurrentSelection();
            void SetFileName([MarshalAs(UnmanagedType.LPWStr)] string pszName);
            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetFileName();
            void SetTitle([MarshalAs(UnmanagedType.LPWStr)] string pszTitle);
            void SetOkButtonLabel([MarshalAs(UnmanagedType.LPWStr)] string pszText);
            void SetFileNameLabel([MarshalAs(UnmanagedType.LPWStr)] string pszLabel);
            IShellItem GetResult();
            void AddPlace(IShellItem psi, CommonFileDialogCustomPlaceLocation fdap);
            void SetDefaultExtension([MarshalAs(UnmanagedType.LPWStr)] string pszDefaultExtension);
            void Close(int hr);
            void SetClientGuid(in Guid guid);
            void ClearClientData();
            void SetFilter(IntPtr pFilter);
            IShellItemArray GetResults();
            IShellItemArray GetSelectedItems();
        }

        [ComImport]
        [Guid("84BCCD23-5FDE-4CDB-AEA4-AF64B83D78AB")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IFileSaveDialog
        {
            [PreserveSig]
            int Show(IntPtr parent);
            void SetFileTypes(int cFileTypes, [MarshalAs(UnmanagedType.LPArray)] NativeStructs.COMDLG_FILTERSPEC[] rgFilterSpec);
            void SetFileTypeIndex(int iFileType);
            int GetFileTypeIndex();
            uint Advise(IFileDialogEvents pfde);
            void Unadvise(uint dwCookie);
            void SetOptions(NativeEnums.FILEOPENDIALOGOPTIONS fos);
            NativeEnums.FILEOPENDIALOGOPTIONS GetOptions();
            void SetDefaultFolder(IShellItem psi);
            void SetFolder(IShellItem psi);
            IShellItem GetFolder();
            IShellItem GetCurrentSelection();
            void SetFileName([MarshalAs(UnmanagedType.LPWStr)] string pszName);
            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetFileName();
            void SetTitle([MarshalAs(UnmanagedType.LPWStr)] string pszTitle);
            void SetOkButtonLabel([MarshalAs(UnmanagedType.LPWStr)] string pszText);
            void SetFileNameLabel([MarshalAs(UnmanagedType.LPWStr)] string pszLabel);
            IShellItem GetResult();
            void AddPlace(IShellItem psi, CommonFileDialogCustomPlaceLocation fdap);
            void SetDefaultExtension([MarshalAs(UnmanagedType.LPWStr)] string pszDefaultExtension);
            void Close(int hr);
            void SetClientGuid(in Guid guid);
            void ClearClientData();
            void SetFilter(IntPtr pFilter);
            void SetSaveAsItem(IShellItem psi);
            void SetProperties(IntPtr pStore);
            void SetCollectedProperties(IPropertyDescriptionList pList, bool fAppendDefault);
            IPropertyStore GetProperties();
            void ApplyProperties(IShellItem psi, IntPtr pStore, ref IntPtr hwnd, IntPtr pSink);
        }

        [ComImport]
        [Guid("DC1C5A9C-E88A-4DDE-A5A1-60F82A20AEF7")]
        [ClassInterface(ClassInterfaceType.None)]
        internal class FileOpenDialogRCW { }
        [ComImport]
        [Guid("C0B4E2F3-BA21-4773-8DBA-335EC946EB8B")]
        [ClassInterface(ClassInterfaceType.None)]
        internal class FileSaveDialogRCW { }

        [ComImport]
        [Guid("973510DB-7D7F-452B-8975-74A85828D354")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IFileDialogEvents
        {
            void OnFileOk(IFileDialog pfd);
            void OnFolderChanging(IFileDialog pfd, IShellItem psiFolder);
            void OnFolderChange(IFileDialog pfd);
            void OnSelectionChange(IFileDialog pfd);
            NativeConstants.FDE_SHAREVIOLATION_RESPONSE OnShareViolation(IFileDialog pfd, IShellItem psi);
            void OnTypeChange(IFileDialog pfd);
            NativeConstants.FDE_OVERWRITE_RESPONSE OnOverwrite(IFileDialog pfd, IShellItem psi);
        }
    }
}
