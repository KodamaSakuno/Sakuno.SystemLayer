using System;

namespace Sakuno.SystemLayer
{
    partial class NativeEnums
    {
        [Flags]
        internal enum NLM_INTERNET_CONNECTIVITY
        {
            NLM_INTERNET_CONNECTIVITY_WEBHIJACK = 1,
            NLM_INTERNET_CONNECTIVITY_PROXIED = 2,
            NLM_INTERNET_CONNECTIVITY_CORPORATE = 4,
        }
    }
}
