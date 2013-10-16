using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibBinaryFile
{
    class MainTest
    {
        static void Main(string[] args)
        {
            Reader rd = new Reader(64);
            rd.Open("C:\\Users\\el\\Documents\\Visual Studio 2010\\Projects\\PsychHRV\\PsychHRV\\bin\\Debug\\HRV1.dat");
            
            rd.ReadUnitBy();
            Console.WriteLine(rd.GetUInt64InBuf(0, rd.mByteBuf));
            Console.WriteLine(rd.GetDoubleInBuf(8, rd.mByteBuf));

            rd.ReadUnitBy();
            Console.WriteLine(rd.GetUInt64InBuf(0, rd.mByteBuf));
            Console.WriteLine(rd.GetDoubleInBuf(8, rd.mByteBuf));

            rd.Close();
            Console.ReadLine();
        }
    }
}
