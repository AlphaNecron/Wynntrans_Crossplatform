using System.Runtime.InteropServices;

namespace Wynntrans_CrossAva.Core
{
    public static class Os
    {
        private static bool IsWindows() => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        private static bool IsLinux() => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        private static bool IsMac() => RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

        public static OSPlatform GetOs()
        {
            if (IsWindows()) return OSPlatform.Windows;
            else if (IsMac()) return OSPlatform.OSX;
            else if (IsLinux()) return OSPlatform.Linux;
            else return OSPlatform.FreeBSD;
        }
    }
}