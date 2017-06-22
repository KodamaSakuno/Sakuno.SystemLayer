using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Windows;
using IDataObject = System.Runtime.InteropServices.ComTypes.IDataObject;

namespace Sakuno.SystemLayer
{
    public static class DataObjectExtensions
    {
        public static bool TryGetData<T>(this IDataObject dataObject, string format, out T data) where T : struct
        {
            var formatEtc = CreateFormatEtc(format, TYMED.TYMED_HGLOBAL);

            if (NativeUtils.Failed(dataObject.QueryGetData(ref formatEtc)))
            {
                data = default(T);
                return false;
            }

            dataObject.GetData(ref formatEtc, out var medium);

            try
            {
                data = Marshal.PtrToStructure<T>(medium.unionmember);

                return true;
            }
            finally
            {
                NativeMethods.Ole32.ReleaseStgMedium(ref medium);
            }
        }

        public static void SetData<T>(this IDataObject dataObject, string format, T data) where T : struct
        {
            var formatEtc = CreateFormatEtc(format, TYMED.TYMED_HGLOBAL);
            var buffer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(T)));

            try
            {
                Marshal.StructureToPtr(data, buffer, false);

                var medium = new STGMEDIUM()
                {
                    pUnkForRelease = null,
                    tymed = TYMED.TYMED_HGLOBAL,
                    unionmember = buffer
                };

                dataObject.SetData(ref formatEtc, ref medium, true);
            }
            catch
            {
                Marshal.FreeHGlobal(buffer);
                throw;
            }
        }
        static FORMATETC CreateFormatEtc(string format, TYMED tymed) =>
            new FORMATETC
            {
                cfFormat = (short)DataFormats.GetDataFormat(format).Id,
                tymed = tymed,
                dwAspect = DVASPECT.DVASPECT_CONTENT,
                lindex = -1,
                ptd = IntPtr.Zero
            };
    }
}
