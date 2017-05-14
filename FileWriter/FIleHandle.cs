using System;
using Microsoft.Win32.SafeHandles;

namespace Convestudo.Unmanaged
{
    internal class FileHandle : SafeHandleZeroOrMinusOneIsInvalid
    {       
        public FileHandle(IntPtr handle) : base(true)
        {
            SetHandle(handle);
        }

        protected override bool ReleaseHandle()
        {
            return UnmanagedMethods.CloseHandle(handle);
        }
    }
}
