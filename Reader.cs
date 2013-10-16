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

        /*public int ReadUnitAt(long UnitIndex)
        {
            mStream.Seek(UnitIndex * mUnitLenAsByte, SeekOrigin.Begin);
            int red = mStream.Read(mByteBuf, 0, mUnitLenAsByte);
            //mCurAtUnit = (ulong)(offUnits + 1);
            return red;
        }*/

        public List<byte[]> ReadTillEnd(long BegUnitIndex)
        {
            List<byte[]> retval = new List<byte[]>();
            int red = 100;
            long curUnitIndex = BegUnitIndex;
            while (red >= mUnitLenAsByte)
            {
                byte[] dataSpan = new byte[mUnitLenAsByte];
                    
                mStream.Seek(curUnitIndex * mUnitLenAsByte, SeekOrigin.Begin);
                red = mStream.Read(dataSpan, 0, mUnitLenAsByte);
                
                if (red == mUnitLenAsByte)
                {
                    retval.Add(dataSpan);
                    curUnitIndex++;
                }
            }

            return retval;
        }

        public ulong GetUInt64InBuf(int begat, byte[] source)
        {
            return BitConverter.ToUInt64(source, begat);
        }

        public double GetDoubleInBuf(int begat, byte[] source)
        {
            return BitConverter.ToDouble(source, begat);
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
