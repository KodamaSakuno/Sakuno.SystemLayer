using Microsoft.Win32;
using System;
using System.Security.Principal;
using System.Threading;

namespace Sakuno.SystemLayer
{
    public static class Security
    {
        public static bool IsAdministrator { get; }

        static bool IsUacEnabled
        {
            get
            {
                const string SubKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System";
                const string Name = "EnableLUA";

                try
                {
                    using var registerKey = Registry.LocalMachine.OpenSubKey(SubKey, false);

                    if (registerKey != null && registerKey.GetValueKind(Name) == RegistryValueKind.DWord)
                    {
                        var value = (int)registerKey.GetValue(Name);

                        return value == 1;
                    }

                    return true;
                }
                catch
                {
                    return true;
                }
            }
        }

        static Security()
        {
            var domain = Thread.GetDomain();
            domain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);

            var principal = (WindowsPrincipal)Thread.CurrentPrincipal;
            IsAdministrator = principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
