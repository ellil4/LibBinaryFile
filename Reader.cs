using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LibBinaryFile
{
    public class Reader
    {
        public FileStream mStream;
        private int mUnitLenAsByte = -1;
        public byte[] mByteBuf = null;
        //public ulong mCurAtUnit = 0;

        public Reader(int UnitLenAsByte)
        {
            mUnitLenAsByte = UnitLenAsByte;
            mByteBuf = new byte[UnitLenAsByte];
        }

        public void Open(String path)
        {
            mStream = new FileStream(
                path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            //mCurAtUnit = 0;
        }

        public int ReadUnitAt(long UnitIndex)
        {
            mStream.Seek(UnitIndex * mUnitLenAsByte, SeekOrigin.Begin);
            int red = mStream.Read(mByteBuf, 0, mUnitLenAsByte);
            //mCurAtUnit = (ulong)(offUnits + 1);
            return red;
        }

        public ulong GetUInt64InBuf(int begat)
        {
            return BitConverter.ToUInt64(mByteBuf, begat);
        }

        public double GetDoubleInBuf(int begat)
        {
            return BitConverter.ToDouble(mByteBuf, begat);
        }

        public int ReadUnitBy()
        {
            int red = mStream.Read(mByteBuf, 0, mUnitLenAsByte);
            //mCurAtUnit++;
            return red;
        }

        public void Close()
        {
            mStream.Close();
            mStream = null;
        }
    }
}
