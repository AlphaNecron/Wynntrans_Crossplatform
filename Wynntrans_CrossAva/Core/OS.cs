using System.Runtime.InteropServices;

namespace Wynntrans_CrossAva.Core
{
    public static class OS
    {
        public static bool IsWindows() => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        public static bool IsLinux() => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        public static bool IsMac() => RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

        public static OSPlatform GetOS()
        {
            if (IsWindows()) return OSPlatform.Windows;
            if (IsMac()) return OSPlatform.OSX;
            if (IsLinux()) return OSPlatform.Linux;
            return OSPlatform.FreeBSD;
        }
    }
}