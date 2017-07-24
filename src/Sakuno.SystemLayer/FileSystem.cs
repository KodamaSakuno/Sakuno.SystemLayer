namespace Sakuno.SystemLayer
{
    public static class FileSystem
    {
        public static bool Unblock(string fileName) => NativeMethods.Kernel32.DeleteFileW(fileName + ":Zone.Identifier");
    }
}
