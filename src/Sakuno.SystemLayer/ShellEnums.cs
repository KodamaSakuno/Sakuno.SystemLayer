﻿using System;

namespace Sakuno.SystemLayer
{
    partial class NativeEnums
    {
        [Flags]
        public enum SHCONTF
        {
            SHCONTF_CHECKING_FOR_CHILDREN = 0x10,
            SHCONTF_FOLDERS = 0x20,
            SHCONTF_NONFOLDERS = 0x40,
            SHCONTF_INCLUDEHIDDEN = 0x80,
            SHCONTF_INIT_ON_FIRST_NEXT = 0x100,
            SHCONTF_NETPRINTERSRCH = 0x200,
            SHCONTF_SHAREABLE = 0x400,
            SHCONTF_STORAGE = 0x800,
            SHCONTF_NAVIGATION_ENUM = 0x1000,
            SHCONTF_FASTITEMS = 0x2000,
            SHCONTF_FLATLIST = 0x4000,
            SHCONTF_ENABLE_ASYNC = 0x8000,
            SHCONTF_INCLUDESUPERHIDDEN = 0x10000,
        }

        [Flags]
        public enum SIGDN : uint
        {
            SIGDN_NORMALDISPLAY,
            SIGDN_PARENTRELATIVEPARSING = 0x80018001,
            SIGDN_DESKTOPABSOLUTEPARSING = 0x80028000,
            SIGDN_PARENTRELATIVEEDITING = 0x80031001,
            SIGDN_DESKTOPABSOLUTEEDITING = 0x8004c000,
            SIGDN_FILESYSPATH = 0x80058000,
            SIGDN_URL = 0x80068000,
            SIGDN_PARENTRELATIVEFORADDRESSBAR = 0x8007c001,
            SIGDN_PARENTRELATIVE = 0x80080001,
            SIGDN_PARENTRELATIVEFORUI = 0x80094001,
        }

        [Flags]
        public enum SICHINTF : uint
        {
            SICHINT_DISPLAY,
            SICHINT_ALLFIELDS = 0x80000000,
            SICHINT_CANONICAL = 0x10000000,
            SICHINT_TEST_FILESYSPATH_IF_NOT_EQUAL = 0x20000000,
        }

        [Flags]
        public enum SFGAO : uint
        {
            SFGAO_CANCOPY = 0x00000001,
            SFGAO_CANMOVE = 0x00000002,
            SFGAO_CANLINK = 0x00000004,
            SFGAO_STORAGE = 0x00000008,
            SFGAO_CANRENAME = 0x00000010,
            SFGAO_CANDELETE = 0x00000020,
            SFGAO_HASPROPSHEET = 0x00000040,
            SFGAO_DROPTARGET = 0x00000100,
            SFGAO_CAPABILITYMASK = 0x00000177,
            SFGAO_SYSTEM = 0x00001000,
            SFGAO_ENCRYPTED = 0x00002000,
            SFGAO_ISSLOW = 0x00004000,
            SFGAO_GHOSTED = 0x00008000,
            SFGAO_LINK = 0x00010000,
            SFGAO_SHARE = 0x00020000,
            SFGAO_READONLY = 0x00040000,
            SFGAO_HIDDEN = 0x00080000,
            SFGAO_DISPLAYATTRMASK = 0x000FC000,
            SFGAO_FILESYSANCESTOR = 0x10000000,
            SFGAO_FOLDER = 0x20000000,
            SFGAO_FILESYSTEM = 0x40000000,
            SFGAO_HASSUBFOLDER = 0x80000000,
            SFGAO_CONTENTSMASK = 0x80000000,
            SFGAO_VALIDATE = 0x01000000,
            SFGAO_REMOVABLE = 0x02000000,
            SFGAO_COMPRESSED = 0x04000000,
            SFGAO_BROWSABLE = 0x08000000,
            SFGAO_NONENUMERATED = 0x00100000,
            SFGAO_NEWCONTENT = 0x00200000,
            SFGAO_CANMONIKER = 0x00400000,
            SFGAO_HASSTORAGE = 0x00400000,
            SFGAO_STREAM = 0x00400000,
            SFGAO_STORAGEANCESTOR = 0x00800000,
            SFGAO_STORAGECAPMASK = 0x70C50008,
            SFGAO_PKEYSFGAOMASK = 0x81044000,
        }

        [Flags]
        public enum SHCOLSTATE
        {
            SHCOLSTATE_DEFAULT,
            SHCOLSTATE_TYPE_STR = 0x1,
            SHCOLSTATE_TYPE_INT = 0x2,
            SHCOLSTATE_TYPE_DATE = 0x3,
            SHCOLSTATE_TYPEMASK = 0xF,
            SHCOLSTATE_ONBYDEFAULT = 0x10,
            SHCOLSTATE_SLOW = 0x20,
            SHCOLSTATE_EXTENDED = 0x40,
            SHCOLSTATE_SECONDARYUI = 0x80,
            SHCOLSTATE_HIDDEN = 0x100,
            SHCOLSTATE_PREFER_VARCMP = 0x200,
            SHCOLSTATE_PREFER_FMTCMP = 0x400,
            SHCOLSTATE_NOSORTBYFOLDERNESS = 0x800,
            SHCOLSTATE_VIEWONLY = 0x10000,
            SHCOLSTATE_BATCHREAD = 0x20000,
            SHCOLSTATE_NO_GROUPBY = 0x40000,
            SHCOLSTATE_FIXED_WIDTH = 0x1000,
            SHCOLSTATE_NODPISCALE = 0x2000,
            SHCOLSTATE_FIXED_RATIO = 0x4000,
            SHCOLSTATE_DISPLAYMASK = 0xF000,
        }

        [Flags]
        public enum SHGFI
        {
            SHGFI_LARGEICON = 0x000000000,
            SHGFI_SMALLICON = 0x000000001,
            SHGFI_OPENICON = 0x000000002,
            SHGFI_SHELLICONSIZE = 0x000000004,
            SHGFI_PIDL = 0x000000008,
            SHGFI_USEFILEATTRIBUTES = 0x000000010,
            SHGFI_ICON = 0x000000100,
            SHGFI_DISPLAYNAME = 0x000000200,
            SHGFI_TYPENAME = 0x000000400,
            SHGFI_ATTRIBUTES = 0x000000800,
            SHGFI_ICONLOCATION = 0x000001000,
            SHGFI_EXETYPE = 0x000002000,
            SHGFI_SYSICONINDEX = 0x000004000,
            SHGFI_LINKOVERLAY = 0x000008000,
            SHGFI_SELECTED = 0x000010000,
            SHGFI_ATTR_SPECIFIED = 0x000020000,
        }
    }
}
