using System;
using System.Runtime.InteropServices;

namespace Convestudo.Unmanaged
{
    internal static class UnmanagedMethods
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr CreateFile(string lpFileName, DesiredAccess dwDesiredAccess, ShareMode dwShareMode, IntPtr lpSecurityAttributes, CreationDisposition dwCreationDisposition, FlagsAndAttributes dwFlagsAndAttributes, IntPtr hTemplateFile);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool WriteFile(FileHandle hFile, byte[] aBuffer, uint cbToWrite, ref uint cbThatWereWritten, IntPtr pOverlapped);

        [DllImport("kernel32", SetLastError = true)]
        internal static extern bool CloseHandle(IntPtr handle);
    }
}
