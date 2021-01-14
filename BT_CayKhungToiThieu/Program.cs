/**
 * Ten:Nguyen Le Trong Tien
 * MSSV: 19211TT4165
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CayBaoTrum
{
    class Program
    {
        static void Main(string[] args)
        {
            TienIchCayBaoTrum.GhiFile("caybaotrum.dat");
            int[][] cbt = TienIchCayBaoTrum.TaoMaTranTrongSoTuFile("caybaotrum.dat");
            TienIchCayBaoTrum.InMaTran(cbt);

            Canh[] arr;
            int a = 0;

            arr = TienIchCayBaoTrum.Primm(cbt, 5, out a);

            foreach (var k in arr)
            {
                Console.WriteLine(k + "\t");
            }
        }
    }
}
