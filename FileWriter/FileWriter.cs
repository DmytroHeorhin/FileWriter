using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Convestudo.Unmanaged
{
    public class FileWriter : IFileWriter
    {
        private readonly FileHandle _fileHandle;

        public FileWriter(string fileName)
        {
            var handle = UnmanagedMethods.CreateFile(
                fileName,
                DesiredAccess.Write,
                ShareMode.None,
                IntPtr.Zero,
                CreationDisposition.CreateAlways,
                FlagsAndAttributes.Normal,
                IntPtr.Zero);

            _fileHandle = new FileHandle(handle);

            if(_fileHandle.IsInvalid)
                ThrowLastWin32Err();
        }

        public void Write(string str)
        {
            if(_fileHandle.IsInvalid)
                throw new ObjectDisposedException(nameof(FileWriter));

            var bytes = Encoding.ASCII.GetBytes(str);
            uint bytesWritten = 0;
            UnmanagedMethods.WriteFile(_fileHandle, bytes, (uint)bytes.Length, ref bytesWritten, IntPtr.Zero);
        }

        public void WriteLine(string str)
        {
            Write($"{str}{Environment.NewLine}");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                CloseFileHandle();
            }
        }

        private void CloseFileHandle()
        {
            if (_fileHandle != null && !_fileHandle.IsInvalid)
            {
                _fileHandle.Close();
            }
        }

        private static void ThrowLastWin32Err()
        {
            Marshal.ThrowExceptionForHR(
             Marshal.GetHRForLastWin32Error());
        }
    }
}