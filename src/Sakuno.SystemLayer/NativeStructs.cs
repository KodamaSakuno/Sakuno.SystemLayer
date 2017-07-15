using Sakuno.SystemLayer.Dialogs;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Media;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Sakuno.SystemLayer
{
    public static partial class NativeStructs
    {
        [DebuggerDisplay("POINT ({X}, {Y})")]
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SIZE
        {
            public int X;
            public int Y;

            public SIZE(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        [DebuggerDisplay("RECT [{Left}, {Top}, {Right}, {Bottom}] ({Width} x {Height})")]
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            public int Width => Right - Left;
            public int Height => Bottom - Top;

            public RECT(int left, int top, int right, int bottom)
            {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
            }
        }

        [DebuggerDisplay("MARGINS [{Left}, {Top}, {Right}, {Bottom}]")]
        [StructLayout(LayoutKind.Sequential)]
        public struct MARGINS
        {
            public int Left;
            public int Right;
            public int Top;
            public int Bottom;

            public MARGINS(int uniformValue) : this(uniformValue, uniformValue, uniformValue, uniformValue) { }
            public MARGINS(double left, double top, double right, double bottom) : this((int)left, (int)top, (int)right, (int)bottom) { }
            public MARGINS(int left, int top, int right, int bottom)
            {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWPOS
        {
            public IntPtr hwnd;
            public IntPtr hwndInsertAfter;
            public int x;
            public int y;
            public int cx;
            public int cy;
            public NativeEnums.SetWindowPosition flags;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public NativeConstants.ShowCommand showCmd;
            public POINT ptMinPosition;
            public POINT ptMaxPosition;
            public RECT rcNormalPosition;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct INTERNET_CACHE_ENTRY_INFO
        {
            public uint dwStructSize;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszSourceUrlName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszLocalFileName;
            public NativeEnums.CACHEENTRYTYPE CacheEntryType;
            public uint dwUseCount;
            public uint dwHitRate;
            public uint dwSizeLow;
            public uint dwSizeHigh;
            public FILETIME LastModifiedTime;
            public FILETIME ExpireTime;
            public FILETIME LastAccessTime;
            public FILETIME LastSyncTime;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpHeaderInfo;
            public uint dwHeaderInfoSize;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszFileExtension;
            public IntPtr dwReserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct INTERNET_PROXY_INFO
        {
            public NativeConstants.INTERNET_OPEN_TYPE dwAccessType;
            public IntPtr lpszProxy;
            public IntPtr lpszProxyBypass;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class DVTARGETDEVICE
        {
            public int tdSize;
            public short tdDeviceNameOffset;
            public short tdDriverNameOffset;
            public short tdExtDevmodeOffset;
            public short tdPortNameOffset;
            public byte tdData;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct BITMAPINFO
        {
            public BITMAPINFOHEADER bmiHeader;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1, ArraySubType = UnmanagedType.Struct)]
            public RGBQUAD[] bmiColors;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct BITMAPINFOHEADER
        {
            public int biSize;
            public int biWidth;
            public int biHeight;
            public ushort biPlanes;
            public ushort biBitCount;
            public uint biCompression;
            public uint biSizeImage;
            public int biXPelsPerMeter;
            public int biYPelsPerMeter;
            public uint biClrUsed;
            public uint biClrImportant;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct RGBQUAD
        {
            public byte rgbBlue;
            public byte rgbGreen;
            public byte rgbRed;
            public byte rgbReserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DWM_THUMBNAIL_PROPERTIES
        {
            public NativeEnums.DWM_TNP dwFlags;
            public RECT rcDestination;
            public RECT rcSource;
            public byte opacity;
            [MarshalAs(UnmanagedType.Bool)]
            public bool fVisible;
            [MarshalAs(UnmanagedType.Bool)]
            public bool fSourceClientAreaOnly;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POWERBROADCAST_SETTING
        {
            public Guid PowerSetting;
            public uint DataLength;
            public int Data;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MONITORINFO
        {
            public int cbSize;
            public RECT rcMonitor;
            public RECT rcWork;
            public uint dwFlags;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEM_BATTERY_STATE
        {
            [MarshalAs(UnmanagedType.I1)]
            public bool AcOnLine;
            [MarshalAs(UnmanagedType.I1)]
            public bool BatteryPresent;
            [MarshalAs(UnmanagedType.I1)]
            public bool Charging;
            [MarshalAs(UnmanagedType.I1)]
            public bool Discharging;

            public byte Spare1;
            public byte Spare2;
            public byte Spare3;
            public byte Spare4;

            public uint MaxCapacity;
            public uint RemainingCapacity;
            public uint Rate;
            public uint EstimatedTime;
            public uint DefaultAlert1;
            public uint DefaultAlert2;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct WIN32_FIND_DATAW
        {
            public FileAttributes dwFileAttributes;
            public FILETIME ftCreationTime;
            public FILETIME ftLastAccessTime;
            public FILETIME ftLastWriteTime;
            public uint nFileSizeHigh;
            public uint nFileSizeLow;
            uint dwReserved0;
            uint dwReserved1;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string cFileName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
            public string cAlternateFileName;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public struct PROPERTYKEY
        {
            public Guid FormatId { get; }
            public int PropertyId { get; }

            public PROPERTYKEY(Guid formatId, int propertyId)
            {
                FormatId = formatId;
                PropertyId = propertyId;
            }
        }

        [StructLayout(LayoutKind.Explicit)]
        public sealed class PROPVARIANT : IDisposable
        {
            [FieldOffset(0)]
            ushort _valueType;
            public VarEnum VarType
            {
                get { return (VarEnum)_valueType; }
                set { _valueType = (ushort)value; }
            }

            public bool IsNullOrEmpty => _valueType == (ushort)VarEnum.VT_EMPTY || _valueType == (ushort)VarEnum.VT_NULL;

            [FieldOffset(8)]
            IntPtr _pointer;

            [FieldOffset(8)]
            int _int32;

            [FieldOffset(8)]
            uint _uint32;

            public string StringValue => _valueType == (ushort)VarEnum.VT_LPWSTR ? Marshal.PtrToStringUni(_pointer) : null;
            public int Int32Value => _int32;
            public uint UInt32Value => _uint32;

            public PROPVARIANT() { }
            public PROPVARIANT(string value)
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                VarType = VarEnum.VT_LPWSTR;
                _pointer = Marshal.StringToCoTaskMemUni(value);
            }

            ~PROPVARIANT() => Dispose();
            public void Dispose()
            {
                NativeMethods.Ole32.PropVariantClear(this);
                GC.SuppressFinalize(this);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO
        {
            public int cbSize;
            public IntPtr hwnd;
            public NativeEnums.FLASHW dwFlags;
            public int uCount;
            public int dwTimeout;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct COMDLG_FILTERSPEC
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszSpec;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct TASKDIALOGCONFIG
        {
            public int cbSize;
            public IntPtr hwndParent;
            public IntPtr hInstance;
            public NativeEnums.TASKDIALOG_FLAGS dwFlags;
            public TaskDialogCommonButtons dwCommonButtons;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszWindowTitle;
            public TaskDialogIcon hMainIcon;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszMainInstruction;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszContent;
            public int cButtons;
            public IntPtr pButtons;
            public int nDefaultButton;
            public int cRadioButtons;
            public IntPtr pRadioButtons;
            public int nDefaultRadioButton;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszVerificationText;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszExpandedInformation;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszExpandedControlText;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszCollapsedControlText;
            public TaskDialogIcon hFooterIcon;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszFooter;
            public NativeDelegates.TaskDialogCallbackProc pfCallback;
            public IntPtr lpCallbackData;
            public int cxWidth;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct TASKDIALOG_BUTTON
        {
            public int nButtonID;
            public IntPtr pszButtonText;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MIB_TCPTABLE
        {
            public uint dwNumEntries;
            public MIB_TCPROW_OWNER_PID table;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct MIB_TCPROW_OWNER_PID
        {
            public NativeConstants.MIB_TCP_STATE state;
            public int dwLocalAddr;
            public int dwLocalPort;
            public int dwRemoteAddr;
            public int dwRemotePort;
            public int dwOwningPid;

            public IPAddress LocalAddress => new IPAddress(dwLocalAddr);
            public int LocalPort => ((dwLocalPort & 0xFF) << 8 & 0xFF00) + ((dwLocalPort & 0xFF00) >> 8);

            public IPAddress RemoteAddress => new IPAddress(dwRemoteAddr);
            public int RemotePort => ((dwRemotePort & 0xFF) << 8 & 0xFF00) + ((dwRemotePort & 0xFF00) >> 8);
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public FileAttributes dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEM_INFO
        {
            public NativeConstants.PROCESSOR_ARCHITECTURE wProcessorArchitecture;
            public ushort wReserved;
            public uint dwPageSize;
            public IntPtr lpMinimumApplicationAddress;
            public IntPtr lpMaximumApplicationAddress;
            public IntPtr dwActiveProcessorMask;
            public uint dwNumberOfProcessors;
            public uint dwProcessorType;
            public uint dwAllocationGranularity;
            public short wProcessorLevel;
            public short wProcessorRevision;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MEMORY_BASIC_INFORMATION
        {
            public IntPtr BaseAddress;
            public IntPtr AllocationBase;
            public NativeEnums.PAGE AllocationProtect;
            public int RegionSize;
            public NativeEnums.MEM State;
            public NativeEnums.PAGE Protect;
            public NativeEnums.MEM Type;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct PROCESSENTRY32
        {
            public int dwSize;
            public int cntUsage;
            public int th32ProcessID;
            public IntPtr th32DefaultHeapID;
            public int th32ModuleID;
            public int cntThreads;
            public int th32ParentProcessID;
            public int pcPriClassBase;
            public int dwFlags;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szExeFile;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WINHTTP_CURRENT_USER_IE_PROXY_CONFIG
        {
            public bool fAutoDetect;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszAutoConfigUrl;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszProxy;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszProxyBypass;
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct INTERNET_PER_CONN_OPTION_LIST
        {
            public int dwSize;
            public IntPtr pszConnection;
            public int dwOptionCount;
            public int dwOptionError;
            public INTERNET_PER_CONN_OPTION* pOptions;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct INTERNET_PER_CONN_OPTION
        {
            public NativeConstants.INTERNET_PER_CONN_OPTION dwOption;
            public INTERNET_PER_CONN_OPTION_OPTION_VALUE Value;
        }
        [StructLayout(LayoutKind.Explicit)]
        public struct INTERNET_PER_CONN_OPTION_OPTION_VALUE
        {
            [FieldOffset(0)]
            public int dwValue;
            [FieldOffset(0)]
            public IntPtr pszValue;
            [FieldOffset(0)]
            public FILETIME ftValue;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WNDCLASSEX
        {
            public int cbSize;
            public int style;
            public NativeDelegates.WindowProc lpfnWndProc;
            public int cbClsExtra;
            public int cbWndExtra;
            public IntPtr hInstance;
            public IntPtr hIcon;
            public IntPtr hCursor;
            public IntPtr hbrBackground;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszMenuName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszClassName;
            public IntPtr hIconSm;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SHDRAGIMAGE
        {
            public SIZE sizeDragImage;
            public POINT ptOffset;
            public IntPtr hbmpDragImage;
            public int crColorKey;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Size = 1044)]
        public struct DROPDESCRIPTION
        {
            public NativeConstants.DROPIMAGETYPE type;
            //public IntPtr szMessage;
            //public IntPtr szInsert;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szMessage;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szInsert;
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct WINDOWCOMPOSITIONATTRIBDATA
        {
            public NativeConstants.WINDOWCOMPOSITIONATTRIB dwAttrib;
            public void* pvData;
            public int cbData;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ACCENT_POLICY
        {
            public NativeConstants.ACCENT_STATE dwAccentState;
            public NativeEnums.ACCENT_FLAGS dwFlags;
            public int dwGradientColor;
            public int dwAnimationId;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SERVICE_STATUS_PROCESS
        {
            public NativeEnums.SERVICE_TYPE dwServiceType;
            public NativeConstants.SERVICE_STATE dwCurrentState;
            public int dwControlsAccepted;
            public int dwWin32ExitCode;
            public int dwServiceSpecificExitCode;
            public int dwCheckPoint;
            public int dwWaitHint;
            public int dwProcessId;
            public int dwServiceFlags;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ENUM_SERVICE_STATUS_PROCESS
        {
            public IntPtr lpServiceName;
            public IntPtr lpDisplayName;
            public SERVICE_STATUS_PROCESS ServiceStatusProcess;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RGBA
        {
            public byte R;
            public byte G;
            public byte B;
            public byte A;

            public Color ToColor() =>
                Color.FromArgb(A, R, G, B);
        }
    }
}
