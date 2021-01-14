/**
 * TEN: NGUYỄN LÊ TRỌNG TIỀN
 * MSSV: 19211TT4165
 * NGAY: 3/12/2020
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToMau
{
    class Program
    {
        static void Main(string[] args)
        {
            TienIchToMau.GhiFile("tomau.dat");
            int[][] maTranKe = TienIchToMau.DocFile("tomau.dat");
            TienIchToMau.inMaTran(maTranKe);
            Console.WriteLine();
            int[] kq = TienIchToMau.ToMauHeuristic(maTranKe);
            TienIchToMau.inBangMau(kq);
        }
    }
}
