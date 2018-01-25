﻿using System;

namespace Sakuno.SystemLayer
{
    public static partial class NativeConstants
    {
        public enum ShowCommand
        {
            SW_HIDE,
            SW_SHOWNORMAL,
            SW_NORMAL = 1,
            SW_SHOWMINIMIZED,
            SW_SHOWMAXIMIZED,
            SW_MAXIMIZE = 3,
            SW_SHOWNOACTIVATE,
            SW_SHOW,
            SW_MINIMIZE,
            SW_SHOWMINNOACTIVE,
            SW_SHOWNA,
            SW_RESTORE,
            SW_SHOWDEFAULT,
            SW_FORCEMINIMIZE,
            SW_MAX = 11
        }

        public enum GetWindowLong
        {
            GWL_WNDPROC = -4,
            GWL_HINSTANCE = -6,
            GWL_HWNDPARENT = -8,
            GWL_STYLE = -16,
            GWL_EXSTYLE = -20,
            GWL_USERDATA = -21,
            GWL_ID = -12,
        }
        public enum GetClassLong
        {
            GCLP_MENUNAME = -8,
            GCLP_HBRBACKGROUND = -10,
            GCLP_HCURSOR = -12,
            GCLP_HICON = -14,
            GCLP_HMODULE = -16,
            GCL_CBWNDEXTRA = -18,
            GCL_CBCLSEXTRA = -20,
            GCLP_WNDPROC = -24,
            GCL_STYLE = -26,
            GCLP_HICONSM = -34,
            GCW_ATOM = -32
        }

        public enum WindowMessage
        {
            WM_NULL = 0x0000,
            WM_CREATE = 0x0001,
            WM_DESTROY = 0x0002,
            WM_MOVE = 0x0003,
            WM_SIZE = 0x0005,
            WM_ACTIVATE = 0x0006,
            WM_SETFOCUS = 0x0007,
            WM_KILLFOCUS = 0x0008,
            WM_ENABLE = 0x000A,
            WM_SETREDRAW = 0x000B,
            WM_SETTEXT = 0x000C,
            WM_GETTEXT = 0x000D,
            WM_GETTEXTLENGTH = 0x000E,
            WM_PAINT = 0x000F,
            WM_CLOSE = 0x0010,
            WM_QUERYENDSESSION = 0x0011,
            WM_QUERYOPEN = 0x0013,
            WM_ENDSESSION = 0x0016,
            WM_QUIT = 0x0012,
            WM_ERASEBKGND = 0x0014,
            WM_SYSCOLORCHANGE = 0x0015,
            WM_SHOWWINDOW = 0x0018,
            WM_WININICHANGE = 0x001A,
            WM_SETTINGCHANGE = WM_WININICHANGE,
            WM_DEVMODECHANGE = 0x001B,
            WM_ACTIVATEAPP = 0x001C,
            WM_FONTCHANGE = 0x001D,
            WM_TIMECHANGE = 0x001E,
            WM_CANCELMODE = 0x001F,
            WM_SETCURSOR = 0x0020,
            WM_MOUSEACTIVATE = 0x0021,
            WM_CHILDACTIVATE = 0x0022,
            WM_QUEUESYNC = 0x0023,
            WM_GETMINMAXINFO = 0x0024,
            WM_PAINTICON = 0x0026,
            WM_ICONERASEBKGND = 0x0027,
            WM_NEXTDLGCTL = 0x0028,
            WM_SPOOLERSTATUS = 0x002A,
            WM_DRAWITEM = 0x002B,
            WM_MEASUREITEM = 0x002C,
            WM_DELETEITEM = 0x002D,
            WM_VKEYTOITEM = 0x002E,
            WM_CHARTOITEM = 0x002F,
            WM_SETFONT = 0x0030,
            WM_GETFONT = 0x0031,
            WM_SETHOTKEY = 0x0032,
            WM_GETHOTKEY = 0x0033,
            WM_QUERYDRAGICON = 0x0037,
            WM_COMPAREITEM = 0x0039,
            WM_GETOBJECT = 0x003D,
            WM_COMPACTING = 0x0041,
            WM_COMMNOTIFY = 0x0044,
            WM_WINDOWPOSCHANGING = 0x0046,
            WM_WINDOWPOSCHANGED = 0x0047,
            WM_POWER = 0x0048,
            WM_COPYDATA = 0x004A,
            WM_CANCELJOURNAL = 0x004B,
            WM_NOTIFY = 0x004E,
            WM_INPUTLANGCHANGEREQUEST = 0x0050,
            WM_INPUTLANGCHANGE = 0x0051,
            WM_TCARD = 0x0052,
            WM_HELP = 0x0053,
            WM_USERCHANGED = 0x0054,
            WM_NOTIFYFORMAT = 0x0055,
            WM_CONTEXTMENU = 0x007B,
            WM_STYLECHANGING = 0x007C,
            WM_STYLECHANGED = 0x007D,
            WM_DISPLAYCHANGE = 0x007E,
            WM_GETICON = 0x007F,
            WM_SETICON = 0x0080,
            WM_NCCREATE = 0x0081,
            WM_NCDESTROY = 0x0082,
            WM_NCCALCSIZE = 0x0083,
            WM_NCHITTEST = 0x0084,
            WM_NCPAINT = 0x0085,
            WM_NCACTIVATE = 0x0086,
            WM_GETDLGCODE = 0x0087,
            WM_SYNCPAINT = 0x0088,
            WM_NCMOUSEMOVE = 0x00A0,
            WM_NCLBUTTONDOWN = 0x00A1,
            WM_NCLBUTTONUP = 0x00A2,
            WM_NCLBUTTONDBLCLK = 0x00A3,
            WM_NCRBUTTONDOWN = 0x00A4,
            WM_NCRBUTTONUP = 0x00A5,
            WM_NCRBUTTONDBLCLK = 0x00A6,
            WM_NCMBUTTONDOWN = 0x00A7,
            WM_NCMBUTTONUP = 0x00A8,
            WM_NCMBUTTONDBLCLK = 0x00A9,
            WM_NCXBUTTONDOWN = 0x00AB,
            WM_NCXBUTTONUP = 0x00AC,
            WM_NCXBUTTONDBLCLK = 0x00AD,
            WM_INPUT = 0x00FF,
            WM_KEYFIRST = 0x0100,
            WM_KEYDOWN = 0x0100,
            WM_KEYUP = 0x0101,
            WM_CHAR = 0x0102,
            WM_DEADCHAR = 0x0103,
            WM_SYSKEYDOWN = 0x0104,
            WM_SYSKEYUP = 0x0105,
            WM_SYSCHAR = 0x0106,
            WM_SYSDEADCHAR = 0x0107,
            WM_UNICHAR = 0x0109,
            WM_KEYLAST = 0x0108,
            WM_IME_STARTCOMPOSITION = 0x010D,
            WM_IME_ENDCOMPOSITION = 0x010E,
            WM_IME_COMPOSITION = 0x010F,
            WM_IME_KEYLAST = 0x010F,
            WM_INITDIALOG = 0x0110,
            WM_COMMAND = 0x0111,
            WM_SYSCOMMAND = 0x0112,
            WM_TIMER = 0x0113,
            WM_HSCROLL = 0x0114,
            WM_VSCROLL = 0x0115,
            WM_INITMENU = 0x0116,
            WM_INITMENUPOPUP = 0x0117,
            WM_MENUSELECT = 0x011F,
            WM_MENUCHAR = 0x0120,
            WM_ENTERIDLE = 0x0121,
            WM_MENURBUTTONUP = 0x0122,
            WM_MENUDRAG = 0x0123,
            WM_MENUGETOBJECT = 0x0124,
            WM_UNINITMENUPOPUP = 0x0125,
            WM_MENUCOMMAND = 0x0126,
            WM_CHANGEUISTATE = 0x0127,
            WM_UPDATEUISTATE = 0x0128,
            WM_QUERYUISTATE = 0x0129,
            WM_CTLCOLOR = 0x0019,
            WM_CTLCOLORMSGBOX = 0x0132,
            WM_CTLCOLOREDIT = 0x0133,
            WM_CTLCOLORLISTBOX = 0x0134,
            WM_CTLCOLORBTN = 0x0135,
            WM_CTLCOLORDLG = 0x0136,
            WM_CTLCOLORSCROLLBAR = 0x0137,
            WM_CTLCOLORSTATIC = 0x0138,
            WM_MOUSEFIRST = 0x0200,
            WM_MOUSEMOVE = 0x0200,
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_LBUTTONDBLCLK = 0x0203,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205,
            WM_RBUTTONDBLCLK = 0x0206,
            WM_MBUTTONDOWN = 0x0207,
            WM_MBUTTONUP = 0x0208,
            WM_MBUTTONDBLCLK = 0x0209,
            WM_MOUSEWHEEL = 0x020A,
            WM_XBUTTONDOWN = 0x020B,
            WM_XBUTTONUP = 0x020C,
            WM_XBUTTONDBLCLK = 0x020D,
            WM_MOUSELAST = 0x020D,
            WM_MOUSEHWHEEL = 0x020E,
            WM_PARENTNOTIFY = 0x0210,
            WM_ENTERMENULOOP = 0x0211,
            WM_EXITMENULOOP = 0x0212,
            WM_NEXTMENU = 0x0213,
            WM_SIZING = 0x0214,
            WM_CAPTURECHANGED = 0x0215,
            WM_MOVING = 0x0216,
            WM_POWERBROADCAST = 0x0218,
            WM_DEVICECHANGE = 0x0219,
            WM_MDICREATE = 0x0220,
            WM_MDIDESTROY = 0x0221,
            WM_MDIACTIVATE = 0x0222,
            WM_MDIRESTORE = 0x0223,
            WM_MDINEXT = 0x0224,
            WM_MDIMAXIMIZE = 0x0225,
            WM_MDITILE = 0x0226,
            WM_MDICASCADE = 0x0227,
            WM_MDIICONARRANGE = 0x0228,
            WM_MDIGETACTIVE = 0x0229,
            WM_MDISETMENU = 0x0230,
            WM_ENTERSIZEMOVE = 0x0231,
            WM_EXITSIZEMOVE = 0x0232,
            WM_DROPFILES = 0x0233,
            WM_MDIREFRESHMENU = 0x0234,
            WM_IME_SETCONTEXT = 0x0281,
            WM_IME_NOTIFY = 0x0282,
            WM_IME_CONTROL = 0x0283,
            WM_IME_COMPOSITIONFULL = 0x0284,
            WM_IME_SELECT = 0x0285,
            WM_IME_CHAR = 0x0286,
            WM_IME_REQUEST = 0x0288,
            WM_IME_KEYDOWN = 0x0290,
            WM_IME_KEYUP = 0x0291,
            WM_MOUSEHOVER = 0x02A1,
            WM_MOUSELEAVE = 0x02A3,
            WM_NCMOUSELEAVE = 0x02A2,
            WM_WTSSESSION_CHANGE = 0x02B1,
            WM_TABLET_FIRST = 0x02C0,
            WM_TABLET_LAST = 0x02DF,
            WM_DPICHANGED = 0x02E0,
            WM_CUT = 0x0300,
            WM_COPY = 0x0301,
            WM_PASTE = 0x0302,
            WM_CLEAR = 0x0303,
            WM_UNDO = 0x0304,
            WM_RENDERFORMAT = 0x0305,
            WM_RENDERALLFORMATS = 0x0306,
            WM_DESTROYCLIPBOARD = 0x0307,
            WM_DRAWCLIPBOARD = 0x0308,
            WM_PAINTCLIPBOARD = 0x0309,
            WM_VSCROLLCLIPBOARD = 0x030A,
            WM_SIZECLIPBOARD = 0x030B,
            WM_ASKCBFORMATNAME = 0x030C,
            WM_CHANGECBCHAIN = 0x030D,
            WM_HSCROLLCLIPBOARD = 0x030E,
            WM_QUERYNEWPALETTE = 0x030F,
            WM_PALETTEISCHANGING = 0x0310,
            WM_PALETTECHANGED = 0x0311,
            WM_HOTKEY = 0x0312,
            WM_PRINT = 0x0317,
            WM_PRINTCLIENT = 0x0318,
            WM_APPCOMMAND = 0x0319,
            WM_THEMECHANGED = 0x031A,
            WM_DWMCOMPOSITIONCHANGED = 0x031E,
            WM_DWMNCRENDERINGCHANGED = 0x031F,
            WM_DWMCOLORIZATIONCOLORCHANGED = 0x320,
            WM_HANDHELDFIRST = 0x0358,
            WM_HANDHELDLAST = 0x035F,
            WM_AFXFIRST = 0x0360,
            WM_AFXLAST = 0x037F,
            WM_PENWINFIRST = 0x0380,
            WM_PENWINLAST = 0x038F,
            WM_USER = 0x0400,
            WM_REFLECT = 0x2000,
            WM_APP = 0x8000,

            TDM_NAVIGATE_PAGE = WM_USER + 101,
            TDM_CLICK_BUTTON = WM_USER + 102,
            TDM_SET_MARQUEE_PROGRESS_BAR = WM_USER + 103,
            TDM_SET_PROGRESS_BAR_STATE = WM_USER + 104,
            TDM_SET_PROGRESS_BAR_RANGE = WM_USER + 105,
            TDM_SET_PROGRESS_BAR_POS = WM_USER + 106,
            TDM_SET_PROGRESS_BAR_MARQUEE = WM_USER + 107,
            TDM_SET_ELEMENT_TEXT = WM_USER + 108,
            TDM_CLICK_RADIO_BUTTON = WM_USER + 110,
            TDM_ENABLE_BUTTON = WM_USER + 111,
            TDM_ENABLE_RADIO_BUTTON = WM_USER + 112,
            TDM_CLICK_VERIFICATION = WM_USER + 113,
            TDM_UPDATE_ELEMENT_TEXT = WM_USER + 114,
            TDM_SET_BUTTON_ELEVATION_REQUIRED_STATE = WM_USER + 115,
            TDM_UPDATE_ICON = WM_USER + 116,
        }

        public enum WindowMessageSizing
        {
            WMSZ_LEFT = 1,
            WMSZ_RIGHT,
            WMSZ_TOP,
            WMSZ_TOPLEFT,
            WMSZ_TOPRIGHT,
            WMSZ_BOTTOM,
            WMSZ_BOTTOMLEFT,
            WMSZ_BOTTOMRIGHT,
        }

        public enum SystemCommand
        {
            SC_SIZE = 0xF000,
            SC_MOVE = 0xF010,
            SC_MINIMIZE = 0xF020,
            SC_MAXIMIZE = 0xF030,
            SC_NEXTWINDOW = 0xF040,
            SC_PREVWINDOW = 0xF050,
            SC_CLOSE = 0xF060,
            SC_VSCROLL = 0xF070,
            SC_HSCROLL = 0xF080,
            SC_MOUSEMENU = 0xF090,
            SC_KEYMENU = 0xF100,
            SC_ARRANGE = 0xF110,
            SC_RESTORE = 0xF120,
            SC_TASKLIST = 0xF130,
            SC_SCREENSAVE = 0xF140,
            SC_HOTKEY = 0xF150,
            SC_DEFAULT = 0xF160,
            SC_MONITORPOWER = 0xF170,
            SC_CONTEXTHELP = 0xF180,
            SC_SEPARATOR = 0xF00F,
            SCF_ISSECURE = 0x00000001,
        }

        public enum HitTest
        {
            HTERROR = -2,
            HTTRANSPARENT = -1,
            HTNOWHERE = 0,
            HTCLIENT = 1,
            HTCAPTION = 2,
            HTSYSMENU = 3,
            HTGROWBOX = 4,
            HTSIZE = HTGROWBOX,
            HTMENU = 5,
            HTHSCROLL = 6,
            HTVSCROLL = 7,
            HTMINBUTTON = 8,
            HTMAXBUTTON = 9,
            HTLEFT = 10,
            HTRIGHT = 11,
            HTTOP = 12,
            HTTOPLEFT = 13,
            HTTOPRIGHT = 14,
            HTBOTTOM = 15,
            HTBOTTOMLEFT = 16,
            HTBOTTOMRIGHT = 17,
            HTBORDER = 18,
            HTREDUCE = HTMINBUTTON,
            HTZOOM = HTMAXBUTTON,
            HTSIZEFIRST = HTLEFT,
            HTSIZELAST = HTBOTTOMRIGHT,
            HTOBJECT = 19,
            HTCLOSE = 20,
            HTHELP = 21,
        }

        public enum MouseActivate
        {
            MA_ACTIVATE = 1,
            MA_ACTIVATEANDEAT,
            MA_NOACTIVATE,
            MA_NOACTIVATEANDEAT,
        }

        public static readonly IntPtr HWND_TOP = IntPtr.Zero;
        public static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        public static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        public static readonly IntPtr HWND_MESSAGE = new IntPtr(-3);

        public enum GetWindow
        {
            GW_HWNDFIRST,
            GW_HWNDLAST,
            GW_HWNDNEXT,
            GW_HWNDPREV,
            GW_OWNER,
            GW_CHILD,
            GW_ENABLEDPOPUP,
            GW_MAX,
        }

        public enum SPI
        {
            SPI_GETBEEP = 0x0001,
            SPI_SETBEEP = 0x0002,
            SPI_GETMOUSE = 0x0003,
            SPI_SETMOUSE = 0x0004,
            SPI_GETBORDER = 0x0005,
            SPI_SETBORDER = 0x0006,
            SPI_GETKEYBOARDSPEED = 0x000A,
            SPI_SETKEYBOARDSPEED = 0x000B,
            SPI_LANGDRIVER = 0x000C,
            SPI_ICONHORIZONTALSPACING = 0x000D,
            SPI_GETSCREENSAVETIMEOUT = 0x000E,
            SPI_SETSCREENSAVETIMEOUT = 0x000F,
            SPI_GETSCREENSAVEACTIVE = 0x0010,
            SPI_SETSCREENSAVEACTIVE = 0x0011,
            SPI_GETGRIDGRANULARITY = 0x0012,
            SPI_SETGRIDGRANULARITY = 0x0013,
            SPI_SETDESKWALLPAPER = 0x0014,
            SPI_SETDESKPATTERN = 0x0015,
            SPI_GETKEYBOARDDELAY = 0x0016,
            SPI_SETKEYBOARDDELAY = 0x0017,
            SPI_ICONVERTICALSPACING = 0x0018,
            SPI_GETICONTITLEWRAP = 0x0019,
            SPI_SETICONTITLEWRAP = 0x001A,
            SPI_GETMENUDROPALIGNMENT = 0x001B,
            SPI_SETMENUDROPALIGNMENT = 0x001C,
            SPI_SETDOUBLECLKWIDTH = 0x001D,
            SPI_SETDOUBLECLKHEIGHT = 0x001E,
            SPI_GETICONTITLELOGFONT = 0x001F,
            SPI_SETDOUBLECLICKTIME = 0x0020,
            SPI_SETMOUSEBUTTONSWAP = 0x0021,
            SPI_SETICONTITLELOGFONT = 0x0022,
            SPI_GETFASTTASKSWITCH = 0x0023,
            SPI_SETFASTTASKSWITCH = 0x0024,
            SPI_SETDRAGFULLWINDOWS = 0x0025,
            SPI_GETDRAGFULLWINDOWS = 0x0026,
            SPI_GETNONCLIENTMETRICS = 0x0029,
            SPI_SETNONCLIENTMETRICS = 0x002A,
            SPI_GETMINIMIZEDMETRICS = 0x002B,
            SPI_SETMINIMIZEDMETRICS = 0x002C,
            SPI_GETICONMETRICS = 0x002D,
            SPI_SETICONMETRICS = 0x002E,
            SPI_SETWORKAREA = 0x002F,
            SPI_GETWORKAREA = 0x0030,
            SPI_SETPENWINDOWS = 0x0031,
            SPI_SETHIGHCONTRAST = 0x0043,
            SPI_GETKEYBOARDPREF = 0x0044,
            SPI_SETKEYBOARDPREF = 0x0045,
            SPI_GETSCREENREADER = 0x0046,
            SPI_SETSCREENREADER = 0x0047,
            SPI_GETANIMATION = 0x0048,
            SPI_SETANIMATION = 0x0049,
            SPI_GETFONTSMOOTHING = 0x004A,
            SPI_SETFONTSMOOTHING = 0x004B,
            SPI_SETDRAGWIDTH = 0x004C,
            SPI_SETDRAGHEIGHT = 0x004D,
            SPI_SETHANDHELD = 0x004E,
            SPI_GETLOWPOWERTIMEOUT = 0x004F,
            SPI_GETPOWEROFFTIMEOUT = 0x0050,
            SPI_SETLOWPOWERTIMEOUT = 0x0051,
            SPI_SETPOWEROFFTIMEOUT = 0x0052,
            SPI_GETLOWPOWERACTIVE = 0x0053,
            SPI_GETPOWEROFFACTIVE = 0x0054,
            SPI_SETLOWPOWERACTIVE = 0x0055,
            SPI_SETPOWEROFFACTIVE = 0x0056,
            SPI_SETCURSORS = 0x0057,
            SPI_SETICONS = 0x0058,
            SPI_GETDEFAULTINPUTLANG = 0x0059,
            SPI_SETDEFAULTINPUTLANG = 0x005A,
            SPI_SETLANGTOGGLE = 0x005B,
            SPI_GETWINDOWSEXTENSION = 0x005C,
            SPI_SETMOUSETRAILS = 0x005D,
            SPI_GETMOUSETRAILS = 0x005E,
            SPI_SETSCREENSAVERRUNNING = 0x0061,
            SPI_SCREENSAVERRUNNING = SPI_SETSCREENSAVERRUNNING,
            SPI_GETFILTERKEYS = 0x0032,
            SPI_SETFILTERKEYS = 0x0033,
            SPI_GETTOGGLEKEYS = 0x0034,
            SPI_SETTOGGLEKEYS = 0x0035,
            SPI_GETMOUSEKEYS = 0x0036,
            SPI_SETMOUSEKEYS = 0x0037,
            SPI_GETSHOWSOUNDS = 0x0038,
            SPI_SETSHOWSOUNDS = 0x0039,
            SPI_GETSTICKYKEYS = 0x003A,
            SPI_SETSTICKYKEYS = 0x003B,
            SPI_GETACCESSTIMEOUT = 0x003C,
            SPI_SETACCESSTIMEOUT = 0x003D,
            SPI_GETSERIALKEYS = 0x003E,
            SPI_SETSERIALKEYS = 0x003F,
            SPI_GETSOUNDSENTRY = 0x0040,
            SPI_SETSOUNDSENTRY = 0x0041,
            SPI_GETSNAPTODEFBUTTON = 0x005F,
            SPI_SETSNAPTODEFBUTTON = 0x0060,
            SPI_GETMOUSEHOVERWIDTH = 0x0062,
            SPI_SETMOUSEHOVERWIDTH = 0x0063,
            SPI_GETMOUSEHOVERHEIGHT = 0x0064,
            SPI_SETMOUSEHOVERHEIGHT = 0x0065,
            SPI_GETMOUSEHOVERTIME = 0x0066,
            SPI_SETMOUSEHOVERTIME = 0x0067,
            SPI_GETWHEELSCROLLLINES = 0x0068,
            SPI_SETWHEELSCROLLLINES = 0x0069,
            SPI_GETMENUSHOWDELAY = 0x006A,
            SPI_SETMENUSHOWDELAY = 0x006B,
            SPI_GETSHOWIMEUI = 0x006E,
            SPI_SETSHOWIMEUI = 0x006F,
            SPI_GETMOUSESPEED = 0x0070,
            SPI_SETMOUSESPEED = 0x0071,
            SPI_GETSCREENSAVERRUNNING = 0x0072,
            SPI_GETDESKWALLPAPER = 0x0073,
            SPI_GETACTIVEWINDOWTRACKING = 0x1000,
            SPI_SETACTIVEWINDOWTRACKING = 0x1001,
            SPI_GETMENUANIMATION = 0x1002,
            SPI_SETMENUANIMATION = 0x1003,
            SPI_GETCOMBOBOXANIMATION = 0x1004,
            SPI_SETCOMBOBOXANIMATION = 0x1005,
            SPI_GETLISTBOXSMOOTHSCROLLING = 0x1006,
            SPI_SETLISTBOXSMOOTHSCROLLING = 0x1007,
            SPI_GETGRADIENTCAPTIONS = 0x1008,
            SPI_SETGRADIENTCAPTIONS = 0x1009,
            SPI_GETKEYBOARDCUES = 0x100A,
            SPI_SETKEYBOARDCUES = 0x100B,
            SPI_GETMENUUNDERLINES = SPI_GETKEYBOARDCUES,
            SPI_SETMENUUNDERLINES = SPI_SETKEYBOARDCUES,
            SPI_GETACTIVEWNDTRKZORDER = 0x100C,
            SPI_SETACTIVEWNDTRKZORDER = 0x100D,
            SPI_GETHOTTRACKING = 0x100E,
            SPI_SETHOTTRACKING = 0x100F,
            SPI_GETMENUFADE = 0x1012,
            SPI_SETMENUFADE = 0x1013,
            SPI_GETSELECTIONFADE = 0x1014,
            SPI_SETSELECTIONFADE = 0x1015,
            SPI_GETTOOLTIPANIMATION = 0x1016,
            SPI_SETTOOLTIPANIMATION = 0x1017,
            SPI_GETTOOLTIPFADE = 0x1018,
            SPI_SETTOOLTIPFADE = 0x1019,
            SPI_GETCURSORSHADOW = 0x101A,
            SPI_SETCURSORSHADOW = 0x101B,
            SPI_GETMOUSESONAR = 0x101C,
            SPI_SETMOUSESONAR = 0x101D,
            SPI_GETMOUSECLICKLOCK = 0x101E,
            SPI_SETMOUSECLICKLOCK = 0x101F,
            SPI_GETMOUSEVANISH = 0x1020,
            SPI_SETMOUSEVANISH = 0x1021,
            SPI_GETFLATMENU = 0x1022,
            SPI_SETFLATMENU = 0x1023,
            SPI_GETDROPSHADOW = 0x1024,
            SPI_SETDROPSHADOW = 0x1025,
            SPI_GETBLOCKSENDINPUTRESETS = 0x1026,
            SPI_SETBLOCKSENDINPUTRESETS = 0x1027,
            SPI_GETUIEFFECTS = 0x103E,
            SPI_SETUIEFFECTS = 0x103F,
            SPI_GETFOREGROUNDLOCKTIMEOUT = 0x2000,
            SPI_SETFOREGROUNDLOCKTIMEOUT = 0x2001,
            SPI_GETACTIVEWNDTRKTIMEOUT = 0x2002,
            SPI_SETACTIVEWNDTRKTIMEOUT = 0x2003,
            SPI_GETFOREGROUNDFLASHCOUNT = 0x2004,
            SPI_SETFOREGROUNDFLASHCOUNT = 0x2005,
            SPI_GETCARETWIDTH = 0x2006,
            SPI_SETCARETWIDTH = 0x2007,
            SPI_GETMOUSECLICKLOCKTIME = 0x2008,
            SPI_SETMOUSECLICKLOCKTIME = 0x2009,
            SPI_GETFONTSMOOTHINGTYPE = 0x200A,
            SPI_SETFONTSMOOTHINGTYPE = 0x200B,
            SPI_GETFONTSMOOTHINGCONTRAST = 0x200C,
            SPI_SETFONTSMOOTHINGCONTRAST = 0x200D,
            SPI_GETFOCUSBORDERWIDTH = 0x200E,
            SPI_SETFOCUSBORDERWIDTH = 0x200F,
            SPI_GETFOCUSBORDERHEIGHT = 0x2010,
            SPI_SETFOCUSBORDERHEIGHT = 0x2011,
            SPI_GETFONTSMOOTHINGORIENTATION = 0x2012,
            SPI_SETFONTSMOOTHINGORIENTATION = 0x2013,
        }

        public enum DeviceCap
        {
            DRIVERVERSION = 0,
            TECHNOLOGY = 2,
            HORZSIZE = 4,
            VERTSIZE = 6,
            HORZRES = 8,
            VERTRES = 10,
            BITSPIXEL = 12,
            PLANES = 14,
            NUMBRUSHES = 16,
            NUMPENS = 18,
            NUMMARKERS = 20,
            NUMFONTS = 22,
            NUMCOLORS = 24,
            PDEVICESIZE = 26,
            CURVECAPS = 28,
            LINECAPS = 30,
            POLYGONALCAPS = 32,
            TEXTCAPS = 34,
            CLIPCAPS = 36,
            RASTERCAPS = 38,
            ASPECTX = 40,
            ASPECTY = 42,
            ASPECTXY = 44,
            SHADEBLENDCAPS = 45,
            LOGPIXELSX = 88,
            LOGPIXELSY = 90,
            SIZEPALETTE = 104,
            NUMRESERVED = 106,
            COLORRES = 108,
            PHYSICALWIDTH = 110,
            PHYSICALHEIGHT = 111,
            PHYSICALOFFSETX = 112,
            PHYSICALOFFSETY = 113,
            SCALINGFACTORX = 114,
            SCALINGFACTORY = 115,
            VREFRESH = 116,
            DESKTOPVERTRES = 117,
            DESKTOPHORZRES = 118,
            BLTALIGNMENT = 119
        }

        public enum PBT
        {
            PBT_APMQUERYSUSPEND = 0x0000,
            PBT_APMQUERYSTANDBY = 0x0001,
            PBT_APMQUERYSUSPENDFAILED = 0x0002,
            PBT_APMQUERYSTANDBYFAILED = 0x0003,
            PBT_APMSUSPEND = 0x0004,
            PBT_APMSTANDBY = 0x0005,
            PBT_APMRESUMECRITICAL = 0x0006,
            PBT_APMRESUMESUSPEND = 0x0007,
            PBT_APMRESUMESTANDBY = 0x0008,
            PBT_APMBATTERYLOW = 0x0009,
            PBT_APMPOWERSTATUSCHANGE = 0x000A,
            PBT_APMOEMEVENT = 0x000B,
            PBT_APMRESUMEAUTOMATIC = 0x0012,
            PBT_POWERSETTINGCHANGE = 0x8013,
        }

        public enum MFW
        {
            MONITOR_DEFAULTTONULL,
            MONITOR_DEFAULTTOPRIMARY,
            MONITOR_DEFAULTTONEAREST,
        }

        public enum POWER_INFORMATION_LEVEL
        {
            SystemPowerPolicyAc,
            SystemPowerPolicyDc,
            VerifySystemPolicyAc,
            VerifySystemPolicyDc,
            SystemPowerCapabilities,
            SystemBatteryState,
            SystemPowerStateHandler,
            ProcessorStateHandler,
            SystemPowerPolicyCurrent,
            AdministratorPowerPolicy,
            SystemReserveHiberFile,
            ProcessorInformation,
            SystemPowerInformation,
            ProcessorStateHandler2,
            LastWakeTime,
            LastSleepTime,
            SystemExecutionState,
            SystemPowerStateNotifyHandler,
            ProcessorPowerPolicyAc,
            ProcessorPowerPolicyDc,
            VerifyProcessorPowerPolicyAc,
            VerifyProcessorPowerPolicyDc,
            ProcessorPowerPolicyCurrent,
            SystemPowerStateLogging,
            SystemPowerLoggingEntry,
            SetPowerSettingValue,
            NotifyUserPowerSetting,
            PowerInformationLevelUnused0,
            PowerInformationLevelUnused1,
            SystemVideoState,
            TraceApplicationPowerMessage,
            TraceApplicationPowerMessageEnd,
            ProcessorPerfStates,
            ProcessorIdleStates,
            ProcessorCap,
            SystemWakeSource,
            SystemHiberFileInformation,
            TraceServicePowerMessage,
            ProcessorLoad,
            PowerShutdownNotification,
            MonitorCapabilities,
            SessionPowerInit,
            SessionDisplayState,
            PowerRequestCreate,
            PowerRequestAction,
            GetPowerRequestList,
            ProcessorInformationEx,
            NotifyUserModeLegacyPowerEvent,
            GroupPark,
            ProcessorIdleDomains,
            WakeTimerList,
            SystemHiberFileSize,
            PowerInformationLevelMaximum,
        }

        public enum PROPENUMTYPE
        {
            PET_DISCRETEVALUE,
            PET_RANGEDVALUE,
            PET_DEFAULTVALUE,
            PET_ENDRANGE,
        }
        public enum PROPDESC_DISPLAYTYPE
        {
            PDDT_STRING,
            PDDT_NUMBER,
            PDDT_BOOLEAN,
            PDDT_DATETIME,
            PDDT_ENUMERATED,
        }
        public enum PROPDESC_GROUPING_RANGE
        {
            PDGR_DISCRETE,
            PDGR_ALPHANUMERIC,
            PDGR_SIZE,
            PDGR_DYNAMIC,
            PDGR_DATE,
            PDGR_PERCENT,
            PDGR_ENUMERATED,
        }
        public enum PROPDESC_SORTDESCRIPTION
        {
            PDSD_GENERAL,
            PDSD_A_Z,
            PDSD_LOWEST_HIGHEST,
            PDSD_SMALLEST_BIGGEST,
            PDSD_OLDEST_NEWEST,
        }
        public enum PROPDESC_RELATIVEDESCRIPTION_TYPE
        {
            PDRDT_GENERAL,
            PDRDT_DATE,
            PDRDT_SIZE,
            PDRDT_COUNT,
            PDRDT_REVISION,
            PDRDT_LENGTH,
            PDRDT_DURATION,
            PDRDT_SPEED,
            PDRDT_RATE,
            PDRDT_RATING,
            PDRDT_PRIORITY
        }
        public enum PROPDESC_AGGREGATION_TYPE
        {
            PDAT_DEFAULT,
            PDAT_FIRST,
            PDAT_SUM,
            PDAT_AVERAGE,
            PDAT_DATERANGE,
            PDAT_UNION,
            PDAT_MAX,
            PDAT_MIN,
        }
        public enum PROPDESC_CONDITION_TYPE
        {
            PDCOT_NONE,
            PDCOT_STRING,
            PDCOT_SIZE,
            PDCOT_DATETIME,
            PDCOT_BOOLEAN,
            PDCOT_NUMBER,
        }

        public enum CONDITION_OPERATION
        {
            COP_IMPLICIT,
            COP_EQUAL,
            COP_NOTEQUAL,
            COP_LESSTHAN,
            COP_GREATERTHAN,
            COP_LESSTHANOREQUAL,
            COP_GREATERTHANOREQUAL,
            COP_VALUE_STARTSWITH,
            COP_VALUE_ENDSWITH,
            COP_VALUE_CONTAINS,
            COP_VALUE_NOTCONTAINS,
            COP_DOSWILDCARDS,
            COP_WORD_EQUAL,
            COP_WORD_STARTSWITH,
            COP_APPLICATION_SPECIFIC,
        }

        internal enum TASKDIALOG_NOTIFICATIONS
        {
            CREATED,
            NAVIGATED,
            BUTTONCLICKED,
            HYPERLINKCLICKED,
            TIMER,
            DESTROYED,
            RADIOBUTTONCLICKED,
            DIALOGCONSTRUCTED,
            VERIFICATIONCLICKED,
            HELP,
            EXPANDOBUTTONCLICKED,
        }

        internal enum TASKDIALOG_ELEMENTS
        {
            TDE_CONTENT,
            TDE_EXPANDED_INFORMATION,
            TDE_FOOTER,
            TDE_MAIN_INSTRUCTION,
        }

        internal enum TASKDIALOG_ICON_ELEMENTS
        {
            TDIE_ICON_MAIN,
            TDIE_ICON_FOOTER,
        }

        public enum SystemMetrics
        {
            SM_CXSCREEN,
            SM_CYSCREEN,
            SM_CXVSCROLL,
            SM_CYHSCROLL,
            SM_CYCAPTION,
            SM_CXBORDER,
            SM_CYBORDER,
            SM_CXFIXEDFRAME,
            SM_CYFIXEDFRAME,
            SM_CYVTHUMB,
            SM_CXHTHUMB,
            SM_CXICON,
            SM_CYICON,
            SM_CXCURSOR,
            SM_CYCURSOR,
            SM_CYMENU,
            SM_CXFULLSCREEN,
            SM_CYFULLSCREEN,
            SM_CYKANJIWINDOW,
            SM_MOUSEPRESENT,
            SM_CYVSCROLL,
            SM_CXHSCROLL,
            SM_DEBUG,
            SM_SWAPBUTTON,
            SM_RESERVED1,
            SM_RESERVED2,
            SM_RESERVED3,
            SM_RESERVED4,
            SM_CXMIN,
            SM_CYMIN,
            SM_CXSIZE,
            SM_CYSIZE,
            SM_CXSIZEFRAME,
            SM_CYSIZEFRAME,
            SM_CXMINTRACK,
            SM_CYMINTRACK,
            SM_CXDOUBLECLK,
            SM_CYDOUBLECLK,
            SM_CXICONSPACING,
            SM_CYICONSPACING,
            SM_MENUDROPALIGNMENT,
            SM_PENWINDOWS,
            SM_DBCSENABLED,
            SM_CMOUSEBUTTONS,
            SM_SECURE,
            SM_CXEDGE,
            SM_CYEDGE,
            SM_CXMINSPACING,
            SM_CYMINSPACING,
            SM_CXSMICON,
            SM_CYSMICON,
            SM_CYSMCAPTION,
            SM_CXSMSIZE,
            SM_CYSMSIZE,
            SM_CXMENUSIZE,
            SM_CYMENUSIZE,
            SM_ARRANGE,
            SM_CXMINIMIZED,
            SM_CYMINIMIZED,
            SM_CXMAXTRACK,
            SM_CYMAXTRACK,
            SM_CXMAXIMIZED,
            SM_CYMAXIMIZED,
            SM_NETWORK,
            SM_CLEANBOOT = 67,
            SM_CXDRAG,
            SM_CYDRAG,
            SM_SHOWSOUNDS,
            SM_CXMENUCHECK,
            SM_CYMENUCHECK,
            SM_SLOWMACHINE,
            SM_MIDEASTENABLED,
            SM_MOUSEWHEELPRESENT,
            SM_XVIRTUALSCREEN,
            SM_YVIRTUALSCREEN,
            SM_CXVIRTUALSCREEN,
            SM_CYVIRTUALSCREEN,
            SM_CMONITORS,
            SM_SAMEDISPLAYFORMAT,
            SM_IMMENABLED,
            SM_CXFOCUSBORDER,
            SM_CYFOCUSBORDER,
            SM_TABLETPC = 86,
            SM_MEDIACENTER,
            SM_STARTER,
            SM_SERVERR2,
            SM_MOUSEHORIZONTALWHEELPRESENT = 91,
            SM_CXPADDEDBORDER = 92,
            SM_DIGITIZER = 94,
            SM_MAXIMUMTOUCHES,
            SM_REMOTESESSION = 0x1000,
            SM_SHUTTINGDOWN = 0x2000,
            SM_REMOTECONTROL,
            SM_CARETBLINKINGENABLED,
            SM_CONVERTIBLESLATEMODE,
            SM_SYSTEMDOCKED,
        }

        public enum STGM
        {
            STGM_READ,
            STGM_WRITE,
            STGM_READWRITE,
        }

        public enum AF
        {
            AF_INET = 2,
            AF_INET6 = 23,
        }

        public enum TCP_TABLE_CLASS
        {
            TCP_TABLE_BASIC_LISTENER,
            TCP_TABLE_BASIC_CONNECTIONS,
            TCP_TABLE_BASIC_ALL,
            TCP_TABLE_OWNER_PID_LISTENER,
            TCP_TABLE_OWNER_PID_CONNECTIONS,
            TCP_TABLE_OWNER_PID_ALL,
            TCP_TABLE_OWNER_MODULE_LISTENER,
            TCP_TABLE_OWNER_MODULE_CONNECTIONS,
            TCP_TABLE_OWNER_MODULE_ALL
        }

        public enum MIB_TCP_STATE
        {
            MIB_TCP_STATE_CLOSED = 1,
            MIB_TCP_STATE_LISTEN,
            MIB_TCP_STATE_SYN_SENT,
            MIB_TCP_STATE_SYN_RCVD,
            MIB_TCP_STATE_ESTAB,
            MIB_TCP_STATE_FIN_WAIT1,
            MIB_TCP_STATE_FIN_WAIT2,
            MIB_TCP_STATE_CLOSE_WAIT,
            MIB_TCP_STATE_CLOSING,
            MIB_TCP_STATE_LAST_ACK,
            MIB_TCP_STATE_TIME_WAIT,
            MIB_TCP_STATE_DELETE_TCB,
        }

        public enum PROCESSOR_ARCHITECTURE : ushort
        {
            PROCESSOR_ARCHITECTURE_INTEL,
            PROCESSOR_ARCHITECTURE_IA64 = 6,
            PROCESSOR_ARCHITECTURE_AMD64 = 9,
            PROCESSOR_ARCHITECTURE_UNKNOWN = 0xFFFF,
        }

        public enum WindowsHook
        {
            WH_MSGFILTER = -1,
            WH_JOURNALRECORD,
            WH_JOURNALPLAYBACK,
            WH_KEYBOARD,
            WH_GETMESSAGE,
            WH_CALLWNDPROC,
            WH_CBT,
            WH_SYSMSGFILTER,
            WH_MOUSE,
            WH_HARDWARE,
            WH_DEBUG,
            WH_SHELL,
            WH_FOREGROUNDIDLE,
            WH_CALLWNDPROCRET,
            WH_KEYBOARD_LL,
            WH_MOUSE_LL,
        }

        public enum INTERNET_OPTION
        {
            INTERNET_OPTION_REFRESH = 37,
            INTERNET_OPTION_PROXY,
            INTERNET_OPTION_SETTINGS_CHANGED,
            INTERNET_OPTION_PER_CONNECTION_OPTION = 75,
            INTERNET_OPTION_SUPPRESS_BEHAVIOR = 81,
        }
        public enum INTERNET_OPEN_TYPE
        {
            INTERNET_OPEN_TYPE_PRECONFIG,
            INTERNET_OPEN_TYPE_DIRECT,
            INTERNET_OPEN_TYPE_PROXY = 3,
            INTERNET_OPEN_TYPE_PRECONFIG_WITH_NO_AUTOPROXY
        }

        public enum INTERNETFEATURELIST
        {
            FEATURE_OBJECT_CACHING,
            FEATURE_ZONE_ELEVATION,
            FEATURE_MIME_HANDLING,
            FEATURE_MIME_SNIFFING,
            FEATURE_WINDOW_RESTRICTIONS,
            FEATURE_WEBOC_POPUPMANAGEMENT,
            FEATURE_BEHAVIORS,
            FEATURE_DISABLE_MK_PROTOCOL,
            FEATURE_LOCALMACHINE_LOCKDOWN,
            FEATURE_SECURITYBAND,
            FEATURE_RESTRICT_ACTIVEXINSTALL,
            FEATURE_VALIDATE_NAVIGATE_URL,
            FEATURE_RESTRICT_FILEDOWNLOAD,
            FEATURE_ADDON_MANAGEMENT,
            FEATURE_PROTOCOL_LOCKDOWN,
            FEATURE_HTTP_USERNAME_PASSWORD_DISABLE,
            FEATURE_SAFE_BINDTOOBJECT,
            FEATURE_UNC_SAVEDFILECHECK,
            FEATURE_GET_URL_DOM_FILEPATH_UNENCODED,
            FEATURE_TABBED_BROWSING,
            FEATURE_SSLUX,
            FEATURE_DISABLE_NAVIGATION_SOUNDS,
            FEATURE_DISABLE_LEGACY_COMPRESSION,
            FEATURE_FORCE_ADDR_AND_STATUS,
            FEATURE_XMLHTTP,
            FEATURE_DISABLE_TELNET_PROTOCOL,
            FEATURE_FEEDS,
            FEATURE_BLOCK_INPUT_PROMPTS,
            FEATURE_ENTRY_COUNT
        }

        public enum INTERNET_PER_CONN_OPTION
        {
            INTERNET_PER_CONN_FLAGS = 1,
            INTERNET_PER_CONN_PROXY_SERVER,
            INTERNET_PER_CONN_PROXY_BYPASS,
            INTERNET_PER_CONN_AUTOCONFIG_URL,
            INTERNET_PER_CONN_AUTODISCOVERY_FLAGS,
            INTERNET_PER_CONN_AUTOCONFIG_SECONDARY_URL,
            INTERNET_PER_CONN_AUTOCONFIG_RELOAD_DELAY_MINS,
            INTERNET_PER_CONN_AUTOCONFIG_LAST_DETECT_TIME,
            INTERNET_PER_CONN_AUTOCONFIG_LAST_DETECT_URL,
            INTERNET_PER_CONN_FLAGS_UI,
        }

        public enum INTERNET_SUPPRESS
        {
            INTERNET_SUPPRESS_RESET_ALL,
            INTERNET_SUPPRESS_COOKIE_POLICY,
            INTERNET_SUPPRESS_COOKIE_POLICY_RESET,
            INTERNET_SUPPRESS_COOKIE_PERSIST,
            INTERNET_SUPPRESS_COOKIE_PERSIST_RESET,
        }

        public enum RasterOperation : uint
        {
            SRCCOPY = 0x00CC0020,
            SRCPAINT = 0x00EE0086,
            SRCAND = 0x008800C6,
            SRCINVERT = 0x00660046,
            SRCERASE = 0x00440328,
            NOTSRCCOPY = 0x00330008,
            NOTSRCERASE = 0x001100A6,
            MERGECOPY = 0x00C000CA,
            MERGEPAINT = 0x00BB0226,
            PATCOPY = 0x00F00021,
            PATPAINT = 0x00FB0A09,
            PATINVERT = 0x005A0049,
            DSTINVERT = 0x00550009,
            BLACKNESS = 0x00000042,
            WHITENESS = 0x00FF0062,
            NOMIRRORBITMAP = 0x80000000,
            CAPTUREBLT = 0x40000000,
        }

        public enum DROPIMAGETYPE
        {
            DROPIMAGE_INVALID = -1,
            DROPIMAGE_NONE,
            DROPIMAGE_COPY,
            DROPIMAGE_MOVE,
            DROPIMAGE_LINK = 4,
            DROPIMAGE_LABEL = 6,
            DROPIMAGE_WARNING = 7,
            DROPIMAGE_NOIMAGE = 8
        }

        public enum WINDOWCOMPOSITIONATTRIB
        {
            WCA_UNDEFINED,
            WCA_NCRENDERING_ENABLED,
            WCA_NCRENDERING_POLICY,
            WCA_TRANSITIONS_FORCEDISABLED,
            WCA_ALLOW_NCPAINT,
            WCA_CAPTION_BUTTON_BOUNDS,
            WCA_NONCLIENT_RTL_LAYOUT,
            WCA_FORCE_ICONIC_REPRESENTATION,
            WCA_EXTENDED_FRAME_BOUNDS,
            WCA_HAS_ICONIC_BITMAP,
            WCA_THEME_ATTRIBUTES,
            WCA_NCRENDERING_EXILED,
            WCA_NCADORNMENTINFO,
            WCA_EXCLUDED_FROM_LIVEPREVIEW,
            WCA_VIDEO_OVERLAY_ACTIVE,
            WCA_FORCE_ACTIVEWINDOW_APPEARANCE,
            WCA_DISALLOW_PEEK,
            WCA_CLOAK,
            WCA_CLOAKED,
            WCA_ACCENT_POLICY,
            WCA_FREEZE_REPRESENTATION,
            WCA_EVER_UNCLOAKED,
            WCA_VISUAL_OWNER,
            WCA_LAST,
        }

        public enum ACCENT_STATE
        {
            ACCENT_DISABLED,
            ACCENT_ENABLE_GRADIENT,
            ACCENT_ENABLE_TRANSPARENTGRADIENT,
            ACCENT_ENABLE_BLURBEHIND,
            ACCENT_INVALID_STATE,
        }

        public enum PROCESS_DPI_AWARENESS
        {
            PROCESS_DPI_UNAWARE,
            PROCESS_SYSTEM_DPI_AWARE,
            PROCESS_PER_MONITOR_DPI_AWARE,
        }

        public enum MONITOR_DPI_TYPE
        {
            MDT_EFFECTIVE_DPI,
            MDT_ANGULAR_DPI,
            MDT_RAW_DPI,
            MDT_DEFAULT = MDT_EFFECTIVE_DPI,
        }

        public enum SERVICE_STATE
        {
            SERVICE_STOPPED = 1,
            SERVICE_START_PENDING,
            SERVICE_STOP_PENDING,
            SERVICE_RUNNING,
            SERVICE_CONTINUE_PENDING,
            SERVICE_PAUSE_PENDING,
            SERVICE_PAUSED,
        }
    }
}
