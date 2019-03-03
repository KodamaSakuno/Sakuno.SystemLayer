using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Windows;
using IDataObject = System.Runtime.InteropServices.ComTypes.IDataObject;

namespace Sakuno.SystemLayer
{
    public static partial class NativeInterfaces
    {
        [ComImport]
        [Guid("00000000-0000-0000-C000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IUnknown
        {
            IntPtr QueryInterface(in Guid riid, ref IntPtr pVoid);
            ulong AddRef();
            ulong Release();
        }

        [ComImport]
        [Guid("0000010d-0000-0000-C000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IViewObject
        {
            void Draw(int dwDrawAspect, int lindex, IntPtr pvAspect, ref NativeStructs.DVTARGETDEVICE ptd, IntPtr hdcTargetDev, IntPtr hdcDraw, ref NativeStructs.RECT lprcBounds, ref NativeStructs.RECT lprcWBounds, IntPtr pfnContinue, IntPtr dwContinue);
        }

        [ComImport]
        [Guid("6D5140C1-7436-11CE-8034-00AA006009FA")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IServiceProvider
        {
            [return: MarshalAs(UnmanagedType.Interface)]
            object QueryService(in Guid guidService, in Guid riid);
        }

        [ComImport]
        [Guid("886D8EEB-8CF2-4446-8D02-CDBA1DBDCF99")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IPropertyStore
        {
            int GetCount();
            NativeStructs.PROPERTYKEY GetAt(uint iProp);
            void GetValue(in NativeStructs.PROPERTYKEY key, NativeStructs.PROPVARIANT propvar);
            void SetValue(in NativeStructs.PROPERTYKEY key, NativeStructs.PROPVARIANT propvar);
            void Commit();
        }

        [ComImport]
        [Guid("6F79D558-3E96-4549-A1D1-7D75D2288814")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IPropertyDescription
        {
            NativeStructs.PROPERTYKEY GetPropertyKey();
            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetCanonicalName();
            NativeConstants.VARTYPE GetPropertyType();
            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetDisplayName();
            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetEditInvitation();
            NativeEnums.PROPDESC_TYPE_FLAGS GetTypeFlags(NativeEnums.PROPDESC_TYPE_FLAGS mask);
            NativeEnums.PROPDESC_VIEW_FLAGS GetViewFlags();
            int GetDefaultColumnWidth();
            NativeConstants.PROPDESC_DISPLAYTYPE GetDisplayType();
            NativeEnums.SHCOLSTATE GetColumnState();
            NativeConstants.PROPDESC_GROUPING_RANGE GetGroupingRange();
            NativeConstants.PROPDESC_RELATIVEDESCRIPTION_TYPE GetRelativeDescriptionType();
            void GetRelativeDescription(NativeStructs.PROPVARIANT propvar1, NativeStructs.PROPVARIANT propvar2, [MarshalAs(UnmanagedType.LPWStr)] out string ppszDesc1, [MarshalAs(UnmanagedType.LPWStr)] out string ppszDesc2);
            NativeConstants.PROPDESC_SORTDESCRIPTION GetSortDescription();
            IntPtr GetSortDescriptionLabel(bool fDescending);
            NativeConstants.PROPDESC_AGGREGATION_TYPE GetAggregationType();
            void GetConditionType(out NativeConstants.PROPDESC_CONDITION_TYPE pcontype, out NativeConstants.CONDITION_OPERATION popDefault);
            IPropertyEnumTypeList GetEnumTypeList(in Guid riid);
            void CoerceToCanonicalValue(NativeStructs.PROPVARIANT propvar);
            [return: MarshalAs(UnmanagedType.LPWStr)]
            string FormatForDisplay(NativeStructs.PROPVARIANT propvar, NativeEnums.PROPDESC_FORMAT_FLAGS pdfFlags);
            void IsValueCanonical(NativeStructs.PROPVARIANT propvar);
        }

        [ComImport]
        [Guid("1F9FC1D0-C39B-4B26-817F-011967D3440E")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IPropertyDescriptionList
        {
            int GetCount();
            IPropertyDescription GetAt(int iElem, in Guid riid);
        }

        [ComImport]
        [Guid("11E1FBF9-2D56-4A6B-8DB3-7CD193A471F2")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IPropertyEnumType
        {
            NativeConstants.PROPENUMTYPE GetEnumType();
            void GetValue(NativeStructs.PROPVARIANT ppropvar);
            void GetRangeMinValue(NativeStructs.PROPVARIANT ppropvar);
            void GetRangeSetValue(NativeStructs.PROPVARIANT ppropvar);
            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetDisplayText();
        }

        [ComImport]
        [Guid("A99400F4-3D84-4557-94BA-1242FB2CC9A6")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IPropertyEnumTypeList
        {
            int GetCount();
            IPropertyDescription GetAt(int iElem, in Guid riid);
            object GetConditionAt(int nIndex, in Guid riid);
            int FindMatchingIndex(NativeStructs.PROPVARIANT propvarCmp);
        }

        [ComImport]
        [Guid("55272A00-42CB-11CE-8135-00AA004BB851")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IPropertyBag
        {
            void Read([MarshalAs(UnmanagedType.LPWStr)] string pszPropName, NativeStructs.PROPVARIANT pVar, object pErrorLog = null);
            void Write([MarshalAs(UnmanagedType.LPWStr)] string pszPropName, NativeStructs.PROPVARIANT pVar);
        }

        [ComImport]
        [Guid("B196B284-BAB4-101A-B69C-00AA00341D07")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IConnectionPointContainer
        {
            IEnumerable EnumConnectionPoints();
            IConnectionPoint FindConnectionPoint(in Guid riid);
        }

        [ComImport]
        [Guid("B196B286-BAB4-101A-B69C-00AA00341D07")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IConnectionPoint
        {
            Guid GetConnectionInterface();
            IConnectionPointContainer GetConnectionPointContainer(in Guid riid);
            uint Advise([MarshalAs(UnmanagedType.IUnknown)] object pUnkSink);
            void Unadvise(uint dwCookie);
            IEnumerable EnumConnections();
        }

        [ComImport]
        [Guid("4657278A-411B-11d2-839A-00C04FD918D0")]
        [ClassInterface(ClassInterfaceType.None)]
        public class DragDropHelper { }

        [ComImport]
        [Guid("DE5BF786-477A-11D2-839D-00C04FD918D0")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDragSourceHelper
        {
            void InitializeFromBitmap(ref NativeStructs.SHDRAGIMAGE pshdi, IDataObject pDataObject);
            void InitializeFromWindow(IntPtr hwnd, ref NativeStructs.POINT ppt, IDataObject pDataObject);
        }
        [ComImport]
        [Guid("83E07D0D-0C5F-4163-BF1A-60B274051E40")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDragSourceHelper2
        {
            void InitializeFromBitmap(ref NativeStructs.SHDRAGIMAGE pshdi, IDataObject pDataObject);
            void InitializeFromWindow(IntPtr hwnd, ref NativeStructs.POINT ppt, IDataObject pDataObject);
            void SetFlags(NativeEnums.DSH_FLAGS dwFlags);
        }

        [ComImport]
        [Guid("4657278B-411B-11D2-839A-00C04FD918D0")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDropTargetHelper
        {
            void DragEnter(IntPtr hwndTarget, IDataObject pDataObject, ref NativeStructs.POINT ppt, DragDropEffects dwEffect);
            void DragLeave();
            void DragOver(ref NativeStructs.POINT ppt, DragDropEffects dwEffect);
            void Drop(IDataObject dataObject, ref NativeStructs.POINT ppt, DragDropEffects dwEffect);
            void Show(bool fShow);
        }
    }
}
