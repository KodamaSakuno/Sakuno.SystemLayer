using Sakuno.SystemLayer.Dialogs;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Sakuno.SystemLayer
{
    partial class NativeInterfaces
    {
        [ComImport]
        [Guid("000214E6-0000-0000-C000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IShellFolder
        {
            void ParseDisplayName(IntPtr hwnd, IBindCtx pbc, [MarshalAs(UnmanagedType.LPWStr)] string pszDisplayName, ref uint pchEaten, IntPtr ppidl, ref uint pdwAttributes);
            IEnumerable EnumObjects(IntPtr hwnd, NativeEnums.SHCONTF grfFlags);
            IShellFolder BindToObject(IntPtr pidl, IntPtr pbc, in Guid riid);
            IntPtr BindToStorage(ref IntPtr pidl, IBindCtx pbc, in Guid riid);
            void CompareIDs(IntPtr lParam, ref IntPtr pidl1, ref IntPtr pidl2);
            IntPtr CreateViewObject(IntPtr hwndOwner, in Guid riid);
            void GetAttributesOf(uint cidl, IntPtr apidl, ref uint rgfInOut);
            IntPtr GetUIObjectOf(IntPtr hwndOwner, uint cidl, IntPtr apidl, in Guid riid, ref uint rgfReserved);
            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetDisplayNameOf(ref IntPtr pidl, uint uFlags);
            IntPtr SetNameOf(IntPtr hwnd, ref IntPtr pidl, [MarshalAs(UnmanagedType.LPWStr)] string pszName, uint uFlags);
        }

        [ComImport]
        [Guid("43826D1E-E718-42EE-BC55-A1E261C37BFE")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IShellItem
        {
            IShellFolder BindToHandler(IntPtr pbc, in Guid bhid, in Guid riid);
            IShellItem GetParent();
            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetDisplayName(NativeEnums.SIGDN sigdnName);
            NativeEnums.SFGAO GetAttributes(NativeEnums.SFGAO sfgaoMask);
            int Compare(IShellItem psi, NativeEnums.SICHINTF hint);
        }

        [ComImport]
        [Guid("B63EA76D-1F85-456F-A19C-48159EFA858B")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IShellItemArray
        {
            IntPtr BindToHandler(IntPtr pbc, in Guid bhid, in Guid riid);
            IntPtr GetPropertyStore(int flags, in Guid riid);
            IntPtr GetPropertyDescriptionList(ref NativeStructs.PROPERTYKEY keyType, in Guid riid);
            NativeEnums.SFGAO GetAttributes(NativeConstants.SIATTRIBFLAGS dwAttribFlags, NativeEnums.SFGAO sfgaoMask);
            int GetCount();
            IShellItem GetItemAt(int dwIndex);
            IntPtr EnumItems();
        }

        [ComImport]
        [Guid("000214F9-0000-0000-C000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IShellLinkW
        {
            void GetPath([MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile, int cchMaxPath, ref NativeStructs.WIN32_FIND_DATAW pfd, NativeEnums.SLGP fFlags);
            IntPtr GetIDList();
            void SetIDList(IntPtr pidl);
            void GetDescription([MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszName, int cchMaxName);
            void SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);
            void GetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDir, int cchMaxPath);
            void SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);
            void GetArguments([MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszArgs, int cchMaxPath);
            void SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);
            ushort GetHotKey();
            void SetHotKey(ushort wHotKey);
            int GetShowCmd();
            void SetShowCmd(int iShowCmd);
            int GetIconLocation([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszIconPath, int cchIconPath);
            void SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int iIcon);
            void SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, uint dwReserved);
            void Resolve(IntPtr hwnd, uint fFlags);
            void SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
        }
        [ComImport]
        [Guid("00021401-0000-0000-C000-000000000046")]
        [ClassInterface(ClassInterfaceType.None)]
        public class CShellLink { }

        [ComImport]
        [Guid("B4DB1657-70D7-485E-8E3E-6FCB5A5C1802")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IModalWindow
        {
            void Show(IntPtr hwndOwner);
        }

        [ComImport]
        [Guid("EBBC7C04-315E-11d2-B62F-006097DF5BD4")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IProgressDialog
        {
            void StartProgressDialog(IntPtr hwndParent, object punkEnableModless, NativeEnums.PROGDLG dwFlags, object pvReserved = null);
            void StopProgressDialog();
            void SetTitle([MarshalAs(UnmanagedType.LPWStr)] string pwzTitle);
            void SetAnimation(IntPtr hInstAnimation, uint idAnimation);
            [return: MarshalAs(UnmanagedType.Bool)]
            bool HasUserCancelled();
            void SetProgress(int dwCompleted, int dwTotal);
            void SetProgress64(long ullCompleted, long ullTotal);
            void SetLine(int dwLineNum, [MarshalAs(UnmanagedType.LPWStr)] string pwzString, bool fCompactPath, object pvReserved = null);
            void SetCancelMsg([MarshalAs(UnmanagedType.LPWStr)] string pwzCancelMsg, object pvResversed = null);
            void Timer(ProgressDialogTimerAction dwTimerAction, object pvReserved = null);
        }
        [ComImport]
        [Guid("F8383852-FCD3-11d1-A6B9-006097DF5BD4")]
        internal class CProgressDialog { }
    }
}
