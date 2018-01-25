using System;

namespace Sakuno.SystemLayer
{
    public static partial class NativeEnums
    {
        [Flags]
        public enum WindowStyles : uint
        {
            WS_OVERLAPPED = 0x00000000,
            WS_POPUP = 0x80000000,
            WS_CHILD = 0x40000000,
            WS_MINIMIZE = 0x20000000,
            WS_VISIBLE = 0x10000000,
            WS_DISABLED = 0x08000000,
            WS_CLIPSIBLINGS = 0x04000000,
            WS_CLIPCHILDREN = 0x02000000,
            WS_MAXIMIZE = 0x01000000,
            WS_CAPTION = 0x00C00000,
            WS_BORDER = 0x00800000,
            WS_DLGFRAME = 0x00400000,
            WS_VSCROLL = 0x00200000,
            WS_HSCROLL = 0x00100000,
            WS_SYSMENU = 0x00080000,
            WS_THICKFRAME = 0x00040000,
            WS_GROUP = 0x00020000,
            WS_TABSTOP = 0x00010000,

            WS_MINIMIZEBOX = 0x00020000,
            WS_MAXIMIZEBOX = 0x00010000,

            WS_POPUPWINDOW = WS_POPUP | WS_BORDER | WS_SYSMENU,
            WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX,
        }

        [Flags]
        public enum ExtendedWindowStyles
        {
            WS_EX_DLGMODALFRAME = 0x00000001,
            WS_EX_NOPARENTNOTIFY = 0x00000004,
            WS_EX_TOPMOST = 0x00000008,
            WS_EX_ACCEPTFILES = 0x00000010,
            WS_EX_TRANSPARENT = 0x00000020,
            WS_EX_MDICHILD = 0x00000040,
            WS_EX_TOOLWINDOW = 0x00000080,
            WS_EX_WINDOWEDGE = 0x00000100,
            WS_EX_CLIENTEDGE = 0x00000200,
            WS_EX_CONTEXTHELP = 0x00000400,
            WS_EX_RIGHT = 0x00001000,
            WS_EX_LEFT = 0x00000000,
            WS_EX_RTLREADING = 0x00002000,
            WS_EX_LTRREADING = 0x00000000,
            WS_EX_LEFTSCROLLBAR = 0x00004000,
            WS_EX_RIGHTSCROLLBAR = 0x00000000,

            WS_EX_CONTROLPARENT = 0x00010000,
            WS_EX_STATICEDGE = 0x00020000,
            WS_EX_APPWINDOW = 0x00040000,

            WS_EX_OVERLAPPEDWINDOW = WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE,
            WS_EX_PALETTEWINDOW = WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST,
            WS_EX_LAYERED = 0x00080000,
            WS_EX_NOINHERITLAYOUT = 0x00100000,
            WS_EX_LAYOUTRTL = 0x00400000,
            WS_EX_COMPOSITED = 0x02000000,
            WS_EX_NOACTIVATE = 0x08000000,
        }

        [Flags]
        public enum SetWindowPosition
        {
            SWP_NOSIZE = 0x0001,
            SWP_NOMOVE = 0x0002,
            SWP_NOZORDER = 0x0004,
            SWP_NOREDRAW = 0x0008,
            SWP_NOACTIVATE = 0x0010,
            SWP_FRAMECHANGED = 0x0020,
            SWP_SHOWWINDOW = 0x0040,
            SWP_HIDEWINDOW = 0x0080,
            SWP_NOCOPYBITS = 0x0100,
            SWP_NOOWNERZORDER = 0x0200,
            SWP_NOSENDCHANGING = 0x0400,

            SWP_DRAWFRAME = SWP_FRAMECHANGED,
            SWP_NOREPOSITION = SWP_NOOWNERZORDER,

            SWP_DEFERERASE = 0x2000,
            SWP_ASYNCWINDOWPOS = 0x4000,

            SWP_NOSIZEORMOVE = SWP_NOSIZE | SWP_NOMOVE,
        }

        [Flags]
        public enum CACHEENTRYTYPE
        {
            NORMAL_CACHE_ENTRY = 1,
            STICKY_CACHE_ENTRY = 4,
            EDITED_CACHE_ENTRY = 8,
            TRACK_OFFLINE_CACHE_ENTRY = 0x10,
            TRACK_ONLINE_CACHE_ENTRY = 0x20,
            SPARSE_CACHE_ENTRY = 0x10000,
            COOKIE_CACHE_ENTRY = 0x100000,
            URLHISTORY_CACHE_ENTRY = 0x200000
        }

        [Flags]
        public enum DWM_TNP
        {
            DWM_TNP_RECTDESTINATION = 1,
            DWM_TNP_RECTSOURCE = 2,
            DWM_TNP_OPACITY = 4,
            DWM_TNP_VISIBLE = 8,
            DWM_TNP_SOURCECLIENTAREAONLY = 16,
        }

        [Flags]
        public enum SLGP
        {
            SLGP_SHORTPATH = 1,
            SLGP_UNCPRIORITY = 2,
            SLGP_RAWPATH = 4,
            SLGP_RELATIVEPRIORITY = 8,
        }

        [Flags]
        public enum FLASHW
        {
            FLASHW_STOP,
            FLASHW_CAPTION = 1,
            FLASHW_TRAY = 2,
            FLASHW_ALL = 3,
            FLASHW_TIMER = 4,
            FLASHW_TIMERNOFG = 12,
        }

        [Flags]
        public enum SND
        {
            SND_SYNC,
            SND_ASYNC = 0x0001,
            SND_NODEFAULT = 0x0002,
            SND_MEMORY = 0x0004,
            SND_LOOP = 0x0008,
            SND_NOSTOP = 0x0010,

            SND_NOWAIT = 0x00002000,
            SND_ALIAS = 0x00010000,
            SND_ALIAS_ID = 0x00110000,
            SND_FILENAME = 0x00020000,
            SND_RESOURCE = 0x00040004,

            SND_PURGE = 0x0040,
            SND_APPLICATION = 0x0080,

            SND_SENTRY = 0X00080000,
            SND_RING = 0X00100000,
            SND_SYSTEM = 0X00200000,
        }

        [Flags]
        public enum MF
        {
            MF_BYCOMMAND,
            MF_ENABLED = 0,
            MF_GRAYED,
            MF_DISABLED = 0x0002,
            MF_BYPOSITION = 0x0400,
        }

        [Flags]
        public enum AR_STATE
        {
            AR_ENABLED,
            AR_DISABLED = 0x01,
            AR_SUPPRESSED = 0x02,
            AR_REMOTESESSION = 0x04,
            AR_MULTIMON = 0x08,
            AR_NOSENSOR = 0x10,
            AR_NOT_SUPPORTED = 0x20,
            AR_DOCKED = 0x40,
            AR_LAPTOP = 0x80,
        }

        [Flags]
        internal enum FILEOPENDIALOGOPTIONS : uint
        {
            FOS_OVERWRITEPROMPT = 0x2,
            FOS_STRICTFILETYPES = 0x4,
            FOS_NOCHANGEDIR = 0x8,
            FOS_PICKFOLDERS = 0x20,
            FOS_FORCEFILESYSTEM = 0x40,
            FOS_ALLNONSTORAGEITEMS = 0x80,
            FOS_NOVALIDATE = 0x100,
            FOS_ALLOWMULTISELECT = 0x200,
            FOS_PATHMUSTEXIST = 0x800,
            FOS_FILEMUSTEXIST = 0x1000,
            FOS_CREATEPROMPT = 0x2000,
            FOS_SHAREAWARE = 0x4000,
            FOS_NOREADONLYRETURN = 0x8000,
            FOS_NOTESTFILECREATE = 0x10000,
            FOS_HIDEMRUPLACES = 0x20000,
            FOS_HIDEPINNEDPLACES = 0x40000,
            FOS_NODEREFERENCELINKS = 0x100000,
            FOS_DONTADDTORECENT = 0x2000000,
            FOS_FORCESHOWHIDDEN = 0x10000000,
            FOS_DEFAULTNOMINIMODE = 0x20000000,
            FOS_FORCEPREVIEWPANEON = 0x40000000,
            FOS_SUPPORTSTREAMABLEITEMS = 0x80000000,
        }

        [Flags]
        public enum PROPDESC_TYPE_FLAGS : uint
        {
            PDTF_DEFAULT,
            PDTF_MULTIPLEVALUES = 0x1,
            PDTF_ISINNATE = 0x2,
            PDTF_ISGROUP = 0x4,
            PDTF_CANGROUPBY = 0x8,
            PDTF_CANSTACKBY = 0x10,
            PDTF_ISTREEPROPERTY = 0x20,
            PDTF_INCLUDEINFULLTEXTQUERY = 0x40,
            PDTF_ISVIEWABLE = 0x80,
            PDTF_ISQUERYABLE = 0x100,
            PDTF_CANBEPURGED = 0x200,
            PDTF_SEARCHRAWVALUE = 0x400,
            PDTF_ISSYSTEMPROPERTY = 0x80000000,
            PDTF_MASK_ALL = 0x800007FF,
        }
        [Flags]
        public enum PROPDESC_VIEW_FLAGS
        {
            PDVF_DEFAULT,
            PDVF_CENTERALIGN = 0x1,
            PDVF_RIGHTALIGN = 0x2,
            PDVF_BEGINNEWGROUP = 0x4,
            PDVF_FILLAREA = 0x8,
            PDVF_SORTDESCENDING = 0x10,
            PDVF_SHOWONLYIFPRESENT = 0x20,
            PDVF_SHOWBYDEFAULT = 0x40,
            PDVF_SHOWINPRIMARYLIST = 0x80,
            PDVF_SHOWINSECONDARYLIST = 0x100,
            PDVF_HIDELABEL = 0x200,
            PDVF_HIDDEN = 0x800,
            PDVF_CANWRAP = 0x1000,
            PDVF_MASK_ALL = 0x1BFF,
        }
        [Flags]
        public enum PROPDESC_FORMAT_FLAGS
        {
            PDFF_DEFAULT,
            PDFF_PREFIXNAME = 0x1,
            PDFF_FILENAME = 0x2,
            PDFF_ALWAYSKB = 0x4,
            PDFF_RESERVED_RIGHTTOLEFT = 0x8,
            PDFF_SHORTTIME = 0x10,
            PDFF_LONGTIME = 0x20,
            PDFF_HIDETIME = 0x40,
            PDFF_SHORTDATE = 0x80,
            PDFF_LONGDATE = 0x100,
            PDFF_HIDEDATE = 0x200,
            PDFF_RELATIVEDATE = 0x400,
            PDFF_USEEDITINVITATION = 0x800,
            PDFF_READONLY = 0x1000,
            PDFF_NOAUTOREADINGORDER = 0x2000,
        }

        [Flags]
        public enum ModifierKeys
        {
            MOD_NONE,
            MOD_ALT = 1,
            MOD_CONTROL = 2,
            MOD_SHIFT = 4,
            MOD_WIN = 8,
            MOD_NOREPEAT = 0x4000,
        }

        [Flags]
        public enum ProcessAccessFlags
        {
            PROCESS_TERMINATE = 0x0001,
            PROCESS_CREATE_THREAD = 0x0002,
            PROCESS_SET_SESSIONID = 0x0004,
            PROCESS_VM_OPERATION = 0x0008,
            PROCESS_VM_READ = 0x0010,
            PROCESS_VM_WRITE = 0x0020,
            PROCESS_DUP_HANDLE = 0x0040,
            PROCESS_CREATE_PROCESS = 0x0080,
            PROCESS_SET_QUOTA = 0x0100,
            PROCESS_SET_INFORMATION = 0x0200,
            PROCESS_QUERY_INFORMATION = 0x0400,
            PROCESS_SUSPEND_RESUME = 0x0800,
            PROCESS_QUERY_LIMITED_INFORMATION = 0x1000,
            PROCESS_SET_LIMITED_INFORMATION = 0x2000,
            PROCESS_ALL_ACCESS = 0x001F0FFF,
        }

        [Flags]
        internal enum TASKDIALOG_FLAGS
        {
            TDF_NONE,
            TDF_ENABLE_HYPERLINKS = 0x0001,
            TDF_USE_HICON_MAIN = 0x0002,
            TDF_USE_HICON_FOOTER = 0x0004,
            TDF_ALLOW_DIALOG_CANCELLATION = 0x0008,
            TDF_USE_COMMAND_LINKS = 0x0010,
            TDF_USE_COMMAND_LINKS_NO_ICON = 0x0020,
            TDF_EXPAND_FOOTER_AREA = 0x0040,
            TDF_EXPANDED_BY_DEFAULT = 0x0080,
            TDF_VERIFICATION_FLAG_CHECKED = 0x0100,
            TDF_SHOW_PROGRESS_BAR = 0x0200,
            TDF_SHOW_MARQUEE_PROGRESS_BAR = 0x0400,
            TDF_CALLBACK_TIMER = 0x0800,
            TDF_POSITION_RELATIVE_TO_WINDOW = 0x1000,
            TDF_RTL_LAYOUT = 0x2000,
            TDF_NO_DEFAULT_RADIO_BUTTON = 0x4000,
            TDF_CAN_BE_MINIMIZED = 0x8000,
            TDF_NO_SET_FOREGROUND = 0x00010000,
            TDF_SIZE_TO_CONTENT = 0x01000000,
        }

        [Flags]
        public enum PAGE : uint
        {
            PAGE_NOACCESS = 0x01,
            PAGE_READONLY = 0x02,
            PAGE_READWRITE = 0x04,
            PAGE_WRITECOPY = 0x08,
            PAGE_EXECUTE = 0x10,
            PAGE_EXECUTE_READ = 0x20,
            PAGE_EXECUTE_READWRITE = 0x40,
            PAGE_EXECUTE_WRITECOPY = 0x80,
            PAGE_GUARD = 0x100,
            PAGE_NOCACHE = 0x200,
            PAGE_WRITECOMBINE = 0x400,
            PAGE_REVERT_TO_FILE_MAP = 0x80000000,
        }

        [Flags]
        public enum MEM : uint
        {
            MEM_COMMIT = 0x1000,
            MEM_RESERVE = 0x2000,
            MEM_DECOMMIT = 0x4000,
            MEM_RELEASE = 0x8000,
            MEM_FREE = 0x10000,
            MEM_PRIVATE = 0x20000,
            MEM_MAPPED = 0x40000,
            MEM_RESET = 0x80000,
            MEM_TOP_DOWN = 0x100000,
            MEM_WRITE_WATCH = 0x200000,
            MEM_PHYSICAL = 0x400000,
            MEM_ROTATE = 0x800000,
            MEM_DIFFERENT_IMAGE_BASE_OK = 0x800000,
            MEM_RESET_UNDO = 0x1000000,
            MEM_LARGE_PAGES = 0x20000000,
            MEM_4MB_PAGES = 0x80000000,
        }

        [Flags]
        public enum TH32CS : uint
        {
            TH32CS_SNAPHEAPLIST = 0x00000001,
            TH32CS_SNAPPROCESS = 0x00000002,
            TH32CS_SNAPTHREAD = 0x00000004,
            TH32CS_SNAPMODULE = 0x00000008,
            TH32CS_SNAPMODULE32 = 0x00000010,
            TH32CS_SNAPALL = TH32CS_SNAPHEAPLIST | TH32CS_SNAPPROCESS | TH32CS_SNAPTHREAD | TH32CS_SNAPMODULE,
            TH32CS_SNAPNOHEAPS = 0x40000000,
            TH32CS_INHERIT = 0x80000000,
        }

        [Flags]
        public enum SET_FEATURE
        {
            SET_FEATURE_ON_THREAD = 0x00000001,
            SET_FEATURE_ON_PROCESS = 0x00000002,
            SET_FEATURE_IN_REGISTRY = 0x00000004,
            SET_FEATURE_ON_THREAD_LOCALMACHINE = 0x00000008,
            SET_FEATURE_ON_THREAD_INTRANET = 0x00000010,
            SET_FEATURE_ON_THREAD_TRUSTED = 0x00000020,
            SET_FEATURE_ON_THREAD_INTERNET = 0x00000040,
            SET_FEATURE_ON_THREAD_RESTRICTED = 0x00000080,
        }

        [Flags]
        public enum INTERNET_FLAG
        {
            INTERNET_FLAG_NONE = 0,
            INTERNET_FLAG_FROM_CACHE = 0x01000000,
            INTERNET_FLAG_OFFLINE = INTERNET_FLAG_FROM_CACHE,
            INTERNET_FLAG_MAKE_PERSISTENT = 0x02000000,
            INTERNET_FLAG_NO_CACHE_WRITE = 0x04000000,
            INTERNET_FLAG_DONT_CACHE = INTERNET_FLAG_NO_CACHE_WRITE,
            INTERNET_FLAG_ASYNC = 0x10000000,
        }

        [Flags]
        public enum INTERNET_OPTION_PER_CONN_FLAGS
        {
            PROXY_TYPE_DIRECT = 1,
            PROXY_TYPE_PROXY = 2,
            PROXY_TYPE_AUTO_PROXY_URL = 4,
            PROXY_TYPE_AUTO_DETECT = 8,
        }

        [Flags]
        internal enum PROGDLG
        {
            PROGDLG_NORMAL = 0x00000000,
            PROGDLG_MODAL = 0x00000001,
            PROGDLG_AUTOTIME = 0x00000002,
            PROGDLG_NOTIME = 0x00000004,
            PROGDLG_NOMINIMIZE = 0x00000008,
            PROGDLG_NOPROGRESSBAR = 0x00000010,
            PROGDLG_MARQUEEPROGRESS = 0x00000020,
            PROGDLG_NOCANCEL = 0x00000040,
        }

        [Flags]
        public enum DSH_FLAGS
        {
            DSH_NONE,
            DSH_ALLOWDROPDESCRIPTIONTEXT = 1,
        }

        [Flags]
        public enum ACCENT_FLAGS
        {
            DrawLeftBorder = 0x20,
            DrawTopBorder = 0x40,
            DrawRightBorder = 0x80,
            DrawBottomBorder = 0x100,
            DrawTopLeftBorder = (DrawLeftBorder | DrawTopBorder),
            DrawTopRightBorder = (DrawTopBorder | DrawRightBorder),
            DrawBottomLeftBorder = (DrawLeftBorder | DrawBottomBorder),
            DrawBottomRightBorder = (DrawRightBorder | DrawBottomBorder),
            DrawAllBorders = (DrawLeftBorder | DrawTopBorder | DrawRightBorder | DrawBottomBorder)
        }

        [Flags]
        public enum SC_MANAGER_ACCESS_RIGHTS
        {
            SC_MANAGER_CONNECT = 0x0001,
            SC_MANAGER_CREATE_SERVICE = 0x0002,
            SC_MANAGER_ENUMERATE_SERVICE = 0x0004,
            SC_MANAGER_LOCK = 0x0008,
            SC_MANAGER_QUERY_LOCK_STATUS = 0x0010,
            SC_MANAGER_MODIFY_BOOT_CONFIG = 0x0020,
        }

        [Flags]
        public enum SC_ENUM_TYPE
        {
            SC_ENUM_PROCESS_INFO,
        }

        [Flags]
        public enum SERVICE_TYPE
        {
            SERVICE_KERNEL_DRIVER = 0x01,
            SERVICE_FILE_SYSTEM_DRIVER = 0x02,
            SERVICE_FILE_ADAPTER = 0x04,
            SERVICE_FILE_RECOGNIZER_DRIVER = 0x08,
            SERVICE_DRIVER = SERVICE_KERNEL_DRIVER | SERVICE_FILE_SYSTEM_DRIVER | SERVICE_FILE_RECOGNIZER_DRIVER,
            SERVICE_WIN32_OWN_PROCESS = 0x10,
            SERVICE_WIN32_SHARE_PROCESS = 0x20,
            SERVICE_WIN32 = SERVICE_WIN32_OWN_PROCESS | SERVICE_WIN32_SHARE_PROCESS,
            SERVICE_USER_SERVICE = 0x40,
            SERVICE_USERSERVICE_INSTANCE = 0x80,
            SERVICE_USER_OWN_PROCESS = SERVICE_WIN32_OWN_PROCESS | SERVICE_USER_SERVICE,
            SERVICE_USER_SHARE_PROCESS = SERVICE_WIN32_SHARE_PROCESS | SERVICE_USER_SERVICE,
            SERVICE_INTERACTIVE_PROCESS = 0x100,
            SERVICE_TYPE_ALL = SERVICE_FILE_ADAPTER | SERVICE_DRIVER | SERVICE_WIN32 | SERVICE_USER_SERVICE | SERVICE_USERSERVICE_INSTANCE | SERVICE_INTERACTIVE_PROCESS,
        }

        [Flags]
        public enum SERVICE_STATE
        {
            SERVICE_ACTIVE = 1,
            SERVICE_INACTIVE,
            SERVICE_STATE_ALL,
        }

        [Flags]
        public enum APP_RESTART_FLAGS
        {
            RESTART_NONE,
            RESTART_NO_CRASH = 1,
            RESTART_NO_HANG = 2,
            RESTART_NO_PATCH = 4,
            RESTART_NO_REBOOT = 8,
        }
    }
}
