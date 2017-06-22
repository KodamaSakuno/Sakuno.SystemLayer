﻿using Microsoft.Win32;
using System;

namespace Sakuno.SystemLayer
{
    public static class OS
    {
        static OperatingSystem _os = Environment.OSVersion;

        public static bool IsWindows => _os.Platform == PlatformID.Win32NT;

        public static bool Is64Bit => IntPtr.Size == 8;

        public static bool IsWinXPOrLater => _os.Version.Major >= 6 || (_os.Version.Major == 5 && _os.Version.Minor >= 1);
        public static bool IsWin7OrLater => _os.Version.Major >= 7 || (_os.Version.Major == 6 && _os.Version.Minor >= 1);
        public static bool IsWin8OrLater => _os.Version.Major >= 7 || (_os.Version.Major == 6 && _os.Version.Minor >= 2);
        public static bool IsWin81OrLater => _os.Version.Major >= 7 || (_os.Version.Major == 6 && _os.Version.Minor >= 3);
        public static bool IsWin10OrLater => _os.Version.Major >= 10;

        public static int? DotNetFrameworkReleaseNumber
        {
            get
            {
                const string SubKey = @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\";

                try
                {
                    using (var registerKey = Registry.LocalMachine.OpenSubKey(SubKey))
                    {
                        var value = registerKey?.GetValue("Release");

                        return value != null ? (int?)value : null;
                    }
                }
                catch
                {
                    return null;
                }
            }
        }

    }
}